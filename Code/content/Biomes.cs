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
            Coral.grow_strength = 2; //群系的扩张强度
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
            Coral_low.color = Toolbox.makeColor("#82d9d3", -1f); //颜色代码
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
            Coral_high.color = Toolbox.makeColor("#f7dda3", -1f); //颜色代码
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
            Bamboo.grow_strength = 2; //群系的扩张强度
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
            //Bamboo.addUnit(SA.bear, 2); //加入生物熊,前面是生物id，后面是生成占比
            Bamboo.addUnit("panda", 2);//添加熊猫
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
            Oak.grow_strength = 2; //群系的扩张强度
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
            //Oak.addUnit(SA.wolf, 6); //加入生物,前面是生物id，后面是生成占比
            Oak.addUnit("oak_treants", 1);//添加巨橡树人
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
//------黑暗群系Dark
            BiomeAsset Dark = new BiomeAsset(); //新版本群系的代码独立了出来，不过总体功能没啥变化
            Dark.id = "biome_Dark";
            Dark.tile_low = "Dark_low"; //低块
            Dark.tile_high = "Dark_high"; //高块
            Dark.grow_strength = 10; //群系的扩张强度
            Dark.spread_biome = true;
            Dark.generator_pool_amount = 4; //对地图生成的影响，这个值越大该群系生成概率越高
            Dark.force_unit_skin_set = "mushroom";
            Dark.grow_vegetation_auto = true;
            Dark.grow_type_selector_minerals = new GrowTypeSelector(
                TileActionLibrary.getGrowTypeRandomMineral
            );
            Dark.grow_type_selector_trees = new GrowTypeSelector(
                TileActionLibrary.getGrowTypeRandomTrees
            );
            Dark.grow_type_selector_plants = new GrowTypeSelector(
                TileActionLibrary.getGrowTypeRandomPlants
            );
            //加入生物,前面是生物id，后面是生成占比
            Dark.addUnit(SA.skeleton, 6); //添加骷髅
            Dark.addUnit("bloodsucker", 2);//添加吸血鬼
            Dark.addUnit("werewolf", 4);//添加狼人
            Dark.addUnit("vampire_hunter", 1);//添加吸血鬼猎人
            Dark.addMineral(SB.mineral_stone, 5); //加入铜矿物,前面是建筑id，后面是生成占比
            Dark.addMineral(SB.mineral_metals, 3);
            Dark.addTree("Dark_tree", 1); //加入树,前面是建筑id，后面是生成占比
            Dark.addPlant("Dark", 1); //加入植物,前面是建筑id，后面是生成占比
            AssetManager.biome_library.add(Dark);
            AssetManager.biome_library.addBiomeToPool(Dark);

            TopTileType Dark_low = AssetManager.topTiles.clone("Dark_low", ST.mushroom_low); //地块代码
            Dark_low.color = Toolbox.makeColor("#4d5762", -1f); //颜色代码
            Dark_low.setBiome("biome_Dark");
            Dark_low.force_unit_skin_set = "enchanted";
            Dark_low.rank_type = TileRank.Low;
            Dark_low.setDrawLayer(TileZIndexes.mushroom_low, null);
            Dark_low.stepAction = new TileStepAction(Dark_1); //该群系的特殊事件
            Dark_low.stepActionChance = 1437f; //事件发生概率， 这里是指概率143700%
            Dark_low.fireChance = 0.02f; //燃烧概率
            Dark_low.food_resource = SR.mushrooms;
            Dark_low.biome_asset = Dark;
            AssetManager.topTiles.add(Dark_low);
            AssetManager.topTiles.loadSpritesForTile(Dark_low);

            TopTileType Dark_high = AssetManager.topTiles.clone("Dark_high", ST.mushroom_high);
            Dark_high.color = Toolbox.makeColor("#757a81", -1f); //颜色代码
            Dark_high.setBiome("biome_Dark");
            Dark_high.rank_type = TileRank.High;
            Dark_high.force_unit_skin_set = "enchanted";
            Dark_high.setDrawLayer(TileZIndexes.mushroom_high, null);
            Dark_high.stepActionChance = 1437f;
            Dark_high.fireChance = 0.02f;
            Dark_high.food_resource = SR.mushrooms;
            Dark_high.biome_asset = Dark;
            AssetManager.topTiles.add(Dark_high);
            AssetManager.topTiles.loadSpritesForTile(Dark_high);
