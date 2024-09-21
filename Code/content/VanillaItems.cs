using Cultivation_Way.Abstract;
using Cultivation_Way.Core;
using NeoModLoader.api.attributes;

namespace CW_FantasyCreatures.content;

public class VanillaItems : ExtendedLibrary<ItemAsset, VanillaItems>
{
    public static ItemAsset bloodsucker_jaws;

    internal VanillaItems()
    {
        cached_library = AssetManager.items;
        Clone(nameof(bloodsucker_jaws), "jaws");
        t.action_attack_target += [Hotfixable](pSelf, pTarget, pTile) =>
        {
            if (pTarget.a.asset.id == nameof(Creatures.bloodsucker)) return true;
            if (pTarget.a.hasStatus(nameof(StatusEffects.blood_mark))) return true;

            (pTarget.a as CW_Actor)?.AddStatus(nameof(StatusEffects.blood_mark), pSelf, 15);
            return true;
        };
    }
}