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

namespace CW_FantasyCreatures.content
{
    class Drops
    {
        public static bool callLoopBrush(WorldTile pTile, GodPower pPower)
        {
            AssetManager.powers.CallMethod("loopWithCurrentBrushPower", pTile, pPower);
            return true;
        }

        public static bool callSpawnDrops(WorldTile tTile, GodPower pPower)
        {
            AssetManager.powers.CallMethod("spawnDrops", tTile, pPower);
            return true;
        }

        public static void init()
        {
            //生成群系的Drop----珊瑚群系
            CreateDropAndPower(
                "spawnCoralDrop",
                "drops/Coral_drop",
                3f,
                new DropsAction(action_seeds_Coral),
                "spawnCoral_drops",
                0.01f,
                new PowerAction(callSpawnDrops),
                new PowerAction(callLoopBrush)
            );
            //生成群系的Drop----竹子群系
            CreateDropAndPower(
                "spawnBambooDrop",
                "drops/Bamboo_drop",
                3f,
                new DropsAction(action_seeds_Bamboo),
                "spawnBamboo_drops",
                0.01f,
                new PowerAction(callSpawnDrops),
                new PowerAction(callLoopBrush)
            );
            //生成群系的Drop----血肉群系
            CreateDropAndPower(
                "spawnFleshBloodDrop",
                "drops/FleshBlood_drop",
                3f,
                new DropsAction(action_seeds_FleshBlood),
                "spawnFleshBlood_drops",
                0.01f,
                new PowerAction(callSpawnDrops),
                new PowerAction(callLoopBrush)
            );
            //生成群系的Drop----巨橡群系
            CreateDropAndPower(
                "spawnOakDrop",
                "drops/Oak_drop",
                3f,
                new DropsAction(action_seeds_Oak),
                "spawnOak_drops",
                0.01f,
                new PowerAction(callSpawnDrops),
                new PowerAction(callLoopBrush)
            );
            //生成群系的Drop----泰坦群系
            CreateDropAndPower(
                "spawnTitansDrop",
                "drops/Titans_drop",
                3f,
                new DropsAction(action_seeds_Titans),
                "spawnTitans_drops",
                0.01f,
                new PowerAction(callSpawnDrops),
                new PowerAction(callLoopBrush)
            );
            //生成群系的Drop----黑暗群系
            CreateDropAndPower(
                "spawnDarkDrop",
                "drops/Dark_drop",
                3f,
                new DropsAction(action_seeds_Dark),
                "spawnDark_drops",
                0.01f,
                new PowerAction(callSpawnDrops),
                new PowerAction(callLoopBrush)
            );
            //生成群系的Drop----巨稻群系
            CreateDropAndPower(
                "spawnRiceDrop",
                "drops/Rice_drop",
                3f,
                new DropsAction(action_seeds_Rice),
                "spawnRice_drops",
                0.01f,
                new PowerAction(callSpawnDrops),
                new PowerAction(callLoopBrush)
            );
            //生成群系的Drop----知识群系
            CreateDropAndPower(
                "spawnKnowledgeDrop",
                "drops/Knowledge_drop",
                3f,
                new DropsAction(action_seeds_Knowledge),
                "spawnKnowledge_drops",
                0.01f,
                new PowerAction(callSpawnDrops),
                new PowerAction(callLoopBrush)
            );
            //生成群系的Drop----烛火群系
            CreateDropAndPower(
                "spawnCandleDrop",
                "drops/Candle_drop",
                3f,
                new DropsAction(action_seeds_Candle),
                "spawnCandle_drops",
                0.01f,
                new PowerAction(callSpawnDrops),
                new PowerAction(callLoopBrush)
            );
            //生成群系的Drop----墓地群系
            CreateDropAndPower(
                "spawnCemeteryDrop",
                "drops/Cemetery_drop",
                3f,
                new DropsAction(action_seeds_Cemetery),
                "spawnCemetery_drops",
                0.01f,
                new PowerAction(callSpawnDrops),
                new PowerAction(callLoopBrush)
            );
            //------
        }

