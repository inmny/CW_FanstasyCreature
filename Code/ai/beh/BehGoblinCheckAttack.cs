using System.Collections.Generic;
using ai.behaviours;
using CW_FantasyCreatures.content;

namespace CW_FantasyCreatures.ai.beh;

public class BehGoblinCheckAttack : BehaviourActionActor
{
    public override bool errorsFound(Actor pObject)
    {
        return base.errorsFound(pObject) || pObject.homeBuilding == null;
    }

    public override BehResult execute(Actor pObject)
    {
        Building building = pObject.homeBuilding;
        UnitSpawner spawner = building.component_unit_spawner;

        var attack_city_id = "";

        foreach (Actor unit in spawner.units)
        {
            if (unit.asset.id != nameof(Creatures.goblin_shaman)) continue;

            unit.data.get(ActorDataKeys.goblin_attack_city_string, out attack_city_id);
            break;
        }

        if (string.IsNullOrEmpty(attack_city_id)) signalToStop(spawner.units);

        City city = World.world.cities.get(attack_city_id);
        if (city == null)
        {
            signalToStop(spawner.units);
            return BehResult.Stop;
        }

        var min_dist = float.MaxValue;
        TileZone nearest_zone = null;
        foreach (TileZone zone in city.borderZones)
        {
            var dist = Toolbox.DistTile(zone.centerTile, pObject.currentTile);
            if (dist < min_dist)
            {
                min_dist = dist;
                nearest_zone = zone;
            }
        }

        pObject.beh_tile_target = nearest_zone?.centerTile;
        if (pObject.beh_tile_target == null)
        {
            signalToStop(spawner.units);
            return BehResult.Stop;
        }

        signalGo(spawner.units, nearest_zone);
        return BehResult.Continue;
    }

    private void signalGo(HashSet<Actor> pSpawnerUnits, TileZone zone)
    {
        foreach (Actor unit in pSpawnerUnits)
        {
            if (unit.asset.id == nameof(Creatures.goblin_shaman)) continue;
            if (unit.data.hasFlag(ActorDataKeys.goblin_goto_attack_flag)) continue;

            unit.goTo(zone.tiles.GetRandom(), true);
        }
    }

    private void signalToStop(HashSet<Actor> pSpawnerUnits)
    {
        foreach (Actor unit in pSpawnerUnits)
        {
            unit.data.removeFlag(ActorDataKeys.goblin_goto_attack_flag);
            unit.data.removeString(ActorDataKeys.goblin_attack_city_string);
        }
    }
}