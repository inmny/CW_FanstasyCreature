using Cultivation_Way;
using Cultivation_Way.Abstract;
using Cultivation_Way.Library;

namespace CW_FantasyCreatures.content;
class Resources : ExtendedLibrary<CW_ResourceAsset, Resources>
{
    public static readonly CW_ResourceAsset silver;
    internal Resources()
    {
        cached_library = Manager.resources;

        CreateResource(nameof(silver));
        vanilla_t.mineral = true;
        vanilla_t.type = ResType.Ingredient;
    }
    protected override CW_ResourceAsset Add(CW_ResourceAsset pObj)
    {
        vanilla_t = pObj.vanilla_asset;
        return base.Add(pObj);
    }
    protected void CreateResource(string pID)
    {
        vanilla_t = new ResourceAsset();
        vanilla_t.id = pID;
        vanilla_t.path_icon = "icon" + pID;
        AssetManager.resources.add(vanilla_t);
        t = cached_library.get(pID);
    }
    protected ResourceAsset vanilla_t;
}