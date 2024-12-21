using ai;
using Cultivation_Way.Abstract;
using Cultivation_Way.Constants;
using Cultivation_Way.Core;
using Cultivation_Way.Extension;
using Cultivation_Way.Library;
using Cultivation_Way.Utils.General.AboutStatusEffect;
using NeoModLoader.api.attributes;

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
            t.duration = 10;    // 默认持续时间
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

            blood_mark = FormatStatusEffect.create_simple_status_effect(nameof(blood_mark), new BaseStats(),
                15f,
                path_icon: "ui/icons/iconBlood_Mars");
            blood_mark.action_interval = 1;
            blood_mark.action_on_update += [Hotfixable](pEffect, pSource, pTarget) =>
            {
                if (Toolbox.randomChance(0.99f)) return;
                var a = pTarget as CW_Actor;
                if (a == null || !a.isAlive() || !a.inMapBorder()) return;

                CW_Actor transformed = World.world.units.createNewUnit(nameof(Creatures.bloodsucker), a.currentTile)
                    .CW();
                if (transformed == null) return;
                EffectsLibrary.spawn(nameof(VanillaEffects.fx_spawn_red), transformed.currentTile);

                ActorTool.copyUnitToOtherUnit(a, transformed);
                transformed.data.SetSpells(a.data.GetSpells());

                check_and_copy_cultisys(CultisysType.WAKAN);
                check_and_copy_cultisys(CultisysType.SOUL);
                check_and_copy_cultisys(CultisysType.BODY);

                Cultibook cultibook = a.data.GetCultibook();
                if (cultibook != null)
                    transformed.data.SetCultibook(cultibook);

                a.killHimself(pType: AttackType.Transformation, pCountDeath: false, pDestroy: true);
                return;

                void check_and_copy_cultisys(CultisysType type)
                {
                    CultisysAsset cultisys = a.data.GetCultisys(type);
                    if (cultisys == null) return;
                    a.data.get(cultisys.id, out var level, -1);
                    if (level < 0) return;
                    transformed.data.set(type.ToString(), cultisys.id);
                    transformed.data.set(cultisys.id,     level);
                }
            };
        }

        public static CW_StatusEffect blood_mark { get; private set; }

        private void CreateStatusEffect(string pID)
        {
            Add(new StatusEffect()
            {
                id = pID
            });
        }
    }
}