//------巨稻群系Rice
            BiomeAsset Rice = new BiomeAsset(); //新版本群系的代码独立了出来，不过总体功能没啥变化
            Rice.id = "biome_Rice";
            Rice.tile_low = "Rice_low"; //低块
            Rice.tile_high = "Rice_high"; //高块
            Rice.grow_strength = 10; //群系的扩张强度
            Rice.spread_biome = true;
            Rice.generator_pool_amount = 4; //对地图生成的影响，这个值越大该群系生成概率越高
            Rice.force_unit_skin_set = "mushroom";
            Rice.grow_vegetation_auto = true;
            Rice.grow_type_selector_minerals = new GrowTypeSelector(
                TileActionLibrary.getGrowTypeRandomMineral
            );
            Rice.grow_type_selector_trees = new GrowTypeSelector(
                TileActionLibrary.getGrowTypeRandomTrees
            );
            Rice.grow_type_selector_plants = new GrowTypeSelector(
                TileActionLibrary.getGrowTypeRandomPlants
            );
            //加入生物,前面是生物id，后面是生成占比
            Coral.addUnit(SA.crab, 5); 
            Rice.addMineral(SB.mineral_stone, 5); //加入铜矿物,前面是建筑id，后面是生成占比
            Rice.addMineral(SB.mineral_metals, 3);
            Rice.addTree("Rice_tree", 1); //加入树,前面是建筑id，后面是生成占比
            Rice.addPlant("Rice", 1); //加入植物,前面是建筑id，后面是生成占比
            AssetManager.biome_library.add(Rice);
            AssetManager.biome_library.addBiomeToPool(Rice);

            TopTileType Rice_low = AssetManager.topTiles.clone("Rice_low", ST.mushroom_low); //地块代码
            Rice_low.color = Toolbox.makeColor("#4e836f", -1f); //颜色代码
            Rice_low.setBiome("biome_Rice");
            Rice_low.force_unit_skin_set = "enchanted";
            Rice_low.rank_type = TileRank.Low;
            Rice_low.setDrawLayer(TileZIndexes.mushroom_low, null);
            Rice_low.stepAction = new TileStepAction(Rice_1); //该群系的特殊事件
            Rice_low.stepActionChance = 1437f; //事件发生概率， 这里是指概率143700%
            Rice_low.fireChance = 0.02f; //燃烧概率
            Rice_low.food_resource = SR.mushrooms;
            Rice_low.biome_asset = Rice;
            AssetManager.topTiles.add(Rice_low);
            AssetManager.topTiles.loadSpritesForTile(Rice_low);

            TopTileType Rice_high = AssetManager.topTiles.clone("Rice_high", ST.mushroom_high);
            Rice_high.color = Toolbox.makeColor("#7ac4a9", -1f); //颜色代码
            Rice_high.setBiome("biome_Rice");
            Rice_high.rank_type = TileRank.High;
            Rice_high.force_unit_skin_set = "enchanted";
            Rice_high.setDrawLayer(TileZIndexes.mushroom_high, null);
            Rice_high.stepActionChance = 1437f;
            Rice_high.fireChance = 0.02f;
            Rice_high.food_resource = SR.mushrooms;
            Rice_high.biome_asset = Rice;
            AssetManager.topTiles.add(Rice_high);
            AssetManager.topTiles.loadSpritesForTile(Rice_high);
