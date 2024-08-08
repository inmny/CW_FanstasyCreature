using System;
using System.Linq;
using ai.behaviours;

namespace CW_FantasyCreatures.ai.beh;

public class BehGoblinSelectMembers : BehaviourActionActor
{
    public override BehResult execute(Actor pObject)
    {
        Building building = pObject.homeBuilding;
        UnitSpawner spawner = building.component_unit_spawner;

        pObject.data.get(ActorDataKeys.goblin_attack_city_string, out string city_id);
        City city = World.world.cities.get(city_id);
        if (city == null)
        {
            pObject.data.removeString(ActorDataKeys.goblin_attack_city_string);
            foreach (Actor unit in spawner.units) unit.data.removeFlag(ActorDataKeys.goblin_goto_attack_flag);

            return BehResult.Stop;
        }

        pObject.data.addFlag(ActorDataKeys.goblin_goto_attack_flag);

        var amount = (int)Math.Max(spawner.units_current * 0.8, city.getArmy() * 0.5);
        amount -= spawner.units.Count(x => x.data.hasFlag(ActorDataKeys.goblin_goto_attack_flag));
        foreach (Actor unit in spawner.units)
        {
            if (amount <= 0) break;
            amount--;
            unit.data.addFlag(ActorDataKeys.goblin_goto_attack_flag);
        }

        return BehResult.Continue;
    }
}