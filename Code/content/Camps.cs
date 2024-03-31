using Cultivation_Way.Abstract;

public class Camps : ExtendedLibrary<KingdomAsset, Camps>
{
    /// <summary>
    /// 血族
    /// </summary>
    public static readonly KingdomAsset vampire;
    /// <summary>
    /// 猎魔人
    /// </summary>
    public static readonly KingdomAsset anti_vampire;
    internal Camps()
    {
        CreateCamp(nameof(vampire));//血族阵营
        t.mobs = true;//nature(完全友善)，mobs(怪物)，mad（疯狂），attack_each_other（互相攻击）
        t.addTag(nameof(vampire));//血族标签
        t.addFriendlyTag(nameof(vampire));//对血族标签友好
        AllEnemyWith(nameof(vampire), SK.civ);  // 所有文明阵营都会主动攻击吸血鬼，civ（公民）

        CreateCamp(nameof(anti_vampire));//猎魔人
        t.addTag(nameof(anti_vampire));
        t.addTag(SK.neutral);//中立
        t.addFriendlyTag(SK.neutral);//对中立标签友好
        t.addEnemyTag(nameof(vampire));//对吸血鬼敌对
    }
    internal void CreateCamp(string pID)
    {
        Add(new KingdomAsset()
        {
            id = pID
        });
    }
    /// <summary>
    /// 为拥有所有<paramref name="pIfHasTags"/>标签的阵营对<paramref name="pTag"/>标签友好
    /// </summary>
    internal void AllFriendWith(string pTag, params string[] pIfHasTags)
    {
        // 等新版本NML出来后再换成ForEach
        foreach (var camp in cached_library.list)
        {
            if (camp.list_tags.IsSupersetOf(pIfHasTags))
            {
                camp.addFriendlyTag(pTag);
            }
        }
    }
    /// <summary>
    /// 为拥有所有<paramref name="pIfHasTags"/>标签的阵营对<paramref name="pTag"/>标签敌对
    /// </summary>
    internal void AllEnemyWith(string pTag, params string[] pIfHasTags)
    {
        // 等新版本NML出来后再换成ForEach
        foreach (var camp in cached_library.list)
        {
            if (camp.list_tags.IsSupersetOf(pIfHasTags))
            {
                camp.addEnemyTag(pTag);
            }
        }
    }
}