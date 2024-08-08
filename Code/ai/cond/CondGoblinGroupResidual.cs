using CW_FantasyCreatures.content;

namespace CW_FantasyCreatures.ai.cond;

public class CondGoblinGroupResidual : BehaviourActorCondition
{
    public override bool check(Actor pActor)
    {
        if (pActor.homeBuilding == null)
        {
            return false;
        }

        if (pActor.asset.id                                   == nameof(Creatures.goblin_shaman) &&
            pActor.data.health / (float)pActor.getMaxHealth() <= 0.5f)
        {
            return true;
        }

        var spawner = pActor.homeBuilding.component_unit_spawner;
        return spawner.units_limit * 0.5 > spawner.units_current;
    }
}