//------知识群系
            BiomeAsset Knowledge = new BiomeAsset(); //新版本群系的代码独立了出来，不过总体功能没啥变化
            Knowledge.id = "biome_Knowledge";
            Knowledge.tile_low = "Knowledge_low"; //低块
            Knowledge.tile_high = "Knowledge_high"; //高块
            Knowledge.grow_strength = 2; //群系的扩张强度
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
            //Knowledge.addUnit(SA.fox, 2); //加入生物,前面是生物id，后面是生成占比
            Knowledge.addUnit("knowledge_genie", 4);//添加知识之灵
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
//------烛火群系
            BiomeAsset Candle = new BiomeAsset(); //新版本群系的代码独立了出来，不过总体功能没啥变化
            Candle.id = "biome_Candle";
            Candle.tile_low = "Candle_low"; //低块
            Candle.tile_high = "Candle_high"; //高块
            Candle.grow_strength = 2; //群系的扩张强度
            Candle.spread_biome = true;
            Candle.generator_pool_amount = 4; //对地图生成的影响，这个值越大该群系生成概率越高
            Candle.force_unit_skin_set = "mushroom";
            Candle.grow_vegetation_auto = true;
            Candle.grow_type_selector_minerals = new GrowTypeSelector(
                TileActionLibrary.getGrowTypeRandomMineral
            );
            Candle.grow_type_selector_trees = new GrowTypeSelector(
                TileActionLibrary.getGrowTypeRandomTrees
            );
            Candle.grow_type_selector_plants = new GrowTypeSelector(
                TileActionLibrary.getGrowTypeRandomPlants
            );
            //Candle.addUnit(SA.fox, 2); //加入生物,前面是生物id，后面是生成占比
            Candle.addUnit("candle_genie", 4);//添加烛火之灵
            Candle.addMineral(SB.mineral_stone, 5); //加入矿物,前面是建筑id，后面是生成占比
            Candle.addMineral(SB.mineral_metals, 3);
            Candle.addTree("Candle_tree", 1); //加入树,前面是建筑id，后面是生成占比
            Candle.addPlant("Candle", 1); //加入植物,前面是建筑id，后面是生成占比
            AssetManager.biome_library.add(Candle);
            AssetManager.biome_library.addBiomeToPool(Candle);

            TopTileType Candle_low = AssetManager.topTiles.clone(
                "Candle_low",
                ST.mushroom_low
            ); //地块代码
            Candle_low.color = Toolbox.makeColor("#fbda8e", -1f); //颜色代码
            Candle_low.setBiome("biome_Candle");
            Candle_low.force_unit_skin_set = "enchanted";
            Candle_low.rank_type = TileRank.Low;
            Candle_low.setDrawLayer(TileZIndexes.mushroom_low, null);
            Candle_low.stepAction = new TileStepAction(Candle_1); //该群系的特殊事件
            Candle_low.stepActionChance = 1437f; //事件发生概率， 这里是指概率143700%
            Candle_low.fireChance = 0.02f; //燃烧概率
            Candle_low.food_resource = SR.mushrooms;
            Candle_low.biome_asset = Candle;
            AssetManager.topTiles.add(Candle_low);
            AssetManager.topTiles.loadSpritesForTile(Candle_low);

            TopTileType Candle_high = AssetManager.topTiles.clone(
                "Candle_high",
                ST.mushroom_high
            );
            Candle_high.color = Toolbox.makeColor("#fac959", -1f); //颜色代码
            Candle_high.setBiome("biome_Candle");
            Candle_high.rank_type = TileRank.High;
            Candle_high.force_unit_skin_set = "enchanted";
            Candle_high.setDrawLayer(TileZIndexes.mushroom_high, null);
            Candle_high.stepActionChance = 1437f;
            Candle_high.fireChance = 0.02f;
            Candle_high.food_resource = SR.mushrooms;
            Candle_high.biome_asset = Candle;
            Candle_high.stepAction = tempHighIntelligence; //智慧BUFF
            AssetManager.topTiles.add(Candle_high);
            AssetManager.topTiles.loadSpritesForTile(Candle_high);
