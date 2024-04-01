using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using NCMS;
using NCMS.Utils;
using UnityEngine;
using ReflectionUtility;
using HarmonyLib;
using System.Reflection;

namespace CW_FantasyCreatures.content
{
    /// <summary>
    /// Code prototype from 素和晟睿寒海
    /// </summary>
    class Biomes
    {
        public static void init()
        {
            //------珊瑚群系
            BiomeAsset Coral = new BiomeAsset(); //新版本群系的代码独立了出来，不过总体功能没啥变化
            Coral.id = "biome_Coral";
            Coral.tile_low = "Coral_low"; //低块
            Coral.tile_high = "Coral_high"; //高块
            Coral.grow_strength = 10; //群系的扩张强度
            Coral.spread_biome = true;
            Coral.generator_pool_amount = 4; //对地图生成的影响，这个值越大该群系生成概率越高
            Coral.force_unit_skin_set = "mushroom";
            Coral.grow_vegetation_auto = true;
            Coral.grow_type_selector_minerals = new GrowTypeSelector(
                TileActionLibrary.getGrowTypeRandomMineral
            );
            Coral.grow_type_selector_trees = new GrowTypeSelector(
                TileActionLibrary.getGrowTypeRandomTrees
            );
            Coral.grow_type_selector_plants = new GrowTypeSelector(
                TileActionLibrary.getGrowTypeRandomPlants
            );
            Coral.addUnit(SA.crab, 5); //加入生物,前面是生物id，后面是生成占比
            Coral.addUnit(SA.turtle, 3);
            Coral.addMineral(SB.mineral_stone, 5); //加入矿物,前面是建筑id，后面是生成占比
            Coral.addMineral(SB.mineral_metals, 3);
            Coral.addTree("Coral_tree", 1); //加入树,前面是建筑id，后面是生成占比
            Coral.addPlant("Coral", 1); //加入植物,前面是建筑id，后面是生成占比
            AssetManager.biome_library.add(Coral);
            AssetManager.biome_library.addBiomeToPool(Coral);

            TopTileType Coral_low = AssetManager.topTiles.clone("Coral_low", ST.mushroom_low); //地块代码
            Coral_low.color = Toolbox.makeColor("#8bc9f7", -1f); //颜色代码
            Coral_low.setBiome("biome_Coral");
            Coral_low.force_unit_skin_set = "enchanted";
            Coral_low.rank_type = TileRank.Low;
            Coral_low.setDrawLayer(TileZIndexes.mushroom_low, null);
            Coral_low.stepAction = new TileStepAction(Coral_1); //该群系的特殊事件
            Coral_low.stepActionChance = 1437f; //事件发生概率， 这里是指概率143700%
            Coral_low.fireChance = 0.02f; //燃烧概率
            Coral_low.food_resource = SR.mushrooms;
            Coral_low.biome_asset = Coral;
            AssetManager.topTiles.add(Coral_low);
            AssetManager.topTiles.loadSpritesForTile(Coral_low);

            TopTileType Coral_high = AssetManager.topTiles.clone("Coral_high", ST.mushroom_high);
            Coral_high.color = Toolbox.makeColor("#f7e898", -1f); //颜色代码
            Coral_high.setBiome("biome_Coral");
            Coral_high.rank_type = TileRank.High;
            Coral_high.force_unit_skin_set = "enchanted";
            Coral_high.setDrawLayer(TileZIndexes.mushroom_high, null);
            Coral_high.stepActionChance = 1437f;
            Coral_high.fireChance = 0.02f;
            Coral_high.food_resource = SR.mushrooms;
            Coral_high.biome_asset = Coral;
            AssetManager.topTiles.add(Coral_high);
            AssetManager.topTiles.loadSpritesForTile(Coral_high);
            //------竹林群系
            BiomeAsset Bamboo = new BiomeAsset(); //新版本群系的代码独立了出来，不过总体功能没啥变化
            Bamboo.id = "biome_Bamboo";
            Bamboo.tile_low = "Bamboo_low"; //低块
            Bamboo.tile_high = "Bamboo_high"; //高块
            Bamboo.grow_strength = 10; //群系的扩张强度
            Bamboo.spread_biome = true;
            Bamboo.generator_pool_amount = 4; //对地图生成的影响，这个值越大该群系生成概率越高
            Bamboo.force_unit_skin_set = "mushroom";
            Bamboo.grow_vegetation_auto = true;
            Bamboo.grow_type_selector_minerals = new GrowTypeSelector(
                TileActionLibrary.getGrowTypeRandomMineral
            );
            Bamboo.grow_type_selector_trees = new GrowTypeSelector(
                TileActionLibrary.getGrowTypeRandomTrees
            );
            Bamboo.grow_type_selector_plants = new GrowTypeSelector(
                TileActionLibrary.getGrowTypeRandomPlants
            );
            Bamboo.addUnit(SA.bear, 2); //加入生物,前面是生物id，后面是生成占比
            Bamboo.addUnit("panda", 1);//添加熊猫
            Bamboo.addMineral(SB.mineral_stone, 5); //加入矿物,前面是建筑id，后面是生成占比
            Bamboo.addMineral(SB.mineral_metals, 3);
            Bamboo.addTree("Bamboo_tree", 1); //加入树,前面是建筑id，后面是生成占比
            Bamboo.addPlant("Bamboo", 1); //加入植物,前面是建筑id，后面是生成占比
            AssetManager.biome_library.add(Bamboo);
            AssetManager.biome_library.addBiomeToPool(Bamboo);

            TopTileType Bamboo_low = AssetManager.topTiles.clone("Bamboo_low", ST.mushroom_low); //地块代码
            Bamboo_low.color = Toolbox.makeColor("#f7d384", -1f); //颜色代码
            Bamboo_low.setBiome("biome_Bamboo");
            Bamboo_low.force_unit_skin_set = "enchanted";
            Bamboo_low.rank_type = TileRank.Low;
            Bamboo_low.setDrawLayer(TileZIndexes.mushroom_low, null);
            Bamboo_low.stepAction = new TileStepAction(Bamboo_1); //该群系的特殊事件
            Bamboo_low.stepActionChance = 1437f; //事件发生概率， 这里是指概率143700%
            Bamboo_low.fireChance = 0.02f; //燃烧概率
            Bamboo_low.food_resource = SR.mushrooms;
            Bamboo_low.biome_asset = Bamboo;
            AssetManager.topTiles.add(Bamboo_low);
            AssetManager.topTiles.loadSpritesForTile(Bamboo_low);

            TopTileType Bamboo_high = AssetManager.topTiles.clone("Bamboo_high", ST.mushroom_high);
            Bamboo_high.color = Toolbox.makeColor("#e0ad3f", -1f); //颜色代码
            Bamboo_high.setBiome("biome_Bamboo");
            Bamboo_high.rank_type = TileRank.High;
            Bamboo_high.force_unit_skin_set = "enchanted";
            Bamboo_high.setDrawLayer(TileZIndexes.mushroom_high, null);
            Bamboo_high.stepActionChance = 1437f;
            Bamboo_high.fireChance = 0.02f;
            Bamboo_high.food_resource = SR.mushrooms;
            Bamboo_high.biome_asset = Bamboo;
            AssetManager.topTiles.add(Bamboo_high);
            AssetManager.topTiles.loadSpritesForTile(Bamboo_high);
            //------血肉群系
            BiomeAsset FleshBlood = new BiomeAsset(); //新版本群系的代码独立了出来，不过总体功能没啥变化
            FleshBlood.id = "biome_FleshBlood";
            FleshBlood.tile_low = "FleshBlood_low"; //低块
            FleshBlood.tile_high = "FleshBlood_high"; //高块
            FleshBlood.grow_strength = 20; //群系的扩张强度
            FleshBlood.spread_biome = true;
            FleshBlood.generator_pool_amount = 2; //对地图生成的影响，这个值越大该群系生成概率越高
            FleshBlood.force_unit_skin_set = "mushroom";
            FleshBlood.grow_vegetation_auto = true;
            FleshBlood.grow_type_selector_minerals = new GrowTypeSelector(
                TileActionLibrary.getGrowTypeRandomMineral
            );
            FleshBlood.grow_type_selector_trees = new GrowTypeSelector(
                TileActionLibrary.getGrowTypeRandomTrees
            );
            FleshBlood.grow_type_selector_plants = new GrowTypeSelector(
                TileActionLibrary.getGrowTypeRandomPlants
            );
            FleshBlood.addUnit(SA.tumor_monster_animal, 10); //加入生物,前面是生物id，后面是生成占比
            FleshBlood.addMineral(SB.mineral_stone, 5); //加入矿物,前面是建筑id，后面是生成占比
            FleshBlood.addMineral(SB.mineral_metals, 3);
            FleshBlood.addTree("FleshBlood_tree", 1); //加入树,前面是建筑id，后面是生成占比
            FleshBlood.addPlant("FleshBlood", 1); //加入植物,前面是建筑id，后面是生成占比
            AssetManager.biome_library.add(FleshBlood);
            AssetManager.biome_library.addBiomeToPool(FleshBlood);

            TopTileType FleshBlood_low = AssetManager.topTiles.clone(
                "FleshBlood_low",
                ST.mushroom_low
            ); //地块代码
            FleshBlood_low.stepAction = TileActionLibrary.giveMadnessTrait;
            FleshBlood_low.color = Toolbox.makeColor("#ff4363", -1f); //颜色代码
            FleshBlood_low.setBiome("biome_FleshBlood");
            FleshBlood_low.force_unit_skin_set = "enchanted";
            FleshBlood_low.rank_type = TileRank.Low;
            FleshBlood_low.setDrawLayer(TileZIndexes.mushroom_low, null);
            FleshBlood_low.stepAction = new TileStepAction(FleshBlood_1); //该群系的特殊事件
            FleshBlood_low.stepActionChance = 0.0001f; //事件发生概率， 这里是指概率0.001%
            FleshBlood_low.fireChance = 0.02f; //燃烧概率
            FleshBlood_low.food_resource = SR.mushrooms;
            FleshBlood_low.biome_asset = FleshBlood;
            AssetManager.topTiles.add(FleshBlood_low);
            AssetManager.topTiles.loadSpritesForTile(FleshBlood_low);

            TopTileType FleshBlood_high = AssetManager.topTiles.clone(
                "FleshBlood_high",
                ST.mushroom_high
            );
            FleshBlood_high.stepAction = TileActionLibrary.giveMadnessTrait;
            FleshBlood_high.color = Toolbox.makeColor("#e21d62", -1f); //颜色代码
            FleshBlood_high.setBiome("biome_FleshBlood");
            FleshBlood_high.rank_type = TileRank.High;
            FleshBlood_high.force_unit_skin_set = "enchanted";
            FleshBlood_high.setDrawLayer(TileZIndexes.mushroom_high, null);
            FleshBlood_high.stepActionChance = 0.0001f;
            FleshBlood_high.fireChance = 0.02f;
            FleshBlood_high.food_resource = SR.mushrooms;
            FleshBlood_high.biome_asset = FleshBlood;
            AssetManager.topTiles.add(FleshBlood_high);
            AssetManager.topTiles.loadSpritesForTile(FleshBlood_high);
            //------巨橡群系Oak
            BiomeAsset Oak = new BiomeAsset(); //新版本群系的代码独立了出来，不过总体功能没啥变化
            Oak.id = "biome_Oak";
            Oak.tile_low = "Oak_low"; //低块
            Oak.tile_high = "Oak_high"; //高块
            Oak.grow_strength = 10; //群系的扩张强度
            Oak.spread_biome = true;
            Oak.generator_pool_amount = 4; //对地图生成的影响，这个值越大该群系生成概率越高
            Oak.force_unit_skin_set = "mushroom";
            Oak.grow_vegetation_auto = true;
            Oak.grow_type_selector_minerals = new GrowTypeSelector(
                TileActionLibrary.getGrowTypeRandomMineral
            );
            Oak.grow_type_selector_trees = new GrowTypeSelector(
                TileActionLibrary.getGrowTypeRandomTrees
            );
            Oak.grow_type_selector_plants = new GrowTypeSelector(
                TileActionLibrary.getGrowTypeRandomPlants
            );
            Oak.addUnit(SA.wolf, 6); //加入生物,前面是生物id，后面是生成占比
            Oak.addMineral(SB.mineral_stone, 5); //加入矿物,前面是建筑id，后面是生成占比
            Oak.addMineral(SB.mineral_metals, 3);
            Oak.addTree("Oak_tree", 1); //加入树,前面是建筑id，后面是生成占比
            Oak.addPlant("Oak", 1); //加入植物,前面是建筑id，后面是生成占比
            AssetManager.biome_library.add(Oak);
            AssetManager.biome_library.addBiomeToPool(Oak);

            TopTileType Oak_low = AssetManager.topTiles.clone("Oak_low", ST.mushroom_low); //地块代码
            Oak_low.color = Toolbox.makeColor("#6a7d34", -1f); //颜色代码
            Oak_low.setBiome("biome_Oak");
            Oak_low.force_unit_skin_set = "enchanted";
            Oak_low.rank_type = TileRank.Low;
            Oak_low.setDrawLayer(TileZIndexes.mushroom_low, null);
            Oak_low.stepAction = new TileStepAction(Oak_1); //该群系的特殊事件
            Oak_low.stepActionChance = 1437f; //事件发生概率， 这里是指概率143700%
            Oak_low.fireChance = 0.02f; //燃烧概率
            Oak_low.food_resource = SR.mushrooms;
            Oak_low.biome_asset = Oak;
            AssetManager.topTiles.add(Oak_low);
            AssetManager.topTiles.loadSpritesForTile(Oak_low);

            TopTileType Oak_high = AssetManager.topTiles.clone("Oak_high", ST.mushroom_high);
            Oak_high.color = Toolbox.makeColor("#497124", -1f); //颜色代码
            Oak_high.setBiome("biome_Oak");
            Oak_high.rank_type = TileRank.High;
            Oak_high.force_unit_skin_set = "enchanted";
            Oak_high.setDrawLayer(TileZIndexes.mushroom_high, null);
            Oak_high.stepActionChance = 1437f;
            Oak_high.fireChance = 0.02f;
            Oak_high.food_resource = SR.mushrooms;
            Oak_high.biome_asset = Oak;
            AssetManager.topTiles.add(Oak_high);
            AssetManager.topTiles.loadSpritesForTile(Oak_high);
            //------泰坦群系Titans
            BiomeAsset Titans = new BiomeAsset(); //新版本群系的代码独立了出来，不过总体功能没啥变化
            Titans.id = "biome_Titans";
            Titans.tile_low = "Titans_low"; //低块
            Titans.tile_high = "Titans_high"; //高块
            Titans.grow_strength = 10; //群系的扩张强度
            Titans.spread_biome = true;
            Titans.generator_pool_amount = 4; //对地图生成的影响，这个值越大该群系生成概率越高
            Titans.force_unit_skin_set = "mushroom";
            Titans.grow_vegetation_auto = true;
            Titans.grow_type_selector_minerals = new GrowTypeSelector(
                TileActionLibrary.getGrowTypeRandomMineral
            );
            Titans.grow_type_selector_trees = new GrowTypeSelector(
                TileActionLibrary.getGrowTypeRandomTrees
            );
            Titans.grow_type_selector_plants = new GrowTypeSelector(
                TileActionLibrary.getGrowTypeRandomPlants
            );
            Titans.addUnit(SA.skeleton, 6); //加入生物,前面是生物id，后面是生成占比
            Titans.addMineral(SB.mineral_stone, 5); //加入铜矿物,前面是建筑id，后面是生成占比
            Titans.addMineral(SB.mineral_metals, 3);
            Titans.addTree("Titans_tree", 1); //加入树,前面是建筑id，后面是生成占比
            Titans.addPlant("Titans", 1); //加入植物,前面是建筑id，后面是生成占比
            AssetManager.biome_library.add(Titans);
            AssetManager.biome_library.addBiomeToPool(Titans);

            TopTileType Titans_low = AssetManager.topTiles.clone("Titans_low", ST.mushroom_low); //地块代码
            Titans_low.color = Toolbox.makeColor("#ed9759", -1f); //颜色代码
            Titans_low.setBiome("biome_Titans");
            Titans_low.force_unit_skin_set = "enchanted";
            Titans_low.rank_type = TileRank.Low;
            Titans_low.setDrawLayer(TileZIndexes.mushroom_low, null);
            Titans_low.stepAction = new TileStepAction(Titans_1); //该群系的特殊事件
            Titans_low.stepActionChance = 1437f; //事件发生概率， 这里是指概率143700%
            Titans_low.fireChance = 0.02f; //燃烧概率
            Titans_low.food_resource = SR.mushrooms;
            Titans_low.biome_asset = Titans;
            AssetManager.topTiles.add(Titans_low);
            AssetManager.topTiles.loadSpritesForTile(Titans_low);

            TopTileType Titans_high = AssetManager.topTiles.clone("Titans_high", ST.mushroom_high);
            Titans_high.color = Toolbox.makeColor("#cc4f1d", -1f); //颜色代码
            Titans_high.setBiome("biome_Titans");
            Titans_high.rank_type = TileRank.High;
            Titans_high.force_unit_skin_set = "enchanted";
            Titans_high.setDrawLayer(TileZIndexes.mushroom_high, null);
            Titans_high.stepActionChance = 1437f;
            Titans_high.fireChance = 0.02f;
            Titans_high.food_resource = SR.mushrooms;
            Titans_high.biome_asset = Titans;
            AssetManager.topTiles.add(Titans_high);
            AssetManager.topTiles.loadSpritesForTile(Titans_high);
            //------知识群系
            BiomeAsset Knowledge = new BiomeAsset(); //新版本群系的代码独立了出来，不过总体功能没啥变化
            Knowledge.id = "biome_Knowledge";
            Knowledge.tile_low = "Knowledge_low"; //低块
            Knowledge.tile_high = "Knowledge_high"; //高块
            Knowledge.grow_strength = 10; //群系的扩张强度
            Knowledge.spread_biome = true;
            Knowledge.generator_pool_amount = 4; //对地图生成的影响，这个值越大该群系生成概率越高
            Knowledge.force_unit_skin_set = "mushroom";
            Knowledge.grow_vegetation_auto = true;
            Knowledge.grow_type_selector_minerals = new GrowTypeSelector(
                TileActionLibrary.getGrowTypeRandomMineral
            );
            Knowledge.grow_type_selector_trees = new GrowTypeSelector(
                TileActionLibrary.getGrowTypeRandomTrees
            );
            Knowledge.grow_type_selector_plants = new GrowTypeSelector(
                TileActionLibrary.getGrowTypeRandomPlants
            );
            Knowledge.addUnit(SA.fox, 2); //加入生物,前面是生物id，后面是生成占比
            Knowledge.addMineral(SB.mineral_stone, 5); //加入矿物,前面是建筑id，后面是生成占比
            Knowledge.addMineral(SB.mineral_metals, 3);
            Knowledge.addTree("Knowledge_tree", 1); //加入树,前面是建筑id，后面是生成占比
            Knowledge.addPlant("Knowledge", 1); //加入植物,前面是建筑id，后面是生成占比
            AssetManager.biome_library.add(Knowledge);
            AssetManager.biome_library.addBiomeToPool(Knowledge);

            TopTileType Knowledge_low = AssetManager.topTiles.clone(
                "Knowledge_low",
                ST.mushroom_low
            ); //地块代码
            Knowledge_low.color = Toolbox.makeColor("#7fca4f", -1f); //颜色代码
            Knowledge_low.setBiome("biome_Knowledge");
            Knowledge_low.force_unit_skin_set = "enchanted";
            Knowledge_low.rank_type = TileRank.Low;
            Knowledge_low.setDrawLayer(TileZIndexes.mushroom_low, null);
            Knowledge_low.stepAction = new TileStepAction(Knowledge_1); //该群系的特殊事件
            Knowledge_low.stepActionChance = 1437f; //事件发生概率， 这里是指概率143700%
            Knowledge_low.fireChance = 0.02f; //燃烧概率
            Knowledge_low.food_resource = SR.mushrooms;
            Knowledge_low.biome_asset = Knowledge;
            Knowledge_low.stepAction = tempHighIntelligence; //智慧BUFF
            AssetManager.topTiles.add(Knowledge_low);
            AssetManager.topTiles.loadSpritesForTile(Knowledge_low);

            TopTileType Knowledge_high = AssetManager.topTiles.clone(
                "Knowledge_high",
                ST.mushroom_high
            );
            Knowledge_high.color = Toolbox.makeColor("#69aa3f", -1f); //颜色代码
            Knowledge_high.setBiome("biome_Knowledge");
            Knowledge_high.rank_type = TileRank.High;
            Knowledge_high.force_unit_skin_set = "enchanted";
            Knowledge_high.setDrawLayer(TileZIndexes.mushroom_high, null);
            Knowledge_high.stepActionChance = 1437f;
            Knowledge_high.fireChance = 0.02f;
            Knowledge_high.food_resource = SR.mushrooms;
            Knowledge_high.biome_asset = Knowledge;
            Knowledge_high.stepAction = tempHighIntelligence; //智慧BUFF
            AssetManager.topTiles.add(Knowledge_high);
            AssetManager.topTiles.loadSpritesForTile(Knowledge_high);
            //------
        }

        private static bool tempHighIntelligence(WorldTile pTile, ActorBase pActor)
        {
            pActor.addStatusEffect("intelligent");
            return true;
        }

        public static bool Coral_1(WorldTile pTile, ActorBase pActor) //事件代码,我这里全删了
        {
            return true;
        }

        public static bool Bamboo_1(WorldTile pTile, ActorBase pActor) //事件代码,我这里全删了
        {
            return true;
        }

        public static bool FleshBlood_1(WorldTile pTile, ActorBase pActor) //事件代码,我这里全删了
        {
            return true;
        }

        public static bool Oak_1(WorldTile pTile, ActorBase pActor) //事件代码,我这里全删了
        {
            return true;
        }

        public static bool Titans_1(WorldTile pTile, ActorBase pActor) //事件代码,我这里全删了
        {
            return true;
        }

        public static bool Knowledge_1(WorldTile pTile, ActorBase pActor) //事件代码,我这里全删了
        {
            return true;
        }
    }
}