        public static void CreateDropAndPower(
            string dropId,
            string texturePath,
            float fallingSpeed,
            DropsAction action,
            string powerId,
            float fallingChance,
            PowerAction clickAction,
            PowerAction brushAction
        )
        {
            // 创建新的 DropAsset
            DropAsset newDrop = AssetManager.drops.clone(dropId, "_spawn_building");
            newDrop.path_texture = texturePath;
            newDrop.fallingSpeed = fallingSpeed;
            newDrop.action_landed = action;
            AssetManager.drops.add(newDrop);

            // 创建新的 GodPower
            GodPower newPower = AssetManager.powers.clone(powerId, "_drops");
            newPower.name = powerId;
            newPower.dropID = dropId;
            newPower.fallingChance = fallingChance;
            newPower.click_power_action = clickAction;
            newPower.click_power_brush_action = brushAction;
        }

        //------
        public static void action_seeds_Coral(WorldTile pTile = null, string pDropID = null)
        {
            TopTileType WL2 = AssetManager.topTiles.get("Coral_low"); //这个群系的两个tile作为参数
            TopTileType WT2 = AssetManager.topTiles.get("Coral_high");
            DropsLibrary.useDropSeedOn(pTile, WL2, WT2);
            for (int i = 0; i < pTile.neighbours.Length; i++) //后面这段是扩大种子的效果范围的，删了其实也没什么影响，只是生成群系有些不方便
            {
                DropsLibrary.useDropSeedOn(pTile.neighbours[i], WL2, WT2);
            }
        }

        //-----
        public static void action_seeds_Bamboo(WorldTile pTile = null, string pDropID = null)
        {
            TopTileType WL2 = AssetManager.topTiles.get("Bamboo_low"); //这个群系的两个tile作为参数
            TopTileType WT2 = AssetManager.topTiles.get("Bamboo_high");
            DropsLibrary.useDropSeedOn(pTile, WL2, WT2);
            for (int i = 0; i < pTile.neighbours.Length; i++) //后面这段是扩大种子的效果范围的，删了其实也没什么影响，只是生成群系有些不方便
            {
                DropsLibrary.useDropSeedOn(pTile.neighbours[i], WL2, WT2);
            }
        }

        //-----
        public static void action_seeds_FleshBlood(WorldTile pTile = null, string pDropID = null)
        {
            TopTileType WL2 = AssetManager.topTiles.get("FleshBlood_low"); //这个群系的两个tile作为参数
            TopTileType WT2 = AssetManager.topTiles.get("FleshBlood_high");
            DropsLibrary.useDropSeedOn(pTile, WL2, WT2);
            for (int i = 0; i < pTile.neighbours.Length; i++) //后面这段是扩大种子的效果范围的，删了其实也没什么影响，只是生成群系有些不方便
            {
                DropsLibrary.useDropSeedOn(pTile.neighbours[i], WL2, WT2);
            }
        }

        //-----
        public static void action_seeds_Oak(WorldTile pTile = null, string pDropID = null)
        {
            TopTileType WL2 = AssetManager.topTiles.get("Oak_low"); //这个群系的两个tile作为参数
            TopTileType WT2 = AssetManager.topTiles.get("Oak_high");
            DropsLibrary.useDropSeedOn(pTile, WL2, WT2);
            for (int i = 0; i < pTile.neighbours.Length; i++) //后面这段是扩大种子的效果范围的，删了其实也没什么影响，只是生成群系有些不方便
            {
                DropsLibrary.useDropSeedOn(pTile.neighbours[i], WL2, WT2);
            }
        }

