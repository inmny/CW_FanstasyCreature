using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Cultivation_Way.Addon;
using CW_FantasyCreatures.content;
using CW_FantasyCreatures.ui;
using HarmonyLib;
using NCMS;
using NeoModLoader.api;
using NeoModLoader.api.attributes;
using NeoModLoader.General;
using NeoModLoader.utils;
using ReflectionUtility;
#if 一米_中文名
using Chinese_Name;
#endif

namespace CW_FantasyCreatures;

[ModEntry]
public class Main : CW_Addon<Main>, IReloadable
{
    private       Creatures _creatures;
    public static Camps     Camps { get; private set; }
    public static ModDeclare Declaration { get; private set; }

    [Hotfixable]
    public void Reload()
    {
        typeof(SpriteLoadUtils).GetField("dirNCMSSettings", BindingFlags.Static | BindingFlags.NonPublic).GetValue(null)
                               ?.CallMethod("Clear");
        typeof(ResourcesPatch).GetMethod("LoadResourceFromFolder", BindingFlags.Static | BindingFlags.NonPublic)
                              .Invoke(null, new object[] { Path.Combine(Declaration.FolderPath, "GameResources") });

        var locales_dir = GetLocaleFilesDirectory(Declaration);
        if (Directory.Exists(locales_dir))
        {
            var files = Directory.GetFiles(locales_dir);
            foreach (var locale_file in files)
                try
                {
                    if (locale_file.EndsWith(".json"))
                        LM.LoadLocale(Path.GetFileNameWithoutExtension(locale_file), locale_file);
                    else if (locale_file.EndsWith(".csv")) LM.LoadLocales(locale_file);
                }
                catch (FormatException e)
                {
                    LogWarning(e.Message);
                }

            LM.ApplyLocale();
        }

        ActorAnimationLoader.dict_units.Clear();

        foreach (var unit in World.world.units)
        {
            if (unit != null && unit.isAlive())
            {
                unit.clearSprites();
            }
        }
    }

    protected override void OnModLoad()
    {
        base.OnModLoad();
        PrefabLibrary.gameObject.SetActive(false);
        Declaration = GetDeclaration();
        Config.isEditor = true;

        foreach (Type t in Assembly.GetExecutingAssembly().GetTypes())
            if (t.Name.StartsWith("Patch"))
                Harmony.CreateAndPatchAll(t);

        foreach (Type type in Assembly.GetExecutingAssembly().GetTypes()
                                      .Where(x => x.IsSubclassOf(typeof(StringLibrary))))
            Activator.CreateInstance(type);

#if 一米_中文名
        CN_NameGeneratorLibrary.SubmitDirectoryToLoad(
            Path.Combine(Declaration.FolderPath, "name_generators")
        );
        WordLibraryManager.SubmitDirectoryToLoad(
            Path.Combine(Declaration.FolderPath, "word_libraries")
        );
#endif

        Camps = new Camps();
        _ = new Traits();
        _ = new VanillaItems();
        _ = new VanillaEffects();
        foreach (
            var type in Assembly
                        .GetExecutingAssembly()
                        .GetTypes()
                        .Where(x => x.IsSubclassOf(typeof(BaseExtendedLibrary)) && !x.IsAbstract)
        )
            _ = (BaseExtendedLibrary)Activator.CreateInstance(type);
        Buildings.init();
        Biomes.init();
        Drops.init();
        _ = new StatusEffects();
        _ = new Resources();
        TabManager.init();
        _ = new Elements();
    }
}