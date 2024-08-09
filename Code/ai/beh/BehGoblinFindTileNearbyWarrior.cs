using System.Linq;
using ai.behaviours;
using CW_FantasyCreatures.content;

namespace CW_FantasyCreatures.ai.beh;

public class BehGoblinFindTileNearbyWarrior : BehaviourActionActor
{
    public override bool errorsFound(Actor pObject)
    {
        return base.errorsFound(pObject) || pObject.homeBuilding == null;
    }

    public override BehResult execute(Actor pObject)
    {
        Building building = pObject.homeBuilding;
        UnitSpawner spawner = building.component_unit_spawner;

        var warriors = spawner.units.Where(x => x.asset.id != nameof(Creatures.goblin_shaman) &&
                                                x.data.hasFlag(ActorDataKeys.goblin_goto_attack_flag)).ToList();
        if (warriors.Count == 0) return BehResult.Stop;
        Actor target_warrior = warriors.GetRandom();
        var current_path = warriors.GetRandom().current_path;
        WorldTile tile;
        if (current_path != null && current_path.Count > 0)
        {
            tile = current_path[current_path.Count - 1].region.tiles.GetRandom();
        }
        else
        {
            MapRegion mapRegion = target_warrior.currentTile.region;
            if (mapRegion.tiles.Count < 20 && mapRegion.neighbours.Count > 0)
                mapRegion = mapRegion.neighbours.GetRandom();

            tile = mapRegion.tiles.GetRandom();
        }

        pObject.beh_tile_target = tile;
        return BehResult.Continue;
    }
}