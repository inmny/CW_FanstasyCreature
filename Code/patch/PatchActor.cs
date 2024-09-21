using Cultivation_Way.Utils;
using CW_FantasyCreatures.content;
using HarmonyLib;
using NeoModLoader.api.attributes;
using UnityEngine;

namespace CW_FantasyCreatures.patch;

internal static class PatchActor
{
    [Hotfixable]
    [HarmonyPostfix]
    [HarmonyPatch(typeof(Actor), nameof(Actor.u5_curTileAction))]
    private static void Postfix_slimemove(Actor __instance)
    {
        if (__instance.asset.id != nameof(Creatures.king_slime)) return;
        if (__instance.update_done || __instance.zPosition.y > 0 || __instance.flying) return;

        if (__instance._last_main_sprite.name == "walk_0_0" && __instance.is_moving)
        {
            WorldTile center = __instance.currentTile;
            var radius = 8;
            foreach (BaseSimObject a in GeneralHelper.find_enemies_in_circle(center, null, radius, false))
            {
                if (a.a.asset.id == nameof(Creatures.king_slime)) continue;
                Vector2 delta = a.currentPosition - __instance.currentPosition;
                Vector2 dir = delta.normalized;
                var s_dist = delta.sqrMagnitude;
                a.a.addForce(radius * dir.x / (radius + s_dist), radius * dir.y / (radius + s_dist),
                             radius         / (radius + s_dist));
                a.a.getHit(a.stats[S.damage] * radius / (radius + s_dist), pAttackType: AttackType.Other,
                           pAttacker: __instance);
            }
        }
    }
}