using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cultivation_Way.Abstract;

namespace CW_FantasyCreatures.content
{
    internal class StatusEffects : ExtendedLibrary<StatusEffect, StatusEffects>
    {
        public static readonly StatusEffect intelligent;
        public static readonly StatusEffect huge_light;
        internal StatusEffects()
        {
            CreateStatusEffect(nameof(intelligent));
            t.name = "status_title_intelligent"; // 状态名称key
            t.description = "status_description_intelligent"; // 状态描述key
            t.duration = 10; // 默认持续时间
            t.animated = false; // 是否显示动画
            t.path_icon = "ui/Icons/iconGenius";
            t.allow_timer_reset = true; // 允许计时器重置(即在addStatus时会覆盖剩余时间)
            t.base_stats[S.intelligence] = 99; // 智力加99

            CreateStatusEffect(nameof(huge_light));
            t.name = "status_title_huge_light";
            t.description = "status_description_huge_light";
            t.duration = 86400;
            t.animated = false;
            t.path_icon = "ui/Icons/iconRi";
            t.allow_timer_reset = true;
            t.draw_light_area = true; // 绘制光照区域
            t.draw_light_size = 20; // 光照区域大小
        }
        private void CreateStatusEffect(string pID)
        {
            Add(new StatusEffect()
            {
                id = pID
            });
        }
    }
}
