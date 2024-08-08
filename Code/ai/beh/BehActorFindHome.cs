using ai.behaviours;

namespace CW_FantasyCreatures.ai.beh;

public class BehActorFindHome : BehaviourActionActor
{
    public override bool errorsFound(Actor pObject)
    {
        return base.errorsFound(pObject) || pObject.homeBuilding == null;
    }

    public override BehResult execute(Actor pObject)
    {
        pObject.beh_building_target = pObject.homeBuilding;
        return BehResult.Continue;
    }
}