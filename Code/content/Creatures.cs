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
                                                        
        #region ------梧桐树人
        // 创建一个生物树人
        CreateActor("sycamore_treants","Sycamore Treants","iconSycamore_Treants",out vanilla_t,out stats);
        t.add_allowed_cultisys("cw_cultisys_immortal"); // 允许仙道
        // 武道: cw_cultisys_bushido
        // 魂道: cw_cultisys_soul
        vanilla_t.animation_walk = "walk_1,walk_2,walk_3,walk_4,walk_5,walk_6,walk_7,walk_8";//移动贴图设置
        vanilla_t.animation_swim = "swim_0,swim_1,swim_2,swim_3,swim_4,swim_5,swim_6,swim_7";//游泳贴图设置
        vanilla_t.disableJumpAnimation = true; //允许跳跃
        vanilla_t.needFood = false; // 不需要食物
        vanilla_t.traits = new(){"wise","attractive","flower_prints","healing_aura"};
        // 其他原版设置见 https://github.com/inmny/Cultivation-Way-Core/blob/base_14/Code/W_Content_Actor.cs 第200行开始，
        // 作用于0.14游戏版本，大体没有发生改变
        stats[S.scale]=0.2f;//大小
        stats[S.speed]=45;//移速
        stats[S.damage] = 1000; // 伤害
        stats[CW_S.wakan] = 100; // 灵气
        MarkNameTemplate("western_name"); // 设置命名模板，只在中文名存在时生效
        // 创建这个生物的放置按钮
        CreateButton("sycamore_treants");
        #endregion
                                                        
        #region ------榕树人
        // 创建一个生物树人
        CreateActor("banyan_treants","Banyan Treants","iconBanyan_Treants",out vanilla_t,out stats);
        t.add_allowed_cultisys("cw_cultisys_immortal"); // 允许仙道
        // 武道: cw_cultisys_bushido
        // 魂道: cw_cultisys_soul
        vanilla_t.animation_walk = "walk_1,walk_2,walk_3,walk_4,walk_5,walk_6,walk_7,walk_8";//移动贴图设置
        vanilla_t.animation_swim = "swim_0,swim_1,swim_2,swim_3,swim_4,swim_5,swim_6,swim_7";//游泳贴图设置
        vanilla_t.disableJumpAnimation = true; //允许跳跃
        vanilla_t.needFood = false; // 不需要食物
        vanilla_t.traits = new(){"wise","attractive","flower_prints","healing_aura"};
        // 其他原版设置见 https://github.com/inmny/Cultivation-Way-Core/blob/base_14/Code/W_Content_Actor.cs 第200行开始，
        // 作用于0.14游戏版本，大体没有发生改变
        stats[S.scale]=0.2f;//大小
        stats[S.speed]=45;//移速
        stats[S.damage] = 1000; // 伤害
        stats[CW_S.wakan] = 100; // 灵气
        MarkNameTemplate("western_name"); // 设置命名模板，只在中文名存在时生效
        // 创建这个生物的放置按钮
        CreateButton("banyan_treants");
        #endregion
                                                        
        #region ------椰树人
        // 创建一个生物树人
        CreateActor("coconut_treants","Coconut Treants","iconCoconut_Treants",out vanilla_t,out stats);
        t.add_allowed_cultisys("cw_cultisys_immortal"); // 允许仙道
        // 武道: cw_cultisys_bushido
        // 魂道: cw_cultisys_soul
        vanilla_t.animation_walk = "walk_1,walk_2,walk_3,walk_4,walk_5,walk_6,walk_7,walk_8";//移动贴图设置
        vanilla_t.animation_swim = "swim_0,swim_1,swim_2,swim_3,swim_4,swim_5,swim_6,swim_7";//游泳贴图设置
        vanilla_t.disableJumpAnimation = true; //允许跳跃
        vanilla_t.needFood = false; // 不需要食物
        vanilla_t.traits = new(){"wise","attractive","flower_prints","healing_aura"};
        // 其他原版设置见 https://github.com/inmny/Cultivation-Way-Core/blob/base_14/Code/W_Content_Actor.cs 第200行开始，
        // 作用于0.14游戏版本，大体没有发生改变
        stats[S.scale]=0.2f;//大小
        stats[S.speed]=45;//移速
        stats[S.damage] = 1000; // 伤害
        stats[CW_S.wakan] = 100; // 灵气
        MarkNameTemplate("western_name"); // 设置命名模板，只在中文名存在时生效
        // 创建这个生物的放置按钮
        CreateButton("coconut_treants");
        #endregion
                                                        
        #region ------桉树人
        // 创建一个生物树人
        CreateActor("acacia_treants","Acacia Treants","iconAcacia_Treants",out vanilla_t,out stats);
        t.add_allowed_cultisys("cw_cultisys_immortal"); // 允许仙道
        // 武道: cw_cultisys_bushido
        // 魂道: cw_cultisys_soul
        vanilla_t.animation_walk = "walk_1,walk_2,walk_3,walk_4,walk_5,walk_6,walk_7,walk_8";//移动贴图设置
        vanilla_t.animation_swim = "swim_0,swim_1,swim_2,swim_3,swim_4,swim_5,swim_6,swim_7";//游泳贴图设置
        vanilla_t.disableJumpAnimation = true; //允许跳跃
        vanilla_t.needFood = false; // 不需要食物
        vanilla_t.traits = new(){"wise","attractive","flower_prints","healing_aura"};
        // 其他原版设置见 https://github.com/inmny/Cultivation-Way-Core/blob/base_14/Code/W_Content_Actor.cs 第200行开始，
        // 作用于0.14游戏版本，大体没有发生改变
        stats[S.scale]=0.2f;//大小
        stats[S.damage] = 1000; // 伤害
        stats[CW_S.wakan] = 100; // 灵气
        MarkNameTemplate("western_name"); // 设置命名模板，只在中文名存在时生效
        // 创建这个生物的放置按钮
        CreateButton("acacia_treants");
        #endregion
                                                                
        #region ------橡树人
        // 创建一个生物树人
        CreateActor("oak_treants","Oak Treants","iconOak_Treants",out vanilla_t,out stats);
        t.add_allowed_cultisys("cw_cultisys_immortal"); // 允许仙道
        // 武道: cw_cultisys_bushido
        // 魂道: cw_cultisys_soul
        vanilla_t.animation_walk = "walk_1,walk_2,walk_3,walk_4,walk_5,walk_6,walk_7,walk_8";//移动贴图设置
        vanilla_t.animation_swim = "swim_0,swim_1,swim_2,swim_3,swim_4,swim_5,swim_6,swim_7";//游泳贴图设置
        vanilla_t.disableJumpAnimation = true; //允许跳跃
        vanilla_t.needFood = false; // 不需要食物
        vanilla_t.traits = new(){"wise","attractive","flower_prints","healing_aura"};
        // 其他原版设置见 https://github.com/inmny/Cultivation-Way-Core/blob/base_14/Code/W_Content_Actor.cs 第200行开始，
        // 作用于0.14游戏版本，大体没有发生改变
        stats[S.scale]=0.2f;//大小
        stats[S.speed]=45;//移速
        stats[S.damage] = 1000; // 伤害
        stats[CW_S.wakan] = 100; // 灵气
        MarkNameTemplate("western_name"); // 设置命名模板，只在中文名存在时生效
        // 创建这个生物的放置按钮
        CreateButton("oak_treants");
        #endregion

        #region ------九尾狐
        // 创建一个生物
        CreateActor("fairy_fox", "Fairy Fox", "iconFairy_Fox", out vanilla_t, out stats);
        t.add_allowed_cultisys("cw_cultisys_immortal"); // 允许修仙
        t.force_cultisys_initial_level("cw_cultisys_immortal", 1); // 强制初始仙路等级为筑基
        // 武道: cw_cultisys_bushido
        // 魂道: cw_cultisys_soul
        vanilla_t.animation_walk = "walk_1,walk_2";//移动贴图设置
        vanilla_t.animation_swim = "swim_0,swim_1,swim_2";//游泳贴图设置
        vanilla_t.disableJumpAnimation = false; //允许跳跃
        vanilla_t.needFood = false; // 不需要食物
        // 其他原版设置见 https://github.com/inmny/Cultivation-Way-Core/blob/base_14/Code/W_Content_Actor.cs 第200行开始，
        // 作用于0.14游戏版本，大体没有发生改变
        stats[S.damage] = 1000; // 伤害
        stats[CW_S.wakan] = 100; // 灵气
        MarkNameTemplate("fairy_fox_name"); // 设置命名模板，只在中文名存在时生效
        // 创建这个生物的放置按钮
        CreateButton("fairy_fox");
        #endregion

        #region ------九色神鹿
        // 创建一个生物
        CreateActor("nine_colored_deer", "Nine Colored Deer", "iconNine_Colored_Deer", out vanilla_t, out stats);
        t.add_allowed_cultisys("cw_cultisys_immortal"); // 允许修仙
        t.force_cultisys_initial_level("cw_cultisys_immortal", 1); // 强制初始仙路等级为筑基
        // 武道: cw_cultisys_bushido
        // 魂道: cw_cultisys_soul
        vanilla_t.animation_walk = "walk_1,walk_2";//移动贴图设置
        vanilla_t.animation_swim = "swim_0,swim_1";//游泳贴图设置
        vanilla_t.disableJumpAnimation = false; //允许跳跃
        vanilla_t.needFood = false; // 不需要食物
        // 其他原版设置见 https://github.com/inmny/Cultivation-Way-Core/blob/base_14/Code/W_Content_Actor.cs 第200行开始，
        // 作用于0.14游戏版本，大体没有发生改变
        stats[S.damage] = 1000; // 伤害
        stats[CW_S.wakan] = 100; // 灵气
        MarkNameTemplate("nine_colored_deer_name"); // 设置命名模板，只在中文名存在时生效
        // 创建这个生物的放置按钮
        CreateButton("nine_colored_deer");
        #endregion

        #region ------狮子
        // 创建一个生物
        CreateActor("lion", "Lion", "iconLion", out vanilla_t, out stats);
        t.add_allowed_cultisys("cw_cultisys_immortal"); // 允许修仙
        // 武道: cw_cultisys_bushido
        // 魂道: cw_cultisys_soul
        vanilla_t.animation_walk = "walk_1,walk_2";//移动贴图设置
        vanilla_t.animation_swim = "swim_0,swim_1,swim_2";//游泳贴图设置
        vanilla_t.disableJumpAnimation = false; //允许跳跃
        vanilla_t.needFood = false; // 不需要食物
        // 其他原版设置见 https://github.com/inmny/Cultivation-Way-Core/blob/base_14/Code/W_Content_Actor.cs 第200行开始，
        // 作用于0.14游戏版本，大体没有发生改变
        stats[S.damage] = 1000; // 伤害
        stats[CW_S.wakan] = 100; // 灵气
        MarkNameTemplate("lion_name"); // 设置命名模板，只在中文名存在时生效
        // 创建这个生物的放置按钮
        CreateButton("lion");
        #endregion

        #region ------家猪
        // 创建一个生物
        CreateActor("pig", "Pig", "iconPig", out vanilla_t, out stats);
        t.add_allowed_cultisys("cw_cultisys_immortal"); // 允许修仙
        // 武道: cw_cultisys_bushido
        // 魂道: cw_cultisys_soul
        vanilla_t.animation_walk = "walk_1,walk_2";//移动贴图设置
        vanilla_t.animation_swim = "swim_0,swim_1,swim_2";//游泳贴图设置
        vanilla_t.disableJumpAnimation = false; //允许跳跃
        vanilla_t.needFood = false; // 不需要食物
        // 其他原版设置见 https://github.com/inmny/Cultivation-Way-Core/blob/base_14/Code/W_Content_Actor.cs 第200行开始，
        // 作用于0.14游戏版本，大体没有发生改变
        stats[S.damage] = 1000; // 伤害
        stats[CW_S.wakan] = 100; // 灵气
        MarkNameTemplate("pig_name"); // 设置命名模板，只在中文名存在时生效
        // 创建这个生物的放置按钮
        CreateButton("pig");
        #endregion

        #region ------野猪
        // 创建一个生物
        CreateActor("wild_boar", "Wild Boar", "iconWild_Boar", out vanilla_t, out stats);
        t.prefer_element = new[] { 25, 20, 10, 15, 30 }; // 倾向于地灵根
        t.prefer_element_scale = 1f; // 倾向程度
        t.add_allowed_cultisys("cw_cultisys_immortal"); // 允许修仙
        // 武道: cw_cultisys_bushido
        // 魂道: cw_cultisys_soul
        vanilla_t.animation_walk = "walk_1,walk_2";//移动贴图设置
        vanilla_t.animation_swim = "swim_0,swim_1,swim_2";//游泳贴图设置
        vanilla_t.disableJumpAnimation = false; //允许跳跃
        vanilla_t.needFood = false; // 不需要食物
        // 其他原版设置见 https://github.com/inmny/Cultivation-Way-Core/blob/base_14/Code/W_Content_Actor.cs 第200行开始，
        // 作用于0.14游戏版本，大体没有发生改变
        stats[S.damage] = 1000; // 伤害
        stats[CW_S.wakan] = 100; // 灵气
        MarkNameTemplate("pig_name"); // 设置命名模板，只在中文名存在时生效
        // 创建这个生物的放置按钮
        CreateButton("wild_boar");
        #endregion


        #region ------公鸡
        // 创建一个生物
        CreateActor("rooster", "Rooster", "iconRooster", out vanilla_t, out stats);
        t.add_allowed_cultisys("cw_cultisys_immortal"); // 允许修仙
        // 武道: cw_cultisys_bushido
        // 魂道: cw_cultisys_soul
        vanilla_t.animation_walk = "walk_1,walk_2";//移动贴图设置
        vanilla_t.animation_swim = "swim_0,swim_1,swim_2";//游泳贴图设置
        vanilla_t.disableJumpAnimation = false; //允许跳跃
        vanilla_t.needFood = false; // 不需要食物
        // 其他原版设置见 https://github.com/inmny/Cultivation-Way-Core/blob/base_14/Code/W_Content_Actor.cs 第200行开始，
        // 作用于0.14游戏版本，大体没有发生改变
        stats[S.damage] = 1000; // 伤害
        stats[CW_S.wakan] = 100; // 灵气
        MarkNameTemplate("rooster_name"); // 设置命名模板，只在中文名存在时生效
        // 创建这个生物的放置按钮
        CreateButton("rooster");
        #endregion

        #region ------老虎
        // 创建一个生物
        CreateActor("tiger", "Tiger", "iconTiger", out vanilla_t, out stats);
        t.prefer_element = new[] { 20, 20, 40, 10, 10 }; // 倾向于风灵根
        t.prefer_element_scale = 1f; // 倾向程度
        t.add_allowed_cultisys("cw_cultisys_immortal"); // 允许修仙
        // 武道: cw_cultisys_bushido
        // 魂道: cw_cultisys_soul
        vanilla_t.animation_walk = "walk_1,walk_2";//移动贴图设置
        vanilla_t.animation_swim = "swim_0,swim_1,swim_2";//游泳贴图设置
        vanilla_t.disableJumpAnimation = false; //允许跳跃
        vanilla_t.needFood = false; // 不需要食物
        // 其他原版设置见 https://github.com/inmny/Cultivation-Way-Core/blob/base_14/Code/W_Content_Actor.cs 第200行开始，
        // 作用于0.14游戏版本，大体没有发生改变
        stats[S.damage] = 1000; // 伤害
        stats[CW_S.wakan] = 100; // 灵气
        MarkNameTemplate("tiger_name"); // 设置命名模板，只在中文名存在时生效
        // 创建这个生物的放置按钮
        CreateButton("tiger");
        #endregion

        #region ------熊猫
        // 创建一个生物
        CreateActor("panda", "Panda", "iconPanda", out vanilla_t, out stats);
        t.prefer_element = new[] { 30, 10, 30, 10, 20 }; // 倾向于草灵根
        t.prefer_element_scale = 1f; // 倾向程度
        t.add_allowed_cultisys("cw_cultisys_immortal"); // 允许修仙
        // 武道: cw_cultisys_bushido
        // 魂道: cw_cultisys_soul
        vanilla_t.animation_walk = "walk_1,walk_2";//移动贴图设置
        vanilla_t.animation_swim = "swim_0,swim_1,swim_2";//游泳贴图设置
        vanilla_t.disableJumpAnimation = true; //允许跳跃
        vanilla_t.needFood = false; // 不需要食物
        // 其他原版设置见 https://github.com/inmny/Cultivation-Way-Core/blob/base_14/Code/W_Content_Actor.cs 第200行开始，
        // 作用于0.14游戏版本，大体没有发生改变
        stats[S.damage] = 1000; // 伤害
        stats[S.speed]=40;//移速
        stats[CW_S.wakan] = 100; // 灵气
        MarkNameTemplate("panda_name"); // 设置命名模板，只在中文名存在时生效
        // 创建这个生物的放置按钮
        CreateButton("panda");
        #endregion

        #region ------鹿
        // 创建一个生物
        CreateActor("deer", "Deer", "iconDeer", out vanilla_t, out stats);
        t.add_allowed_cultisys("cw_cultisys_immortal"); // 允许修仙
        // 武道: cw_cultisys_bushido
        // 魂道: cw_cultisys_soul
        vanilla_t.animation_walk = "walk_1,walk_2,walk_3";//移动贴图设置
        vanilla_t.animation_swim = "swim_0,swim_1,swim_2,swim_3";//游泳贴图设置
        vanilla_t.disableJumpAnimation = false; //允许跳跃
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
        CreateActor("half_deer_man","Half Deer Man","iconHalf_Deer_Man",out vanilla_t,out stats);
        t.add_allowed_cultisys("cw_cultisys_immortal"); // 允许修仙
        // 武道: cw_cultisys_bushido
        // 魂道: cw_cultisys_soul
        vanilla_t.animation_walk = "walk_1,walk_2,walk_3";//移动贴图设置
        vanilla_t.animation_swim = "swim_0,swim_1,swim_2,swim_3";//游泳贴图设置
        vanilla_t.disableJumpAnimation = false; //允许跳跃
        vanilla_t.needFood = false; // 不需要食物
        vanilla_t.defaultWeapons = List.Of<string>(new string[] {"bow"});//添加弓
        vanilla_t.defaultWeaponsMaterial = List.Of<string>(new string[] {"wood"});//木
        // 其他原版设置见 https://github.com/inmny/Cultivation-Way-Core/blob/base_14/Code/W_Content_Actor.cs 第200行开始，
        // 作用于0.14游戏版本，大体没有发生改变
        stats[S.damage] = 1000; // 伤害
        stats[CW_S.wakan] = 100; // 灵气
        MarkNameTemplate("western_name"); // 设置命名模板，只在中文名存在时生效
        // 创建这个生物的放置按钮
        CreateButton("half_deer_man");
        #endregion

        #region ------马
        // 创建一个生物
        CreateActor("horse", "Horse", "iconHorse", out vanilla_t, out stats);
        t.add_allowed_cultisys("cw_cultisys_immortal"); // 允许修仙
        // 武道: cw_cultisys_bushido
        // 魂道: cw_cultisys_soul
        vanilla_t.animation_walk = "walk_1,walk_2,walk_3";//移动贴图设置
        vanilla_t.animation_swim = "swim_0,swim_1,swim_2,swim_3";//游泳贴图设置
        vanilla_t.disableJumpAnimation = false; //允许跳跃
        vanilla_t.needFood = false; // 不需要食物
        // 其他原版设置见 https://github.com/inmny/Cultivation-Way-Core/blob/base_14/Code/W_Content_Actor.cs 第200行开始，
        // 作用于0.14游戏版本，大体没有发生改变
        stats[S.damage] = 1000; // 伤害
        stats[CW_S.wakan] = 100; // 灵气
        MarkNameTemplate("horse_name"); // 设置命名模板，只在中文名存在时生效
        // 创建这个生物的放置按钮
        CreateButton("horse");
        #endregion

        #region ------半人马
        // 创建一个生物半人马
        CreateActor("centaur","Centaur","iconCentaur",out vanilla_t,out stats);
        t.add_allowed_cultisys("cw_cultisys_immortal"); // 允许修仙
        // 武道: cw_cultisys_bushido
        // 魂道: cw_cultisys_soul
        vanilla_t.animation_walk = "walk_1,walk_2,walk_3,walk_4";//移动贴图设置
        vanilla_t.animation_swim = "swim_0,swim_1,swim_2,swim_3";//游泳贴图设置
        vanilla_t.disableJumpAnimation = false; //允许跳跃
        vanilla_t.needFood = false; // 不需要食物
        vanilla_t.defaultWeapons = List.Of<string>(new string[] {"spear"});//添加矛
        vanilla_t.defaultWeaponsMaterial = List.Of<string>(new string[] {"stone"});//石头
        // 其他原版设置见 https://github.com/inmny/Cultivation-Way-Core/blob/base_14/Code/W_Content_Actor.cs 第200行开始，
        // 作用于0.14游戏版本，大体没有发生改变
        stats[S.damage] = 1000; // 伤害
        stats[CW_S.wakan] = 100; // 灵气
        MarkNameTemplate("western_name"); // 设置命名模板，只在中文名存在时生效
        // 创建这个生物的放置按钮
        CreateButton("centaur");
        #endregion
        
        #region ------阿努比斯
        // 创建一个生物阿努比斯
        CreateActor("anubis","Anubis","iconAnubis",out vanilla_t,out stats);
        t.prefer_element = new[] { 40, 5, 10, 5, 40 }; // 倾向于暗灵根
        t.prefer_element_scale = 1f; // 倾向程度
        t.add_allowed_cultisys("cw_cultisys_immortal"); // 允许修仙
        // 武道: cw_cultisys_bushido
        // 魂道: cw_cultisys_soul
        vanilla_t.animation_walk = "walk_0,walk_1,walk_2,walk_3,walk_4,walk_5,walk_6,walk_7";//移动贴图设置
        vanilla_t.animation_swim = "swim_0,swim_1,swim_2,swim_3,swim_4,swim_5,swim_6,swim_7";//游泳贴图设置
        vanilla_t.disableJumpAnimation = true; //允许跳跃
        vanilla_t.needFood = false; // 不需要食物
        vanilla_t.defaultWeapons = List.Of<string>(new string[] {"evil_staff"});//添加邪恶法杖
        // 其他原版设置见 https://github.com/inmny/Cultivation-Way-Core/blob/base_14/Code/W_Content_Actor.cs 第200行开始，
        // 作用于0.14游戏版本，大体没有发生改变
        stats[S.scale]=0.2f;//大小
        stats[S.damage] = 1000; // 伤害
        stats[CW_S.wakan] = 100; // 灵气
        MarkNameTemplate("anubis_name"); // 设置命名模板，只在中文名存在时生效
        // 创建这个生物的放置按钮
        CreateButton("anubis");
        #endregion
                  
        #region ------骨龙
        // 创建一个生物骨龙
        CreateActor("ossaurus","Ossaurus","iconOssaurus",out vanilla_t,out stats);
        t.add_allowed_cultisys("cw_cultisys_immortal"); // 允许修仙
        // 武道: cw_cultisys_bushido
        // 魂道: cw_cultisys_soul
        vanilla_t.animation_walk = "walk_1,walk_2,walk_3,walk_4,walk_5,walk_6";//移动贴图设置
        vanilla_t.animation_swim = "swim_0,swim_1,swim_2,swim_3,swim_4,swim_5";//游泳贴图设置
        vanilla_t.disableJumpAnimation = true; //允许跳跃
        vanilla_t.needFood = false; // 不需要食物
        // 其他原版设置见 https://github.com/inmny/Cultivation-Way-Core/blob/base_14/Code/W_Content_Actor.cs 第200行开始，
        // 作用于0.14游戏版本，大体没有发生改变
        stats[S.scale]=0.3f;//大小
        stats[S.damage] = 1000; // 伤害
        stats[CW_S.wakan] = 100; // 灵气
        MarkNameTemplate("western_name"); // 设置命名模板，只在中文名存在时生效
        // 创建这个生物的放置按钮
        CreateButton("ossaurus");
        #endregion
                                        
        #region ------法老
        // 创建一个生物法老
        CreateActor("pharaoh","Pharaoh","iconPharaoh",out vanilla_t,out stats);
        t.add_allowed_cultisys("cw_cultisys_soul"); // 允许魂道
        // 武道: cw_cultisys_bushido
        // 魂道: cw_cultisys_soul
        vanilla_t.animation_walk = "walk_0,walk_1,walk_2,walk_3,walk_4,walk_5,walk_6,walk_7";//移动贴图设置
        vanilla_t.animation_swim = "swim_0,swim_1,swim_2,swim_3,swim_4,swim_5,swim_6,swim_7";//游泳贴图设置
        vanilla_t.disableJumpAnimation = true; //允许跳跃
        vanilla_t.needFood = false; // 不需要食物
        vanilla_t.defaultWeapons = List.Of<string>(new string[] {"necromancer_staff"});//添加亡灵法杖
        // 其他原版设置见 https://github.com/inmny/Cultivation-Way-Core/blob/base_14/Code/W_Content_Actor.cs 第200行开始，
        // 作用于0.14游戏版本，大体没有发生改变
        stats[S.scale]=0.2f;//大小
        stats[S.damage] = 1000; // 伤害
        stats[CW_S.wakan] = 100; // 灵气
        MarkNameTemplate("pharaoh_name"); // 设置命名模板，只在中文名存在时生效
        // 创建这个生物的放置按钮
        CreateButton("pharaoh");
        #endregion
                                                
        #region ------骷髅骑士
        // 创建一个生物骷髅骑士
        CreateActor("skeleton_knight","Skeleton Knight","iconSkeleton_Knight",out vanilla_t,out stats);
        t.add_allowed_cultisys("cw_cultisys_soul"); // 允许魂道
        // 武道: cw_cultisys_bushido
        // 魂道: cw_cultisys_soul
        vanilla_t.animation_walk = "walk_1,walk_2,walk_3";//移动贴图设置
        vanilla_t.animation_swim = "swim_0,swim_1,swim_2,swim_3";//游泳贴图设置
        vanilla_t.disableJumpAnimation = false; //允许跳跃
        vanilla_t.needFood = false; // 不需要食物
        // 其他原版设置见 https://github.com/inmny/Cultivation-Way-Core/blob/base_14/Code/W_Content_Actor.cs 第200行开始，
        // 作用于0.14游戏版本，大体没有发生改变
        stats[S.damage] = 1000; // 伤害
        stats[CW_S.wakan] = 100; // 灵气
        MarkNameTemplate("skeleton_knight_name"); // 设置命名模板，只在中文名存在时生效
        // 创建这个生物的放置按钮
        CreateButton("skeleton_knight");
        #endregion
                                                                
        #region ------斯芬克斯
        // 创建一个生物斯芬克斯
        CreateActor("sphinx","Sphinx","iconSphinx",out vanilla_t,out stats);
        t.prefer_element = new[] { 25, 20, 10, 15, 30 }; // 倾向于地灵根
        t.prefer_element_scale = 1f; // 倾向程度
        t.add_allowed_cultisys("cw_cultisys_immortal"); // 允许修仙
        // 武道: cw_cultisys_bushido
        // 魂道: cw_cultisys_soul
        vanilla_t.animation_walk = "walk_0,walk_1,walk_2,walk_3";//移动贴图设置
        vanilla_t.animation_swim = "swim_0,swim_1,swim_2,swim_3";//游泳贴图设置
        vanilla_t.disableJumpAnimation = true; //允许跳跃
        vanilla_t.needFood = false; // 不需要食物
        // 其他原版设置见 https://github.com/inmny/Cultivation-Way-Core/blob/base_14/Code/W_Content_Actor.cs 第200行开始，
        // 作用于0.14游戏版本，大体没有发生改变
        stats[S.scale]=0.2f;//大小
        stats[S.damage] = 1000; // 伤害
        stats[CW_S.wakan] = 100; // 灵气
        MarkNameTemplate("sphinx_name"); // 设置命名模板，只在中文名存在时生效
        // 创建这个生物的放置按钮
        CreateButton("sphinx");
        #endregion

        #region ------吸血鬼
        // 创建一个生物吸血鬼
        CreateActor("bloodsucker","Bloodsucker","iconBloodsucker",out vanilla_t,out stats);
        t.prefer_element = new[] { 40, 10, 40, 5, 5 }; // 倾向于血灵根
        t.prefer_element_scale = 1f; // 倾向程度
        t.add_allowed_cultisys("cw_cultisys_immortal"); // 允许修仙

        // 武道: cw_cultisys_bushido
        // 魂道: cw_cultisys_soul
        vanilla_t.animation_walk = "walk_1,walk_2,walk_3";//移动贴图设置
        vanilla_t.animation_swim = "swim_0,swim_1,swim_2,swim_3";//游泳贴图设置
        vanilla_t.disableJumpAnimation = false; //允许跳跃
        vanilla_t.needFood = false; // 不需要食物
        vanilla_t.kingdom = Camps.vampire.id;
        // 其他原版设置见 https://github.com/inmny/Cultivation-Way-Core/blob/base_14/Code/W_Content_Actor.cs 第200行开始，
        // 作用于0.14游戏版本，大体没有发生改变
        stats[S.damage] = 1000; // 伤害
        stats[CW_S.wakan] = 100; // 灵气
        MarkNameTemplate("bloodsucker_name"); // 设置命名模板，只在中文名存在时生效
        // 创建这个生物的放置按钮
        CreateButton("bloodsucker");
        #endregion

        #region ------吸血鬼猎人
        // 创建一个生物吸血鬼猎人
        CreateActor("vampire_hunter","Vampire Hunter","iconVampire_Hunter",out vanilla_t,out stats);
        t.add_allowed_cultisys("cw_cultisys_immortal"); // 允许修仙
        t.add_allowed_cultisys("cw_cultisys_bushido"); // 允许武道
        // 武道: cw_cultisys_bushido
        // 魂道: cw_cultisys_soul
        vanilla_t.animation_walk = "walk_1,walk_2,walk_3";//移动贴图设置
        vanilla_t.animation_swim = "swim_0,swim_1,swim_2,swim_3";//游泳贴图设置
        vanilla_t.disableJumpAnimation = true; //允许跳跃
        vanilla_t.needFood = false; // 不需要食物
        vanilla_t.defaultWeapons = List.Of<string>(new string[] {"shotgun"});//添加霰弹
        vanilla_t.kingdom = Camps.anti_vampire.id;
        // 其他原版设置见 https://github.com/inmny/Cultivation-Way-Core/blob/base_14/Code/W_Content_Actor.cs 第200行开始，
        // 作用于0.14游戏版本，大体没有发生改变
        stats[S.damage] = 1000; // 伤害
        stats[CW_S.wakan] = 100; // 灵气
        MarkNameTemplate("western_name"); // 设置命名模板，只在中文名存在时生效
        // 创建这个生物的放置按钮
        CreateButton("vampire_hunter");
        #endregion

        #region ------知识之灵
        // 创建一个生物知识之灵
        CreateActor("knowledge_genie","Knowledge Genie","iconKnowledge_Genie",out vanilla_t,out stats);
        t.add_allowed_cultisys("cw_cultisys_immortal"); // 允许修仙
        // 武道: cw_cultisys_bushido
        // 魂道: cw_cultisys_soul
        vanilla_t.animation_walk = "walk_0,walk_1,walk_2,walk_3";//移动贴图设置
        vanilla_t.animation_swim = "swim_0,swim_1,swim_2,swim_3";//游泳贴图设置
        vanilla_t.disableJumpAnimation = false; //允许跳跃
        vanilla_t.needFood = false; // 不需要食物
        // 其他原版设置见 https://github.com/inmny/Cultivation-Way-Core/blob/base_14/Code/W_Content_Actor.cs 第200行开始，
        // 作用于0.14游戏版本，大体没有发生改变
        stats[S.damage] = 1000; // 伤害
        stats[CW_S.wakan] = 100; // 灵气
        MarkNameTemplate("western_name"); // 设置命名模板，只在中文名存在时生效
        // 创建这个生物的放置按钮
        CreateButton("knowledge_genie");
        #endregion

        #region ------狼人
        // 创建一个生物狼人
        CreateActor("werewolf","Werewolf","iconWerewolf",out vanilla_t,out stats);
        t.add_allowed_cultisys("cw_cultisys_bushido"); // 允许武道
        // 武道: cw_cultisys_bushido
        // 魂道: cw_cultisys_soul
        vanilla_t.animation_walk = "walk_1,walk_2,walk_3";//移动贴图设置
        vanilla_t.animation_swim = "swim_0,swim_1,swim_2,swim_3";//游泳贴图设置
        vanilla_t.disableJumpAnimation = true; //允许跳跃
        vanilla_t.needFood = false; // 不需要食物
        // 其他原版设置见 https://github.com/inmny/Cultivation-Way-Core/blob/base_14/Code/W_Content_Actor.cs 第200行开始，
        // 作用于0.14游戏版本，大体没有发生改变
        stats[S.damage] = 1000; // 伤害
        stats[CW_S.wakan] = 100; // 灵气
        MarkNameTemplate("western_name"); // 设置命名模板，只在中文名存在时生效
        // 创建这个生物的放置按钮
        CreateButton("werewolf");
        #endregion
        
        #region ------凤凰
        // 创建一个生物凤凰
        CreateActor("feng_huang","Feng Huang","iconFeng_Huang",out vanilla_t,out stats);
        t.add_allowed_cultisys("cw_cultisys_immortal"); // 允许修仙
        t.force_cultisys_initial_level("cw_cultisys_immortal", 10); // 强制初始仙路等级为地仙
        // 武道: cw_cultisys_bushido
        // 魂道: cw_cultisys_soul
        vanilla_t.animation_walk = "walk_1,walk_2";//移动贴图设置
        vanilla_t.animation_swim = "swim_1,swim_2";//游泳贴图设置
        vanilla_t.disableJumpAnimation = true; //允许跳跃
        vanilla_t.needFood = false; // 不需要食物
        vanilla_t.kingdom = Camps.Divine.id;//
        // 其他原版设置见 https://github.com/inmny/Cultivation-Way-Core/blob/base_14/Code/W_Content_Actor.cs 第200行开始，
        // 作用于0.14游戏版本，大体没有发生改变
        stats[S.scale]=0.2f;//大小
        stats[S.damage] = 1000; // 伤害
        stats[CW_S.wakan] = 100; // 灵气
        MarkNameTemplate("feng_huang_name"); // 设置命名模板，只在中文名存在时生效
        // 创建这个生物的放置按钮
        CreateButton("feng_huang");
        #endregion

        #region ------朱雀
        // 创建一个生物朱雀
        CreateActor("suzaku","Suzaku","iconSuzaku",out vanilla_t,out stats);
        t.prefer_element = new[] { 5, 80, 5, 5, 5 }; // 倾向于火灵根
        t.prefer_element_scale = 1f; // 倾向程度
        t.add_allowed_cultisys("cw_cultisys_immortal"); // 允许修仙
        t.born_spells.Add("fire_blade");//添加火斩
        t.force_cultisys_initial_level("cw_cultisys_immortal", 2); // 强制初始仙路等级为金丹
        // 武道: cw_cultisys_bushido
        // 魂道: cw_cultisys_soul
        vanilla_t.animation_walk = "walk_1,walk_2";//移动贴图设置
        vanilla_t.animation_swim = "swim_1,swim_2";//移动贴图设置
        vanilla_t.disableJumpAnimation = true; //允许跳跃
        vanilla_t.needFood = false; // 不需要食物
        vanilla_t.kingdom = Camps.Divine.id;//
        vanilla_t.traits = new(){"fire_blood","fire_proof","burning_feet"};
        // 其他原版设置见 https://github.com/inmny/Cultivation-Way-Core/blob/base_14/Code/W_Content_Actor.cs 第200行开始，
        // 作用于0.14游戏版本，大体没有发生改变
        stats[S.scale]=0.2f;//大小
        stats[S.damage] = 1000; // 伤害
        stats[CW_S.wakan] = 100; // 灵气
        MarkNameTemplate("suzaku_name"); // 设置命名模板，只在中文名存在时生效
        // 创建这个生物的放置按钮
        CreateButton("suzaku");
        #endregion

        #region ------麒麟
        // 创建一个生物麒麟
        CreateActor("qilin","Qilin","iconQilin",out vanilla_t,out stats);
        t.prefer_element = new[] { 5, 5, 5, 5, 80 }; // 倾向于土灵根
        t.prefer_element_scale = 1f; // 倾向程度
        t.add_allowed_cultisys("cw_cultisys_immortal"); // 允许修仙
        t.force_cultisys_initial_level("cw_cultisys_immortal", 2); // 强制初始仙路等级为金丹
        // 武道: cw_cultisys_bushido
        // 魂道: cw_cultisys_soul
        vanilla_t.animation_walk = "walk_1,walk_2";//移动贴图设置
        vanilla_t.animation_swim = "swim_0,swim_1,swim_2";//游泳贴图设置
        vanilla_t.disableJumpAnimation = false; //允许跳跃
        vanilla_t.needFood = false; // 不需要食物
        vanilla_t.kingdom = Camps.Divine.id;
        vanilla_t.traits = new(){"agile","pacifist","strong","shiny"};
        // 其他原版设置见 https://github.com/inmny/Cultivation-Way-Core/blob/base_14/Code/W_Content_Actor.cs 第200行开始，
        // 作用于0.14游戏版本，大体没有发生改变
        stats[S.scale]=0.2f;//大小
        stats[S.damage] = 1000; // 伤害
        stats[CW_S.wakan] = 100; // 灵气
        MarkNameTemplate("qilin_name"); // 设置命名模板，只在中文名存在时生效
        // 创建这个生物的放置按钮
        CreateButton("qilin");
        #endregion

        #region ------白虎
        // 创建一个生物白虎
        CreateActor("white_tiger","White Tiger","iconWhite_Tiger",out vanilla_t,out stats);
        t.prefer_element = new[] { 5, 5, 5, 80, 5 }; // 倾向于金灵根
        t.prefer_element_scale = 1f; // 倾向程度
        t.add_allowed_cultisys("cw_cultisys_immortal"); // 允许修仙
        t.force_cultisys_initial_level("cw_cultisys_immortal", 2); // 强制初始仙路等级为金丹
        // 武道: cw_cultisys_bushido
        // 魂道: cw_cultisys_soul
        vanilla_t.animation_walk = "walk_1,walk_2";//移动贴图设置
        vanilla_t.animation_swim = "swim_0,swim_1,swim_2";//游泳贴图设置
        vanilla_t.disableJumpAnimation = false; //允许跳跃
        vanilla_t.needFood = false; // 不需要食物
        vanilla_t.kingdom = Camps.Divine.id;
        vanilla_t.traits = new(){"bloodlust","fast","strong",nameof(Traits.huge_light)};
        // 其他原版设置见 https://github.com/inmny/Cultivation-Way-Core/blob/base_14/Code/W_Content_Actor.cs 第200行开始，
        // 作用于0.14游戏版本，大体没有发生改变
        stats[S.scale]=0.2f;//大小
        stats[S.damage] = 1000; // 伤害
        stats[CW_S.wakan] = 100; // 灵气
        MarkNameTemplate("white_tiger_name"); // 设置命名模板，只在中文名存在时生效
        // 创建这个生物的放置按钮
        CreateButton("white_tiger");
        #endregion
                                                                                                        
        #region ------玄武
        // 创建一个生物玄武
        CreateActor("xuanwu","Xuanwu","iconXuanwu",out vanilla_t,out stats);
        t.prefer_element = new[] { 80, 5, 5, 5, 5 }; // 倾向于水灵根
        t.prefer_element_scale = 1f; // 倾向程度
        t.add_allowed_cultisys("cw_cultisys_immortal"); // 允许修仙
        t.force_cultisys_initial_level("cw_cultisys_immortal", 2); // 强制初始仙路等级为金丹
        // 武道: cw_cultisys_bushido
        // 魂道: cw_cultisys_soul
        vanilla_t.animation_walk = "walk_0,walk_1,walk_2,walk_3";//移动贴图设置
        vanilla_t.animation_swim = "swim_0,swim_1,swim_2,swim_3";//游泳贴图设置
        vanilla_t.disableJumpAnimation = true; //允许跳跃
        vanilla_t.needFood = false; // 不需要食物
        vanilla_t.kingdom = Camps.Divine.id;
        vanilla_t.traits = new(){"tough","freeze_proof","cold_aura"};
        // 其他原版设置见 https://github.com/inmny/Cultivation-Way-Core/blob/base_14/Code/W_Content_Actor.cs 第200行开始，
        // 作用于0.14游戏版本，大体没有发生改变
        stats[S.scale]=0.2f;//大小
        stats[S.speed]=50;//移速
        stats[S.damage] = 1000; // 伤害
        stats[CW_S.wakan] = 100; // 灵气
        MarkNameTemplate("xuanwu_name"); // 设置命名模板，只在中文名存在时生效
        // 创建这个生物的放置按钮
        CreateButton("xuanwu");
        #endregion

        #region ------中国龙
        // 创建一个生物中国龙
        CreateActor("loong","Loong","iconLoong",out vanilla_t,out stats);
        t.prefer_element = new[] { 5, 5, 80, 5, 5 }; // 倾向于木灵根
        t.prefer_element_scale = 1f; // 倾向程度
        t.add_allowed_cultisys("cw_cultisys_immortal"); // 允许修仙
        t.force_cultisys_initial_level("cw_cultisys_immortal", 2); // 强制初始仙路等级为金丹
        // 武道: cw_cultisys_bushido
        // 魂道: cw_cultisys_soul
        vanilla_t.animation_walk = "walk_1,walk_2,walk_3,walk_4,walk_5,walk_6";//移动贴图设置
        vanilla_t.animation_swim = "swim_0,swim_1,swim_2,swim_3,swim_4,swim_5";//游泳贴图设置
        vanilla_t.disableJumpAnimation = true; //允许跳跃
        vanilla_t.needFood = false; // 不需要食物
        vanilla_t.kingdom = Camps.Divine.id;
        vanilla_t.traits = new(){"wise","attractive","flower_prints","healing_aura","energized"};
        // 其他原版设置见 https://github.com/inmny/Cultivation-Way-Core/blob/base_14/Code/W_Content_Actor.cs 第200行开始，
        // 作用于0.14游戏版本，大体没有发生改变
        stats[S.scale]=0.2f;//大小
        stats[S.damage] = 1000; // 伤害
        stats[CW_S.wakan] = 100; // 灵气
        MarkNameTemplate("loong_name"); // 设置命名模板，只在中文名存在时生效
        // 创建这个生物的放置按钮
        CreateButton("loong");
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
    private void CreateActor(
        string pID,
        string pLocaleKey,
        string pIconName,
        out ActorAsset pActorAsset,
        out BaseStats pStats
    )
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
    private void WithCamp(string pCampID)
    {
        t.vanllia_asset.kingdom = pCampID;
        if (!AssetManager.kingdoms.dict.ContainsKey(pCampID))
        {
            Main.Camps.CreateCamp(pCampID);
        }
    }
    /// <summary>
    ///     为一个生物创建一个放置按钮
    /// </summary>
    /// <param name="pActorID">生物id</param>
    /// <param name="pButtonContainer">按钮容器</param>
    private void CreateButton(
        string pActorID,
        ButtonContainerType pButtonContainer = ButtonContainerType.ACTOR
    )
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
    private void CreateButton(
        string pLocaleKey,
        string pIconName,
        ButtonContainerType pButtonContainerType,
        params string[] pActorIDs
    )
    {
        FormatButtons.add_actors_button(
            pActorIDs.ToList(),
            pLocaleKey,
            pIconName,
            pButtonContainerType
        );
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
