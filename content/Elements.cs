using Cultivation_Way.Constants;
using Cultivation_Way.Library;

namespace CW_FantasyCreatures.content;

internal class Elements : ExtendedLibrary<ElementAsset>
{
    protected override void Init()
    {
        var element = Manager.elements.add_element("cw_lightning", 40, 40, 0, 20, 0, 2f, 5f);
        element.base_stats[S.mod_damage] = 1f;
        element.base_stats[CW_S.mod_cultivelo] = 0.5f;
    }
}