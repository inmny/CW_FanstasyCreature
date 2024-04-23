using Cultivation_Way.Abstract;

namespace CW_FantasyCreatures.content;

class Traits : ExtendedLibrary<ActorTrait, Traits>
{
    public static readonly StatusEffect huge_light;

    internal Traits()
    {
        CreateTrait(nameof(huge_light));
        t.birth = 0;
        t.path_icon = "ui/Icons/iconGenius";
        t.group_id = "special";
        t.special_effect_interval = 1;
        t.action_special_effect = (o, t) =>{
            if (!o.isAlive()) return false;
            o.addStatusEffect(nameof(StatusEffects.huge_light), 86400);
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