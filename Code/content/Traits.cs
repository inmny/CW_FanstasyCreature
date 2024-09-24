using Cultivation_Way.Abstract;

namespace CW_FantasyCreatures.content;

class Traits : ExtendedLibrary<ActorTrait, Traits>
{
    public static readonly ActorTrait huge_light;
    public static readonly ActorTrait wolf_poison;
    public static readonly ActorTrait bloodsucker;

    internal Traits()
    {
        CreateTrait(nameof(huge_light));
        t.birth = 0;
        t.path_icon = "ui/Icons/iconRi";
        t.group_id = "special";
        t.special_effect_interval = 1;
        t.action_special_effect = (o, t) =>
        {
            if (!o.isAlive()) return false;
            o.addStatusEffect(nameof(StatusEffects.huge_light), 86400);
            return true;
        };
        CreateTrait(nameof(wolf_poison));
        t.birth = 0;
        t.path_icon = "ui/Icons/iconDamage";
        t.group_id = TraitGroup.acquired;
        CreateTrait(nameof(bloodsucker));
        t.birth = 0;
        t.path_icon = "ui/Icons/iconBloodsucker";
        t.group_id = TraitGroup.special;
        t.special_effect_interval = 1;
        t.action_special_effect += (o, t) =>
        {
            if (!o.isAlive()) return false;
            if (!World.world_era.overlay_sun) return false;

            o.addStatusEffect("burning");
            return true;
        };
    }

    private void CreateTrait(string pID)
    {
        Add(new ActorTrait()
        {
            id = pID
        });
    }
}