namespace CW_FantasyCreatures.ai.cond;

public class CondGoblinHasHome : BehaviourActorCondition
{
    public override bool check(Actor pActor)
    {
        return pActor.homeBuilding != null;
    }
}