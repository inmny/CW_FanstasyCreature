using System;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NCMS;
using NCMS.Utils;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using ReflectionUtility;
using Cultivation_Way.UI;
using NeoModLoader.General;

namespace CW_FantasyCreatures.ui
{
    class TabManager
    {
        private static PowersTab tab;
        public static void init()
        {
            tab = NeoModLoader.General.UI.Tab.TabManager.CreateTab("Biome", "Biome Title", "Biome Description", Sprites.LoadSprite($"{Mod.Info.Path}/icon.png"));
            loadButtons();
        }
        public static void AddBuildingDropButton(string power_id, string power_name, string building_id){
            GodPower power = null;
            DropAsset drop = null;
            power = AssetManager.powers.clone(power_id, "_dropBuilding");
            power.dropID = power.id;
            power.name = power_name;
            power.click_power_action = AssetManager.powers.spawnDrops;
            drop = AssetManager.drops.clone(power.id, "_spawn_building");
            drop.building_asset = building_id;
            drop.action_landed = DropsLibrary.action_spawn_building;

            CWTab.add_button(
                PowerButtonCreator.CreateGodPowerButton(power.id, 
                    SpriteTextureLoader.getSprite($"ui/icons/icon{building_id}")), 
                Cultivation_Way.Constants.ButtonContainerType.BUILDING
            );
        }

        private static void loadButtons()
        {
            int index = 1;
            int xPos = 72 + 9;
            int yPos = 18;
            int gap = 35;
            
            PowerButtons.CreateButton(
                "spawnCoral_drops",
                Mod.EmbededResources.LoadSprite($"{Mod.Info.Name}.Resources.tile_0.png"),
                "珊瑚种子",
                "陆地上的珊瑚？长腿的鱼？",
                new Vector2(xPos + (index * gap), yPos),
                ButtonType.GodPower,
                tab.transform,
                null
            );
            index++;
            PowerButtons.CreateButton(
                "spawnBamboo_drops",
                Mod.EmbededResources.LoadSprite($"{Mod.Info.Name}.Resources.tile_1.png"),
                "竹林种子",
                "不正经的草？黑白的熊？",
                new Vector2(xPos + (index * gap), yPos),
                ButtonType.GodPower,
                tab.transform,
                null
            );
            index++;
            PowerButtons.CreateButton(
                "spawnFleshBlood_drops",
                Mod.EmbededResources.LoadSprite($"{Mod.Info.Name}.Resources.tile_2.png"),
                "血肉种子",
                "鲜血和肉的世界！疯狂！",
                new Vector2(xPos + (index * gap), yPos),
                ButtonType.GodPower,
                tab.transform,
                null
            );
            index++;
            PowerButtons.CreateButton(
                "spawnOak_drops",
                Mod.EmbededResources.LoadSprite($"{Mod.Info.Name}.Resources.tile_3.png"),
                "巨橡种子",
                "撑天的巨大橡木！巨树！",
                new Vector2(xPos + (index * gap), yPos),
                ButtonType.GodPower,
                tab.transform,
                null
            );
            index++;
            PowerButtons.CreateButton(
                "spawnTitans_drops",
                Mod.EmbededResources.LoadSprite($"{Mod.Info.Name}.Resources.tile_4.png"),
                "泰坦种子",
                "倒下的泰坦巨人！遗迹！",
                new Vector2(xPos + (index * gap), yPos),
                ButtonType.GodPower,
                tab.transform,
                null
            );
            index++;
            PowerButtons.CreateButton(
                "spawnKnowledge_drops",
                Mod.EmbededResources.LoadSprite($"{Mod.Info.Name}.Resources.tile_5.png"),
                "知识种子",
                "知识就是力量！学习！",
                new Vector2(xPos + (index * gap), yPos),
                ButtonType.GodPower,
                tab.transform,
                null
            );
            index++;
            PowerButtons.CreateButton(
                "spawnDark_drops",
                Mod.EmbededResources.LoadSprite($"{Mod.Info.Name}.Resources.tile_6.png"),
                "黑暗种子",
                "充斥着阴谋与杀戮的森林！黑暗！",
                new Vector2(xPos + (index * gap), yPos),
                ButtonType.GodPower,
                tab.transform,
                null
            );
            index++;
                PowerButtons.CreateButton(
                "spawnRice_drops",
                Mod.EmbededResources.LoadSprite($"{Mod.Info.Name}.Resources.tile_7.png"),
                "巨稻种子",
                "高大的稻谷，禾下乘凉！富足！",
                new Vector2(xPos + (index * gap), yPos),
                ButtonType.GodPower,
                tab.transform,
                null
            );
            index++;
            
                PowerButtons.CreateButton(
                "spawnCandle_drops",
                Mod.EmbededResources.LoadSprite($"{Mod.Info.Name}.Resources.tile_8.png"),
                "烛火种子",
                "驱散黑暗，带来光明！希望！",
                new Vector2(xPos + (index * gap), yPos),
                ButtonType.GodPower,
                tab.transform,
                null
            );
            index++;
        }
    }
}
