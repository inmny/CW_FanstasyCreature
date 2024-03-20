using Cultivation_Way.Abstract;
using Cultivation_Way.Constants;
using Cultivation_Way.Library;

namespace CW_FantasyCreatures.content;

internal class Elements : ExtendedLibrary<ElementAsset, Elements>
{
    public static readonly ElementAsset cw_lightning;
    internal Elements()
    {
        CreateElement("cw_lightning", 40, 40, 0, 20, 0, 2f, 5f);
        t.base_stats[S.mod_damage] = 1f;
        t.base_stats[CW_S.mod_cultivelo] = 0.5f;
    }
    protected void CreateElement(string pID, int water, int fire, int wood, int iron, int ground, float promot, float rarity)
    {
        Add(new ElementAsset(pID, water, fire, wood, iron, ground, promot, rarity));
    }
}
