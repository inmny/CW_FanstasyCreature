using ai.behaviours;
using CW_FantasyCreatures.ai.beh;

namespace CW_FantasyCreatures.ai;

class ActorTasks : ExtendedLibrary<BehaviourTaskActor>
{
    public static readonly BehaviourTaskActor goblin_shaman_walk_around_tower;
    public static readonly BehaviourTaskActor goblin_shaman_find_attack_target;
    public static readonly BehaviourTaskActor goblin_shaman_follow_behind;
    public static readonly BehaviourTaskActor goblin_shaman_goback_tower;

    public static readonly BehaviourTaskActor goblin_warrior_follow_behind;
    public static readonly BehaviourTaskActor goblin_warrior_goto_attack_target;
    public static readonly BehaviourTaskActor goblin_warrior_walk_around_tower;

    public static readonly BehaviourTaskActor random_move;

    protected override void Init()
    {
        add(new() { id = nameof(goblin_shaman_goback_tower) });
        t.addBeh(new BehActorFindHome());
        t.addBeh(new BehGoToBuildingTarget(true));
        add(new() { id = nameof(goblin_shaman_find_attack_target) });
        t.addBeh(new BehGoblinFindAttackCity());
        t.addBeh(new BehGoblinSelectMembers());
        t.addBeh(new BehGoblinCheckAttack());
        add(new() { id = nameof(goblin_shaman_follow_behind) });
        t.addBeh(new BehGoblinFindTileNearbyWarrior());
        t.addBeh(new BehGoblinRestoreHealth());
        t.addBeh(new BehGoToTileTarget());
        add(new() { id = nameof(goblin_shaman_walk_around_tower) });
        t.addBeh(new BehGoblinUnselectMemers());
        t.addBeh(new BehGoblinTowerGetRandomZoneTile());
        t.addBeh(new BehGoToTileTarget());
        t.addBeh(new BehGoblinRestoreHealth());
        t.addBeh(new BehRandomWait(3f, 6f));

        add(new() { id = nameof(goblin_warrior_goto_attack_target) });
        t.addBeh(new BehGoToTileTarget());
        ((BehGoToTileTarget)t.list.Last()).walkOnWater = true;
        add(new() { id = nameof(goblin_warrior_follow_behind) });
        t.addBeh(new BehGoblinFindTileNearbyShaman());
        t.addBeh(new BehGoToTileTarget());
        add(new() { id = nameof(goblin_warrior_walk_around_tower) });
        t.addBeh(new BehGoblinTowerGetRandomZoneTile());
        t.addBeh(new BehGoToTileTarget());
        t.addBeh(new BehRandomWait(3f, 6f));
    }
}