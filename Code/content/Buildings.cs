using NCMS;
using System;
using NCMS.Utils;
using System.IO;
using System.Linq;
using UnityEngine;
using ReflectionUtility;
using HarmonyLib;
using System.Reflection;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading;
using System.Text;
using UnityEngine.UI;
using pathfinding;
using CW_FantasyCreatures.ui;

namespace CW_FantasyCreatures.content
{
    class Buildings
    {
        private static List<BuildingAsset> humanBuildings = new List<BuildingAsset>();

        public static void init()
        {
            //------珊瑚群系Coral
            BuildingAsset Coral_tree = AssetManager.buildings.clone("Coral_tree", "tree");
            Coral_tree.limit_per_zone = 7;
            Coral_tree.canBePlacedOnlyOn = List.Of<string>(
                new string[] { "Coral_high", "Coral_low" }
            );
            Coral_tree.spread_ids = List.Of<string>(new string[] { "Coral_tree" });
            Coral_tree.setShadow(0.5f, 0.03f, 0.12f); //设置阴影
            AssetManager.buildings.addResource("wood", 5, false); //添加木材
            AssetManager.buildings.addResource("fish", 5, false); //添加鱼肉
            AssetManager.buildings.loadSprites(Coral_tree);

            BuildingAsset Coral = AssetManager.buildings.clone("Coral", "mushroom");
            Coral.limit_per_zone = 4;
            Coral.wheat = true;
            Coral.canBeHarvested = true;
            Coral.setShadow(0.5f, 0.03f, 0.12f);
            Coral.canBePlacedOnlyOn = List.Of<string>(new string[] { "Coral_high", "Coral_low" });
            Coral.spread_ids = List.Of<string>(new string[] { "Coral" });
            AssetManager.buildings.addResource("stone", 1, false); //添加石头
            AssetManager.buildings.addResource("fish", 5, false); //添加鱼肉
            AssetManager.buildings.loadSprites(Coral);
            //------竹林群系Bamboo
            BuildingAsset Bamboo_tree = AssetManager.buildings.clone("Bamboo_tree", "tree");
            Bamboo_tree.limit_per_zone = 7;
            Bamboo_tree.canBePlacedOnlyOn = List.Of<string>(
                new string[] { "Bamboo_high", "Bamboo_low" }
            );
            Bamboo_tree.spread_ids = List.Of<string>(new string[] { "Bamboo_tree" });
            Bamboo_tree.setShadow(0.5f, 0.03f, 0.12f); //设置阴影
            AssetManager.buildings.addResource("wood", 5, false); //添加木材
            AssetManager.buildings.addResource("herbs", 5, false); //添加香草
            AssetManager.buildings.loadSprites(Bamboo_tree);

            BuildingAsset Bamboo = AssetManager.buildings.clone("Bamboo", "mushroom");
            Bamboo.limit_per_zone = 4;
            Bamboo.wheat = true;
            Bamboo.canBeHarvested = true;
            Bamboo.setShadow(0.5f, 0.03f, 0.12f);
            Bamboo.canBePlacedOnlyOn = List.Of<string>(
                new string[] { "Bamboo_high", "Bamboo_low" }
            );
            Bamboo.spread_ids = List.Of<string>(new string[] { "Bamboo" });
            AssetManager.buildings.addResource("stone", 1, false); //添加石头
            AssetManager.buildings.loadSprites(Bamboo);
            //------血肉群系FleshBlood
            BuildingAsset FleshBlood_tree = AssetManager.buildings.clone("FleshBlood_tree", "tree");
            FleshBlood_tree.limit_per_zone = 1;
            FleshBlood_tree.canBePlacedOnlyOn = List.Of<string>(
                new string[] { "FleshBlood_high", "FleshBlood_low" }
            );
            FleshBlood_tree.spread_ids = List.Of<string>(new string[] { "FleshBlood_tree" });
            FleshBlood_tree.setShadow(0.5f, 0.03f, 0.12f); //设置阴影
            FleshBlood_tree.material = "building";//设置树木为建筑，禁止晃动
            AssetManager.buildings.addResource("worms", 5, false); //添加蠕虫
            AssetManager.buildings.addResource("bones", 5, false); //添加骨头
            AssetManager.buildings.addResource("meat", 5, false); //添加肉
            AssetManager.buildings.loadSprites(FleshBlood_tree);
            FleshBlood_tree.affected_by_drought = false;//禁止建筑晃动

            BuildingAsset FleshBlood = AssetManager.buildings.clone("FleshBlood", "mushroom");
            FleshBlood.limit_per_zone = 1;
            FleshBlood.wheat = true;
            FleshBlood.canBeHarvested = true;
            FleshBlood.setShadow(0.5f, 0.03f, 0.12f);
            FleshBlood.canBePlacedOnlyOn = List.Of<string>(
                new string[] { "FleshBlood_high", "FleshBlood_low" }
            );
            FleshBlood.spread_ids = List.Of<string>(new string[] { "FleshBlood" });
            AssetManager.buildings.addResource("meat", 1, false); //添加肉
            AssetManager.buildings.loadSprites(FleshBlood);
            //------巨橡群系Oak
            BuildingAsset Oak_tree = AssetManager.buildings.clone("Oak_tree", "tree");
            Oak_tree.limit_per_zone = 7;
            Oak_tree.canBePlacedOnlyOn = List.Of<string>(new string[] { "Oak_high", "Oak_low" });
            Oak_tree.spread_ids = List.Of<string>(new string[] { "Oak_tree" });
            Oak_tree.setShadow(0.5f, 0.03f, 0.12f); //设置阴影
            AssetManager.buildings.addResource("wood", 20, false); //添加木材
            AssetManager.buildings.loadSprites(Oak_tree);

            BuildingAsset Oak = AssetManager.buildings.clone("Oak", "mushroom");
            Oak.limit_per_zone = 4;
            Oak.wheat = true;
            Oak.canBeHarvested = true;
            Oak.setShadow(0.5f, 0.03f, 0.12f);
            Oak.canBePlacedOnlyOn = List.Of<string>(new string[] { "Oak_high", "Oak_low" });
            Oak.spread_ids = List.Of<string>(new string[] { "Oak" });
            AssetManager.buildings.addResource("stone", 1, false); //添加石头
            AssetManager.buildings.loadSprites(Oak);
            //------泰坦群系Titans
            BuildingAsset Titans_tree = AssetManager.buildings.clone("Titans_tree", "tree");
            Titans_tree.limit_per_zone = 1;
            Titans_tree.canBePlacedOnlyOn = List.Of<string>(
                new string[] { "Titans_high", "Titans_low" }
            );
            Titans_tree.spread_ids = List.Of<string>(new string[] { "Titans_tree" });
            Titans_tree.setShadow(0.5f, 0.03f, 0.12f); //设置阴影
            Titans_tree.material = "building";//设置树木为建筑，禁止晃动
            AssetManager.buildings.addResource("wood", 20, false); //添加木材
            AssetManager.buildings.loadSprites(Titans_tree);
            Titans_tree.affected_by_drought = false;

            BuildingAsset Titans = AssetManager.buildings.clone("Titans", "mushroom");
            Titans.limit_per_zone = 4;
            Titans.wheat = true;
            Titans.canBeHarvested = true;
            Titans.setShadow(0.5f, 0.03f, 0.12f);
            Titans.canBePlacedOnlyOn = List.Of<string>(
                new string[] { "Titans_high", "Titans_low" }
            );
            Titans.spread_ids = List.Of<string>(new string[] { "Titans" });
            AssetManager.buildings.addResource("bones", 6, false); //添加骨头
            AssetManager.buildings.addResource("gold", 8, false); //添加金
            AssetManager.buildings.addResource("common_metals", 8, false); //添加金属
            AssetManager.buildings.addResource("stone", 1, false); //添加石头
            AssetManager.buildings.loadSprites(Titans);
            //------黑暗群系Dark
            BuildingAsset Dark_tree = AssetManager.buildings.clone("Dark_tree", "tree");
            Dark_tree.limit_per_zone = 7;
            Dark_tree.canBePlacedOnlyOn = List.Of<string>(
                new string[] { "Dark_high", "Dark_low" }
            );
            Dark_tree.spread_ids = List.Of<string>(new string[] { "Dark_tree" });
            Dark_tree.setShadow(0.5f, 0.03f, 0.12f); //设置阴影
            AssetManager.buildings.addResource("wood", 20, false); //添加木材
            AssetManager.buildings.loadSprites(Dark_tree);

            BuildingAsset Dark = AssetManager.buildings.clone("Dark", "mushroom");
            Dark.limit_per_zone = 4;
            Dark.wheat = true;
            Dark.canBeHarvested = true;
            Dark.setShadow(0.5f, 0.03f, 0.12f);
            Dark.canBePlacedOnlyOn = List.Of<string>(
                new string[] { "Dark_high", "Dark_low" }
            );
            Dark.spread_ids = List.Of<string>(new string[] { "Dark" });
            AssetManager.buildings.addResource("bones", 6, false); //添加骨头
            AssetManager.buildings.addResource("stone", 1, false); //添加石头
            AssetManager.buildings.loadSprites(Dark);
            //------巨稻群系Rice
            BuildingAsset Rice_tree = AssetManager.buildings.clone("Rice_tree", "tree");
            Rice_tree.limit_per_zone = 7;
            Rice_tree.canBePlacedOnlyOn = List.Of<string>(
                new string[] { "Rice_high", "Rice_low" }
            );
            Rice_tree.spread_ids = List.Of<string>(new string[] { "Rice_tree" });
            Rice_tree.setShadow(0.5f, 0.03f, 0.12f); //设置阴影
            AssetManager.buildings.addResource("wheat", 5, false); //添加小麦
            AssetManager.buildings.addResource("wood", 20, false); //添加木材
            AssetManager.buildings.loadSprites(Rice_tree);

            BuildingAsset Rice = AssetManager.buildings.clone("Rice", "mushroom");
            Rice.limit_per_zone = 4;
            Rice.wheat = true;
            Rice.canBeHarvested = true;
            Rice.setShadow(0.5f, 0.03f, 0.12f);
            Rice.canBePlacedOnlyOn = List.Of<string>(
                new string[] { "Rice_high", "Rice_low" }
            );
            Rice.spread_ids = List.Of<string>(new string[] { "Rice" });
            AssetManager.buildings.addResource("fish", 5, false); //添加鱼肉
            AssetManager.buildings.addResource("stone", 1, false); //添加石头
            AssetManager.buildings.loadSprites(Rice);
            //------知识群系Knowledge
            BuildingAsset Knowledge_tree = AssetManager.buildings.clone("Knowledge_tree", "tree");
            Knowledge_tree.limit_per_zone = 2;
            Knowledge_tree.canBePlacedOnlyOn = List.Of<string>(
                new string[] { "Knowledge_high", "Knowledge_low" }
            );
            Knowledge_tree.spread_ids = List.Of<string>(new string[] { "Knowledge_tree" });
            Knowledge_tree.setShadow(0.5f, 0.03f, 0.12f); //设置阴影
            AssetManager.buildings.addResource("wood", 5, false); //添加木材
            AssetManager.buildings.loadSprites(Knowledge_tree);

            BuildingAsset Knowledge = AssetManager.buildings.clone("Knowledge", "mushroom");
            Knowledge.limit_per_zone = 4;
            Knowledge.wheat = true;
            Knowledge.canBeHarvested = true;
            Knowledge.setShadow(0.5f, 0.03f, 0.12f);
            Knowledge.canBePlacedOnlyOn = List.Of<string>(
                new string[] { "Knowledge_high", "Knowledge_low" }
            );
            Knowledge.spread_ids = List.Of<string>(new string[] { "Knowledge" });
            AssetManager.buildings.addResource("stone", 1, false); //添加石头
            AssetManager.buildings.loadSprites(Knowledge);
            //------哥布林地穴
            BuildingAsset GoblinTower = AssetManager.buildings.clone(nameof(GoblinTower), SB.flame_tower);
            GoblinTower.race = "Goblin"; // 自己改哥布林相关的种族
            GoblinTower.kingdom = "Goblin"; // 自己改
            GoblinTower.tower = false; // 禁用原有的火球发射
            GoblinTower.spawnUnits_asset = "goblin_warrior:6,goblin_shaman:1,goblin_knight:2"; // 改哥布林的生物id
            AssetManager.buildings.loadSprites(GoblinTower);
            TabManager.AddBuildingDropButton(GoblinTower.id, GoblinTower.id, GoblinTower.id);

            //------魔法学院
            BuildingAsset MagicTower = AssetManager.buildings.clone(nameof(MagicTower), SB.flame_tower);
            MagicTower.race = "Extraordinary"; // 自己改魔法相关的种族
            MagicTower.kingdom = "Extraordinary"; // 自己改
            MagicTower.tower = false; // 禁用原有的火球发射
            MagicTower.spawnUnits_asset = "griffin_knight:3,sorcerer:1,guard_knight:2"; // 改生物id
            AssetManager.buildings.loadSprites(MagicTower);
            TabManager.AddBuildingDropButton(MagicTower.id, MagicTower.id, MagicTower.id);
            
            //------妖精树屋
            BuildingAsset SpriteTower = AssetManager.buildings.clone(nameof(SpriteTower), SB.flame_tower);
            SpriteTower.race = "Sprite"; // 自己改魔法相关的种族
            SpriteTower.kingdom = "Sprite"; // 自己改
            SpriteTower.tower = false; // 禁用原有的火球发射
            SpriteTower.spawnUnits_asset = "sprite_ranger:8,sprite_druid:1,sprite_warrior:4"; // 改生物id
            AssetManager.buildings.loadSprites(SpriteTower);
            TabManager.AddBuildingDropButton(SpriteTower.id, SpriteTower.id, SpriteTower.id);

            //------傀儡工坊
            BuildingAsset RobotTower = AssetManager.buildings.clone(nameof(RobotTower), SB.flame_tower);
            RobotTower.race = "Robot"; // 自己改魔法相关的种族
            RobotTower.kingdom = "Robot"; // 自己改
            RobotTower.tower = true; // 火球发射
            RobotTower.smoke = true; // 烟雾开关
            RobotTower.smokeInterval = 0.5f; // 烟雾产生时间间隔
            RobotTower.smokeOffset = new Vector2Int(6, 3); // 烟雾产生位置
            RobotTower.spawnUnits_asset = "fort_robot:4,destroy_robot:1,tank_robot:2"; // 改生物id
            AssetManager.buildings.loadSprites(RobotTower);
            TabManager.AddBuildingDropButton(RobotTower.id, RobotTower.id, RobotTower.id);

            //------烛火群系Candle
            BuildingAsset Candle_tree = AssetManager.buildings.clone("Candle_tree", "tree");
            Candle_tree.limit_per_zone = 2;
            Candle_tree.canBePlacedOnlyOn = List.Of<string>(
                new string[] { "Candle_high", "Candle_low" }
            );
            Candle_tree.spread_ids = List.Of<string>(new string[] { "Candle_tree" });
            Candle_tree.setShadow(0.5f, 0.03f, 0.12f); //设置阴影
            Candle_tree.material = "building";//设置树木为建筑，禁止晃动
            Candle_tree.draw_light_area = true;//允许树发光
            Candle_tree.draw_light_size = 0.4f; //亮度
            AssetManager.buildings.addResource("wood", 5, false); //添加木材
            AssetManager.buildings.loadSprites(Candle_tree);

            BuildingAsset Candle = AssetManager.buildings.clone("Candle", "mushroom");
            Candle.limit_per_zone = 4;
            Candle.wheat = true;
            Candle.material = "building";//设置草为建筑，禁止晃动
            Candle.canBeHarvested = true;
            Candle.setShadow(0.5f, 0.03f, 0.12f);
            Candle.canBePlacedOnlyOn = List.Of<string>(
                new string[] { "Candle_high", "Candle_low" }
            );
            Candle.spread_ids = List.Of<string>(new string[] { "Candle" });
            AssetManager.buildings.addResource("stone", 1, false); //添加石头
            AssetManager.buildings.loadSprites(Candle);
            
            //------墓地群系Cemetery
            BuildingAsset Cemetery_tree = AssetManager.buildings.clone("Cemetery_tree", "tree");
            Cemetery_tree.limit_per_zone = 2;
            Cemetery_tree.canBePlacedOnlyOn = List.Of<string>(
                new string[] { "Cemetery_high", "Cemetery_low" }
            );
            Cemetery_tree.spread_ids = List.Of<string>(new string[] { "Cemetery_tree" });
            Cemetery_tree.setShadow(0.5f, 0.03f, 0.12f); //设置阴影
            Cemetery_tree.material = "building";//设置树木为建筑，禁止晃动
            AssetManager.buildings.addResource("wood", 5, false); //添加木材
            AssetManager.buildings.loadSprites(Cemetery_tree);

            BuildingAsset Cemetery = AssetManager.buildings.clone("Cemetery", "mushroom");
            Cemetery.limit_per_zone = 4;
            Cemetery.wheat = true;
            Cemetery.material = "building";//设置草为建筑，禁止晃动
            Cemetery.canBeHarvested = true;
            Cemetery.setShadow(0.5f, 0.03f, 0.12f);
            Cemetery.canBePlacedOnlyOn = List.Of<string>(
                new string[] { "Cemetery_high", "Cemetery_low" }
            );
            Cemetery.spread_ids = List.Of<string>(new string[] { "Cemetery" });
            AssetManager.buildings.addResource("stone", 1, false); //添加石头
            AssetManager.buildings.loadSprites(Cemetery);
            //------蕨类群系Fern
            BuildingAsset Fern_tree = AssetManager.buildings.clone("Fern_tree", "tree");
            Fern_tree.limit_per_zone = 7;
            Fern_tree.canBePlacedOnlyOn = List.Of<string>(
                new string[] { "Fern_high", "Fern_low" }
            );
            Fern_tree.spread_ids = List.Of<string>(new string[] { "Fern_tree" });
            Fern_tree.setShadow(0.5f, 0.03f, 0.12f); //设置阴影
            AssetManager.buildings.addResource("wood", 20, false); //添加木材
            AssetManager.buildings.loadSprites(Fern_tree);

            BuildingAsset Fern = AssetManager.buildings.clone("Fern", "mushroom");
            Fern.limit_per_zone = 4;
            Fern.wheat = true;
            Fern.canBeHarvested = true;
            Fern.setShadow(0.5f, 0.03f, 0.12f);
            Fern.canBePlacedOnlyOn = List.Of<string>(
                new string[] { "Fern_high", "Fern_low" }
            );
            Fern.spread_ids = List.Of<string>(new string[] { "Fern" });
            AssetManager.buildings.addResource("stone", 1, false); //添加石头
            AssetManager.buildings.loadSprites(Fern);

        }
    }
}
