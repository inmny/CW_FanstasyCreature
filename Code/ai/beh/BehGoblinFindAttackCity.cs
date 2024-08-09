using System.Collections.Generic;
using ai.behaviours;
using NeoModLoader.api.attributes;

namespace CW_FantasyCreatures.ai.beh;

public class BehGoblinFindAttackCity : BehaviourActionActor
{
    public override bool errorsFound(Actor pObject)
    {
        return base.errorsFound(pObject) || pObject.homeBuilding == null;
    }

    public override BehResult execute(Actor pObject)
    {
        var attack_city_id = FindAttackCity(pObject);
        if (string.IsNullOrEmpty(attack_city_id)) return BehResult.Stop;
        pObject.data.set(ActorDataKeys.goblin_attack_city_string, attack_city_id);
        return BehResult.Continue;
    }

    private string FindAttackCity(Actor actor)
    {
        var possible_cities = new List<City>();
        foreach (City city in World.world.cities.list)
        {
            if (!city.getTile().isSameIsland(actor.currentTile)) continue;
            possible_cities.Add(city);
        }

        if (possible_cities.Count > 0)
        {
            City city = findSafestCity(possible_cities, actor, actor.homeBuilding.component_unit_spawner.units_current);
            if (city != null) return city.data.id;
        }

        City safest_city = findSafestCity(world.cities.list, actor, float.MaxValue);
        return safest_city?.data.id;
    }

    private City findSafestCity(List<City> cities, Actor actor, float tolerant_max_danger)
    {
        var min_danger = tolerant_max_danger;
        City safest_city = null;
        foreach (City city in cities)
        {
            if (!city.kingdom.isEnemy(actor.kingdom)) continue;
            var danger = computeDanger(city, actor, null);
            if (danger < min_danger)
            {
                safest_city = city;
                min_danger = danger;
            }
        }

        return safest_city;
    }

    [Hotfixable]
    private float computeDanger(City pCity, Actor pActor, City last_city, int depth = 0)
    {
        if (depth >= 3) return 0;
        float danger = pCity.getArmy();

        TileZone nearest_zone = getNearestZone(pCity.borderZones, pActor.currentTile);
        if (nearest_zone == null) return danger;

        danger += Toolbox.DistTile(nearest_zone.centerTile, pActor.currentTile) * 0.1f;

        foreach (TileZone neigh in nearest_zone.neighboursAll)
            if (neigh.city != pCity && neigh.city != last_city && neigh.city != null)
                danger += computeDanger(neigh.city, pActor, pCity, depth + 1);

        return danger;
    }

    private TileZone getNearestZone(IEnumerable<TileZone> zones, WorldTile tile)
    {
        var min_dist = float.MaxValue;
        TileZone nearest_zone = null;
        foreach (TileZone zone in zones)
        {
            var dist = Toolbox.DistTile(zone.centerTile, tile);
            if (dist < min_dist)
            {
                min_dist = dist;
                nearest_zone = zone;
            }
        }

        return nearest_zone;
    }
}