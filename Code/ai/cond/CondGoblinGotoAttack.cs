namespace CW_FantasyCreatures.ai.cond;

public class CondGoblinGotoAttack : BehaviourActorCondition
{
    public override bool check(Actor pActor)
    {
        return pActor.data.hasFlag(ActorDataKeys.goblin_goto_attack_flag);
    }
}