using Cultivation_Way.Abstract;
using NeoModLoader.utils;
using UnityEngine;

namespace CW_FantasyCreatures.content;

public class VanillaEffects : ExtendedLibrary<EffectAsset, VanillaEffects>
{
    public static readonly EffectAsset fx_spawn_red;

    internal VanillaEffects()
    {
        Clone(nameof(fx_spawn_red), "fx_spawn");
        GameObject new_prefab = Object.Instantiate(UnityEngine.Resources.Load<GameObject>(t.prefab_id),
                                                   Main.Instance.PrefabLibrary);
        new_prefab.GetComponent<SpriteRenderer>().color = Color.red;
        t.prefab_id = "effects/prefabs/PrefabSpawnSmallRed";
        t.spawn_action = AssetManager.effects_library.showSpawnEffect;
        ResourcesPatch.PatchResource(t.prefab_id, new_prefab);
    }
}