//------墓地群系
            BiomeAsset Cemetery = new BiomeAsset(); //新版本群系的代码独立了出来，不过总体功能没啥变化
            Cemetery.id = "biome_Cemetery";
            Cemetery.tile_low = "Cemetery_low"; //低块
            Cemetery.tile_high = "Cemetery_high"; //高块
            Cemetery.grow_strength = 2; //群系的扩张强度
            Cemetery.spread_biome = true;
            Cemetery.generator_pool_amount = 4; //对地图生成的影响，这个值越大该群系生成概率越高
            Cemetery.force_unit_skin_set = "mushroom";
            Cemetery.grow_vegetation_auto = true;
            Cemetery.grow_type_selector_minerals = new GrowTypeSelector(
                TileActionLibrary.getGrowTypeRandomMineral
            );
            Cemetery.grow_type_selector_trees = new GrowTypeSelector(
                TileActionLibrary.getGrowTypeRandomTrees
            );
            Cemetery.grow_type_selector_plants = new GrowTypeSelector(
                TileActionLibrary.getGrowTypeRandomPlants
            );
            //Cemetery.addUnit(SA.fox, 2); //加入生物,前面是生物id，后面是生成占比
            Cemetery.addUnit("ghost_fire", 4);//添加鬼火之灵
            Cemetery.addMineral(SB.mineral_stone, 5); //加入矿物,前面是建筑id，后面是生成占比
            Cemetery.addMineral(SB.mineral_metals, 3);
            Cemetery.addTree("Cemetery_tree", 1); //加入树,前面是建筑id，后面是生成占比
            Cemetery.addPlant("Cemetery", 1); //加入植物,前面是建筑id，后面是生成占比
            AssetManager.biome_library.add(Cemetery);
            AssetManager.biome_library.addBiomeToPool(Cemetery);

            TopTileType Cemetery_low = AssetManager.topTiles.clone(
                "Cemetery_low",
                ST.mushroom_low
            ); //地块代码
            Cemetery_low.color = Toolbox.makeColor("#757a81", -1f); //颜色代码
            Cemetery_low.setBiome("biome_Cemetery");
            Cemetery_low.force_unit_skin_set = "enchanted";
            Cemetery_low.rank_type = TileRank.Low;
            Cemetery_low.setDrawLayer(TileZIndexes.mushroom_low, null);
            Cemetery_low.stepAction = new TileStepAction(Cemetery_1); //该群系的特殊事件
            Cemetery_low.stepActionChance = 1437f; //事件发生概率， 这里是指概率143700%
            Cemetery_low.fireChance = 0.02f; //燃烧概率
            Cemetery_low.food_resource = SR.mushrooms;
            Cemetery_low.biome_asset = Cemetery;
            AssetManager.topTiles.add(Cemetery_low);
            AssetManager.topTiles.loadSpritesForTile(Cemetery_low);

            TopTileType Cemetery_high = AssetManager.topTiles.clone(
                "Cemetery_high",
                ST.mushroom_high
            );
            Cemetery_high.color = Toolbox.makeColor("#4d5762", -1f); //颜色代码
            Cemetery_high.setBiome("biome_Cemetery");
            Cemetery_high.rank_type = TileRank.High;
            Cemetery_high.force_unit_skin_set = "enchanted";
            Cemetery_high.setDrawLayer(TileZIndexes.mushroom_high, null);
            Cemetery_high.stepActionChance = 1437f;
            Cemetery_high.fireChance = 0.02f;
            Cemetery_high.food_resource = SR.mushrooms;
            Cemetery_high.biome_asset = Cemetery;
            Cemetery_high.stepAction = tempHighIntelligence; //智慧BUFF
            AssetManager.topTiles.add(Cemetery_high);
            AssetManager.topTiles.loadSpritesForTile(Cemetery_high);
            //------蕨类群系
            BiomeAsset Fern = new BiomeAsset(); //新版本群系的代码独立了出来，不过总体功能没啥变化
            Fern.id = "biome_Fern";
            Fern.tile_low = "Fern_low"; //低块
            Fern.tile_high = "Fern_high"; //高块
            Fern.grow_strength = 2; //群系的扩张强度
            Fern.spread_biome = true;
            Fern.generator_pool_amount = 4; //对地图生成的影响，这个值越大该群系生成概率越高
            Fern.force_unit_skin_set = "mushroom";
            Fern.grow_vegetation_auto = true;
            Fern.grow_type_selector_minerals = new GrowTypeSelector(
                TileActionLibrary.getGrowTypeRandomMineral
            );
            Fern.grow_type_selector_trees = new GrowTypeSelector(
                TileActionLibrary.getGrowTypeRandomTrees
            );
            Fern.grow_type_selector_plants = new GrowTypeSelector(
                TileActionLibrary.getGrowTypeRandomPlants
            );
            //Fern.addUnit(SA.fox, 2); //加入生物,前面是生物id，后面是生成占比
            Fern.addMineral(SB.mineral_stone, 5); //加入矿物,前面是建筑id，后面是生成占比
            Fern.addMineral(SB.mineral_metals, 3);
            Fern.addTree("Fern_tree", 1); //加入树,前面是建筑id，后面是生成占比
            Fern.addPlant("Fern", 1); //加入植物,前面是建筑id，后面是生成占比
            AssetManager.biome_library.add(Fern);
            AssetManager.biome_library.addBiomeToPool(Fern);

            TopTileType Fern_low = AssetManager.topTiles.clone(
                "Fern_low",
                ST.mushroom_low
            ); //地块代码
            Fern_low.color = Toolbox.makeColor("#7fb34e", -1f); //颜色代码
            Fern_low.setBiome("biome_Fern");
            Fern_low.force_unit_skin_set = "enchanted";
            Fern_low.rank_type = TileRank.Low;
            Fern_low.setDrawLayer(TileZIndexes.mushroom_low, null);
            Fern_low.stepAction = new TileStepAction(Fern_1); //该群系的特殊事件
            Fern_low.stepActionChance = 1437f; //事件发生概率， 这里是指概率143700%
            Fern_low.fireChance = 0.02f; //燃烧概率
            Fern_low.food_resource = SR.mushrooms;
            Fern_low.biome_asset = Fern;
            AssetManager.topTiles.add(Fern_low);
            AssetManager.topTiles.loadSpritesForTile(Fern_low);

            TopTileType Fern_high = AssetManager.topTiles.clone(
                "Fern_high",
                ST.mushroom_high
            );
            Fern_high.color = Toolbox.makeColor("#44733f", -1f); //颜色代码
            Fern_high.setBiome("biome_Fern");
            Fern_high.rank_type = TileRank.High;
            Fern_high.force_unit_skin_set = "enchanted";
            Fern_high.setDrawLayer(TileZIndexes.mushroom_high, null);
            Fern_high.stepActionChance = 1437f;
            Fern_high.fireChance = 0.02f;
            Fern_high.food_resource = SR.mushrooms;
            Fern_high.biome_asset = Fern;
            AssetManager.topTiles.add(Fern_high);
            AssetManager.topTiles.loadSpritesForTile(Fern_high);
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
        public static bool Dark_1(WorldTile pTile, ActorBase pActor) //事件代码,我这里全删了
        {
            return true;
        }
        public static bool Rice_1(WorldTile pTile, ActorBase pActor) //事件代码,我这里全删了
        {
            return true;
        }

        public static bool Knowledge_1(WorldTile pTile, ActorBase pActor) //事件代码,我这里全删了
        {
            return true;
        }
        
        public static bool Candle_1(WorldTile pTile, ActorBase pActor) //事件代码,我这里全删了
        {
            return true;
        }
                
        public static bool Cemetery_1(WorldTile pTile, ActorBase pActor) //事件代码,我这里全删了
        {
            return true;
        }
                        
        public static bool Fern_1(WorldTile pTile, ActorBase pActor) //事件代码,我这里全删了
        {
            return true;
        }
    }
}
