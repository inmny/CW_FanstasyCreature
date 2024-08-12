using ai.behaviours;

namespace CW_FantasyCreatures.ai.beh;

public class BehGoblinUnselectMemers : BehaviourActionActor
{
    public override bool errorsFound(Actor pObject)
    {
        return base.errorsFound(pObject) || pObject.homeBuilding == null;
    }

    public override BehResult execute(Actor pObject)
    {
        Building building = pObject.homeBuilding;
        UnitSpawner spawner = building.component_unit_spawner;

        foreach (Actor unit in spawner.units)
        {
            unit.data.removeFlag(ActorDataKeys.goblin_goto_attack_flag);
            unit.data.removeString(ActorDataKeys.goblin_attack_city_string);
        }

        return BehResult.Continue;
    }
}