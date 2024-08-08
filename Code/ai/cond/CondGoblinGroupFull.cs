namespace CW_FantasyCreatures.ai.cond;

public class CondGoblinGroupFull : BehaviourActorCondition
{
    public override bool check(Actor pActor)
    {
        if (pActor.homeBuilding == null)
        {
            return false;
        }

        var spawner = pActor.homeBuilding.component_unit_spawner;
        return spawner.units_limit * 0.9 <= spawner.units_current;
    }
}