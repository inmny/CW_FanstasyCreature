using System.Linq;
using ai.behaviours;
using CW_FantasyCreatures.content;

namespace CW_FantasyCreatures.ai.beh;

public class BehGoblinFindTileNearbyShaman : BehaviourActionActor
{
    public override BehResult execute(Actor pObject)
    {
        Building building = pObject.homeBuilding;
        UnitSpawner spawner = building.component_unit_spawner;

        var shamans = spawner.units.Where(x => x.asset.id == nameof(Creatures.goblin_shaman) &&
                                               x.data.hasFlag(ActorDataKeys.goblin_goto_attack_flag)).ToList();

        Actor shaman = shamans.GetRandom();
        var current_path = shamans.GetRandom().current_path;
        WorldTile tile;
        if (current_path != null && current_path.Count > 0)
        {
            tile = current_path[current_path.Count - 1].region.tiles.GetRandom();
        }
        else
        {
            MapRegion mapRegion = shaman.currentTile.region;
            if (mapRegion.tiles.Count < 20 && mapRegion.neighbours.Count > 0)
                mapRegion = mapRegion.neighbours.GetRandom();

            tile = mapRegion.tiles.GetRandom();
        }

        pObject.beh_tile_target = tile;
        return BehResult.Continue;
    }
}