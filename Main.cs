using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Cultivation_Way.Addon;
using CW_FantasyCreatures.content;
using NeoModLoader.api;
using NCMS;

#if 一米_中文名
using Chinese_Name;
#endif

namespace CW_FantasyCreatures;

[ModEntry]
public class Main : CW_Addon<Main>, IReloadable
{
    private Creatures _creatures;
    public static ModDeclare Declaration { get; private set; }

    public void Reload()
    {
        foreach (var library in BaseExtendedLibrary.libraries)
            library.Reload();
    }

    protected override void OnModLoad()
    {
        base.OnModLoad();
        Declaration = GetDeclaration();

#if 一米_中文名
        CN_NameGeneratorLibrary.SubmitDirectoryToLoad(
            Path.Combine(Declaration.FolderPath, "name_generators")
        );
        WordLibraryManager.SubmitDirectoryToLoad(
            Path.Combine(Declaration.FolderPath, "word_libraries")
        );
#endif

        foreach (
            var type in Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(x => x.IsSubclassOf(typeof(BaseExtendedLibrary)) && !x.IsAbstract)
        )
            _ = (BaseExtendedLibrary)Activator.CreateInstance(type);
    }
}