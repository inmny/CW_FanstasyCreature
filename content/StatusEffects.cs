using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CW_FantasyCreatures
{
    internal class StatusEffects
    {
        public static void init()
        {
            StatusEffect intelligent = new StatusEffect();
            intelligent.id = "intelligent"; // 状态id
            intelligent.name = "status_title_intelligent"; // 状态名称key
            intelligent.description = "status_description_intelligent"; // 状态描述key
            intelligent.duration = 10; // 默认持续时间
            intelligent.animated = false; // 是否显示动画
            intelligent.path_icon = "ui/Icons/iconGenius";
            intelligent.allow_timer_reset = true; // 允许计时器重置(即在addStatus时会覆盖剩余时间)
            intelligent.base_stats[S.intelligence] = 99; // 智力加99
            AssetManager.status.add(intelligent);
        }
    }
}
