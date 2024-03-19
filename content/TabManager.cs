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

namespace CW_FantasyCreatures
{
    class TabManager
    {
        private static PowersTab tab;
        public static void init()
        {
            tab = NeoModLoader.General.UI.Tab.TabManager.CreateTab("Biome", "Biome Title", "Biome Description", Sprites.LoadSprite($"{Mod.Info.Path}/icon.png"));
            loadButtons();
        }

        private static void loadButtons()
        {
            int index = 0;
            int xPos = 72;
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
        }
    }
}
