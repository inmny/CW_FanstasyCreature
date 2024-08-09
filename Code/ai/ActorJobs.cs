using CW_FantasyCreatures.ai.cond;

namespace CW_FantasyCreatures.ai;

class ActorJobs : ExtendedLibrary<ActorJob>
{
    public static readonly ActorJob goblin_shaman;
    public static readonly ActorJob goblin_warrior;

    protected override void Init()
    {
        add(new() { id = nameof(goblin_shaman) });
        t.addTask(nameof(ActorTasks.goblin_shaman_find_attack_target));
        t.addCondition(new CondGoblinGroupFull());
        t.addTask(nameof(ActorTasks.goblin_shaman_follow_behind));
        t.addCondition(new CondGoblinGroupFull());
        t.addTask(nameof(ActorTasks.goblin_shaman_goback_tower));
        t.addCondition(new CondGoblinGroupResidual());
        t.addTask(nameof(ActorTasks.goblin_shaman_walk_around_tower));
        t.addCondition(new CondGoblinGroupFull(), false);
        t.addTask(nameof(ActorTasks.goblin_shaman_walk_around_tower));
        t.addCondition(new CondGoblinGotoAttack(), false);
        t.addTask(nameof(ActorTasks.random_move));
        t.addCondition(new CondGoblinHasHome(), false);

        add(new() { id = nameof(goblin_warrior) });
        t.addTask(nameof(ActorTasks.goblin_warrior_follow_behind));
        t.addCondition(new CondGoblinGroupResidual());
        t.addCondition(new CondGoblinGotoAttack());
        t.addTask(nameof(ActorTasks.goblin_warrior_walk_around_tower));
        t.addCondition(new CondGoblinGroupFull(), false);
        t.addTask(nameof(ActorTasks.goblin_warrior_walk_around_tower));
        t.addCondition(new CondGoblinGotoAttack(), false);
        t.addTask(nameof(ActorTasks.random_move));
        t.addCondition(new CondGoblinHasHome(), false);
    }
}