using System.Collections.Generic;
using System.Linq;
using ai.behaviours;

namespace CW_FantasyCreatures.ai.beh;

public class BehGoblinTowerGetRandomZoneTile : BehaviourActionActor
{
    public override bool errorsFound(Actor pObject)
    {
        return base.errorsFound(pObject) || pObject.homeBuilding == null;
    }

    public override BehResult execute(Actor pObject)
    {
        var building = pObject.homeBuilding;
        var zones_list = new List<TileZone>(building.zones);
        zones_list.AddRange(building.zones.SelectMany(x => x.neighboursAll));

        var tile = zones_list.GetRandom().tiles.GetRandom();
        pObject.beh_tile_target = tile;
        return BehResult.Continue;
    }
}