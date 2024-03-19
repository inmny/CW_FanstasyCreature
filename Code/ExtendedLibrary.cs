using System.Collections.Generic;

namespace CW_FantasyCreatures;

internal abstract class BaseExtendedLibrary
{
    public static List<BaseExtendedLibrary> libraries = new();
    protected abstract void Init();

    protected internal virtual void Reload()
    {
        Init();
    }
}

internal abstract class ExtendedLibrary<T> : BaseExtendedLibrary where T : Asset
{
    public List<T> added_assets = new();
    private AssetLibrary<T> cached_library;
    protected T t;

    public ExtendedLibrary()
    {
        Instance = this;
        Init();
        libraries.Add(this);
    }

    public static ExtendedLibrary<T> Instance { get; private set; }

    protected virtual T add(T pObj)
    {
        cached_library ??= (AssetLibrary<T>)AssetManager.instance.list.Find(l => l is AssetLibrary<T>);
        t = pObj;
        added_assets.Add(pObj);
        return cached_library.add(pObj);
    }
}