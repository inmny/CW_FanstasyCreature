using ai.behaviours;
using UnityEngine;

namespace CW_FantasyCreatures.ai.beh;

public class BehGoblinRestoreHealth : BehaviourActionActor
{
    public override BehResult execute(Actor pObject)
    {
        foreach (var tile in pObject.currentTile.zone.tiles)
        {
            foreach (var unit in tile._units)
            {
                if (unit.isRace(pObject) && Toolbox.randomChance(0.3f) && unit.data.health < unit.getMaxHealth())
                {
                    unit.restoreHealth((int)(unit.getMaxHealth() / 20f));
                    unit.spawnParticle(Color.green);
                }
            }
        }

        return BehResult.Continue;
    }
}