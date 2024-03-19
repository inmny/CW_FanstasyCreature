using System.Collections.Generic;
using System.Linq;
using Cultivation_Way.Constants;
using Cultivation_Way.General.AboutUI;
using Cultivation_Way.Library;

namespace CW_FantasyCreatures.content;

internal class Creatures : ExtendedLibrary<CW_ActorAsset>
{
    protected override void Init()
    {
        ActorAsset vanilla_t;
        BaseStats stats;

        #region ------鹿

        // 创建一个生物
        CreateActor("deer", "Deer", "iconDeer", out vanilla_t, out stats);

        t.born_spells.Add("fire_blade"); // 自带火斩法术
        t.prefer_element = new[] { 40, 40, 0, 20, 0 }; // 倾向于雷灵根
        t.prefer_element_scale = 0.9f; // 倾向程度
        t.add_allowed_cultisys("cw_cultisys_immortal"); // 允许修仙
        // 武道: cw_cultisys_bushido
        // 魂道: cw_cultisys_soul
        vanilla_t.disableJumpAnimation = false;//允许跳跃

        vanilla_t.needFood = false; // 不需要食物
        // 其他原版设置见 https://github.com/inmny/Cultivation-Way-Core/blob/base_14/Code/W_Content_Actor.cs 第200行开始，
        // 作用于0.14游戏版本，大体没有发生改变

        stats[S.damage] = 1000; // 伤害
        stats[CW_S.wakan] = 100; // 灵气

        MarkNameTemplate("deer_name"); // 设置命名模板，只在中文名存在时生效

        // 创建这个生物的放置按钮
        CreateButton("deer");

        #endregion

        #region ------半鹿人

        // 创建一个生物
        CreateActor("half_deer_man", "Half Deer Man", "iconHalf_Deer_Man", out vanilla_t, out stats);

        t.born_spells.Add("fire_blade"); // 自带火斩法术
        t.prefer_element = new[] { 40, 40, 0, 20, 0 }; // 倾向于雷灵根
        t.prefer_element_scale = 0.9f; // 倾向程度
        t.add_allowed_cultisys("cw_cultisys_immortal"); // 允许修仙
        // 武道: cw_cultisys_bushido
        // 魂道: cw_cultisys_soul
        vanilla_t.disableJumpAnimation = false;//允许跳跃

        vanilla_t.needFood = false; // 不需要食物
        // 其他原版设置见 https://github.com/inmny/Cultivation-Way-Core/blob/base_14/Code/W_Content_Actor.cs 第200行开始，
        // 作用于0.14游戏版本，大体没有发生改变

        stats[S.damage] = 1000; // 伤害
        stats[CW_S.wakan] = 100; // 灵气

        MarkNameTemplate("deer_name"); // 设置命名模板，只在中文名存在时生效

        // 创建这个生物的放置按钮
        CreateButton("half_deer_man");

        #endregion
        
    }

    /// <summary>
    ///     创建一个生物
    /// </summary>
    /// <param name="pID">生物的ID</param>
    /// <param name="pLocaleKey">生物翻译名的key</param>
    /// <param name="pIconName">生物的图标名</param>
    /// <param name="pActorAsset">返回的生物原版信息</param>
    /// <param name="pStats">返回的生物属性</param>
    private void CreateActor(string pID, string pLocaleKey, string pIconName, out ActorAsset pActorAsset,
        out BaseStats pStats)
    {
        t = Manager.actors.clone(pID, "wolf");
        pActorAsset = t.vanllia_asset;
        pStats = pActorAsset.base_stats;

        t.culti_velo = 1;

        pActorAsset.take_items = false;
        pActorAsset.use_items = true;
        pActorAsset.icon = pIconName;
        pActorAsset.texture_path = "t_" + pID;
        pActorAsset.nameLocale = pLocaleKey;
#if 一米_中文名
        pActorAsset.nameTemplate = "default_name";
#endif
        AssetManager.actor_library.loadShadow(pActorAsset);
    }

    /// <summary>
    ///     为一个生物创建一个放置按钮
    /// </summary>
    /// <param name="pActorID">生物id</param>
    /// <param name="pButtonContainer">按钮容器</param>
    private void CreateButton(string pActorID, ButtonContainerType pButtonContainer = ButtonContainerType.ACTOR)
    {
        FormatButtons.add_actor_button(pActorID, pButtonContainer);
    }

    /// <summary>
    ///     为一列生物创建一个随机放置按钮
    /// </summary>
    /// <param name="pLocaleKey">按钮标题key</param>
    /// <param name="pIconName">按钮图标名</param>
    /// <param name="pButtonContainerType">按钮容器</param>
    /// <param name="pActorIDs">一列生物</param>
    private void CreateButton(string pLocaleKey, string pIconName, ButtonContainerType pButtonContainerType,
        params string[] pActorIDs)
    {
        FormatButtons.add_actors_button(pActorIDs.ToList(), pLocaleKey, pIconName,
            pButtonContainerType);
    }

    /// <summary>
    ///     设置生物随环境变色集
    /// </summary>
    /// <example>
    ///     <code>
    /// AddColorSet(S_SkinColor.mushroom);  // 给生物添加在蘑菇群系的变色
    /// </code>
    /// </example>
    /// <param name="pColorSetID"></param>
    private void AddColorSet(string pColorSetID)
    {
        t.vanllia_asset.useSkinColors = true;
        t.vanllia_asset.color_sets ??= new List<string>();
        t.vanllia_asset.color_sets.Add(pColorSetID);
    }

    /// <summary>
    ///     设置命名模板
    /// </summary>
    /// <param name="pNameTemplateID"></param>
    private void MarkNameTemplate(string pNameTemplateID)
    {
        if (AssetManager.nameGenerator.dict.ContainsKey(pNameTemplateID))
        {
            t.vanllia_asset.nameTemplate = pNameTemplateID;
        }
        else
        {
#if 一米_中文名
            t.vanllia_asset.nameTemplate = pNameTemplateID;
#endif
        }
    }
}