        //-----
        public static void action_seeds_Titans(WorldTile pTile = null, string pDropID = null)
        {
            TopTileType WL2 = AssetManager.topTiles.get("Titans_low"); //这个群系的两个tile作为参数
            TopTileType WT2 = AssetManager.topTiles.get("Titans_high");
            DropsLibrary.useDropSeedOn(pTile, WL2, WT2);
            for (int i = 0; i < pTile.neighbours.Length; i++) //后面这段是扩大种子的效果范围的，删了其实也没什么影响，只是生成群系有些不方便
            {
                DropsLibrary.useDropSeedOn(pTile.neighbours[i], WL2, WT2);
            }
        }
        //-----
        public static void action_seeds_Dark(WorldTile pTile = null, string pDropID = null)
        {
            TopTileType WL2 = AssetManager.topTiles.get("Dark_low"); //这个群系的两个tile作为参数
            TopTileType WT2 = AssetManager.topTiles.get("Dark_high");
            DropsLibrary.useDropSeedOn(pTile, WL2, WT2);
            for (int i = 0; i < pTile.neighbours.Length; i++) //后面这段是扩大种子的效果范围的，删了其实也没什么影响，只是生成群系有些不方便
            {
                DropsLibrary.useDropSeedOn(pTile.neighbours[i], WL2, WT2);
            }
        }
        //-----
        public static void action_seeds_Rice(WorldTile pTile = null, string pDropID = null)
        {
            TopTileType WL2 = AssetManager.topTiles.get("Rice_low"); //这个群系的两个tile作为参数
            TopTileType WT2 = AssetManager.topTiles.get("Rice_high");
            DropsLibrary.useDropSeedOn(pTile, WL2, WT2);
            for (int i = 0; i < pTile.neighbours.Length; i++) //后面这段是扩大种子的效果范围的，删了其实也没什么影响，只是生成群系有些不方便
            {
                DropsLibrary.useDropSeedOn(pTile.neighbours[i], WL2, WT2);
            }
        }

        //-----
        public static void action_seeds_Knowledge(WorldTile pTile = null, string pDropID = null)
        {
            TopTileType WL2 = AssetManager.topTiles.get("Knowledge_low"); //这个群系的两个tile作为参数
            TopTileType WT2 = AssetManager.topTiles.get("Knowledge_high");
            DropsLibrary.useDropSeedOn(pTile, WL2, WT2);
            for (int i = 0; i < pTile.neighbours.Length; i++) //后面这段是扩大种子的效果范围的，删了其实也没什么影响，只是生成群系有些不方便
            {
                DropsLibrary.useDropSeedOn(pTile.neighbours[i], WL2, WT2);
            }
        }
        
        //-----
        public static void action_seeds_Candle(WorldTile pTile = null, string pDropID = null)
        {
            TopTileType WL2 = AssetManager.topTiles.get("Candle_low"); //这个群系的两个tile作为参数
            TopTileType WT2 = AssetManager.topTiles.get("Candle_high");
            DropsLibrary.useDropSeedOn(pTile, WL2, WT2);
            for (int i = 0; i < pTile.neighbours.Length; i++) //后面这段是扩大种子的效果范围的，删了其实也没什么影响，只是生成群系有些不方便
            {
                DropsLibrary.useDropSeedOn(pTile.neighbours[i], WL2, WT2);
            }
        }
        //-----
        public static void action_seeds_Cemetery(WorldTile pTile = null, string pDropID = null)
        {
            TopTileType WL2 = AssetManager.topTiles.get("Cemetery_low"); //这个群系的两个tile作为参数
            TopTileType WT2 = AssetManager.topTiles.get("Cemetery_high");
            DropsLibrary.useDropSeedOn(pTile, WL2, WT2);
            for (int i = 0; i < pTile.neighbours.Length; i++) //后面这段是扩大种子的效果范围的，删了其实也没什么影响，只是生成群系有些不方便
            {
                DropsLibrary.useDropSeedOn(pTile.neighbours[i], WL2, WT2);
            }
        }
        //------
    }
}
