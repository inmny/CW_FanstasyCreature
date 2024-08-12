using Cultivation_Way.Abstract;

public class Camps : ExtendedLibrary<KingdomAsset, Camps>
{
    /// <summary>
    /// 血族
    /// </summary>
    public static readonly KingdomAsset Vampire;

    /// <summary>
    /// 狼族
    /// </summary>
    public static readonly KingdomAsset Werewolf;

    /// <summary>
    /// 猎魔人
    /// </summary>
    public static readonly KingdomAsset Anti_vampire;

    /// <summary>
    /// 神圣
    /// </summary>
    public static readonly KingdomAsset Divine;

    /// <summary>
    /// 非凡之人
    /// </summary>
    public static readonly KingdomAsset Extraordinary;

    /// <summary>
    /// 亚人族
    /// </summary>
    public static readonly KingdomAsset Subhumans;

    /// <summary>
    /// 灵族
    /// </summary>
    public static readonly KingdomAsset Spirit;

    /// <summary>
    /// 食肉族
    /// </summary>
    public static readonly KingdomAsset Carnivore;

    /// <summary>
    /// 食草族
    /// </summary>
    public static readonly KingdomAsset Herbivore;

    /// <summary>
    /// 杂食族
    /// </summary>
    public static readonly KingdomAsset Omnivorous;

    /// <summary>
    /// 善树族
    /// </summary>
    public static readonly KingdomAsset Good_treants;

    /// <summary>
    /// 恶树族
    /// </summary>
    public static readonly KingdomAsset Evil_treants;

    /// <summary>
    /// 不死族
    /// </summary>
    public static readonly KingdomAsset Undead;

    /// <summary>
    /// 哥布林族
    /// </summary>
    public static readonly KingdomAsset Goblin;

    /// <summary>
    /// 善巨人族
    /// </summary>
    public static readonly KingdomAsset Good_giant;

    /// <summary>
    /// 恶巨人族
    /// </summary>
    public static readonly KingdomAsset Evil_giant;

    internal Camps()
    {
        CreateCamp(nameof(Vampire));           //血族阵营
        t.mobs = true;                         //nature(完全友善)，mobs(怪物)，mad（疯狂），attack_each_other（互相攻击）
        t.addTag(nameof(Vampire));             //血族标签
        t.addFriendlyTag(nameof(Vampire));     //对血族标签友好
        AllEnemyWith(nameof(Vampire), SK.civ); // 所有文明阵营都会主动攻击吸血鬼，civ（公民）
        t.addEnemyTag(nameof(Anti_vampire));   //对猎魔人敌对

        CreateCamp(nameof(Werewolf));          //狼人阵营
        t.mobs = true;                         //nature(完全友善)，mobs(怪物)，mad（疯狂），attack_each_other（互相攻击）
        t.addTag(nameof(Werewolf));            //狼人标签
        t.addFriendlyTag(nameof(Werewolf));    //对狼人标签友好
        AllEnemyWith(nameof(Vampire), SK.civ); // 所有文明阵营都会主动攻击吸血鬼，civ（公民）
        t.addEnemyTag(nameof(Vampire));        //对吸血鬼敌对
        t.addEnemyTag(nameof(Anti_vampire));   //对猎魔人敌对

        CreateCamp(nameof(Anti_vampire)); //猎魔人
        t.addTag(nameof(Anti_vampire));
        t.addTag(SK.neutral);           //中立
        t.addFriendlyTag(SK.neutral);   //对中立标签友好
        t.addFriendlyTag(SK.civ);       //对中立标签友好
        t.addEnemyTag(nameof(Vampire)); //对吸血鬼敌对
        t.addEnemyTag(nameof(Vampire)); //对狼人敌对

        CreateCamp(nameof(Divine));        //神兽阵营
        t.addTag(nameof(Divine));          //神兽标签
        t.addTag(SK.neutral);              //中立
        t.addFriendlyTag(nameof(Divine));  //对神兽标签友好
        t.addEnemyTag("yao");              //对妖族标签敌对
        t.addEnemyTag("ming");             //对妖族标签敌对
        t.addFriendlyTag("eastern_human"); //对东人标签友好

        CreateCamp(nameof(Extraordinary));       //非凡之人阵营
        t.addTag(nameof(Extraordinary));         //非凡之人标签
        t.addTag(SK.neutral);                    //中立
        t.addFriendlyTag(nameof(Extraordinary)); //对非凡之人标签友好
        t.addFriendlyTag("human");               //对人类标签友好
        t.addEnemyTag("Orcs");                   //对兽人标签敌对

        CreateCamp(nameof(Subhumans));       //亚人阵营
        t.addTag(nameof(Subhumans));         //亚人标签
        t.addTag(SK.neutral);                //中立
        t.addFriendlyTag(nameof(Subhumans)); //对亚人标签友好
        t.addEnemyTag("Orcs");               //对兽人标签敌对
        t.addFriendlyTag("elf");             //对精灵标签友好
        t.addFriendlyTag("Herbivore");       //对食草标签友好

        CreateCamp(nameof(Spirit));       //灵族阵营
        t.nature = true;                  //nature(完全友善)，mobs(怪物)，mad（疯狂），attack_each_other（互相攻击）
        t.addTag(nameof(Spirit));         //灵族标签
        t.addFriendlyTag(nameof(Spirit)); //对灵族标签友好

        CreateCamp(nameof(Carnivore));       //食肉族阵营
        t.mobs = true;                       //nature(完全友善)，mobs(怪物)，mad（疯狂），attack_each_other（互相攻击）
        t.addTag(nameof(Carnivore));         //食肉族标签
        t.addFriendlyTag(nameof(Carnivore)); //对食肉族标签友好
        t.addFriendlyTag("elf");             //对精灵标签友好
        t.addEnemyTag("Herbivore");          //对食草标签敌对
        t.addEnemyTag("Omnivorous");         //对杂食标签敌对

        CreateCamp(nameof(Herbivore));       //食草族阵营
        t.addTag(SK.neutral);                //中立
        t.addTag(nameof(Herbivore));         //食草族标签
        t.addFriendlyTag(nameof(Herbivore)); //对食草族标签友好
        t.addFriendlyTag("elf");             //对精灵标签友好
        t.addEnemyTag("Carnivore");          //对食肉标签敌对
        t.addEnemyTag("Omnivorous");         //对杂食标签敌对

        CreateCamp(nameof(Omnivorous));       //杂食族阵营
        t.mobs = true;                        //nature(完全友善)，mobs(怪物)，mad（疯狂），attack_each_other（互相攻击）
        t.addTag(nameof(Omnivorous));         //杂食族标签
        t.addFriendlyTag(nameof(Omnivorous)); //对杂食族标签友好
        t.addFriendlyTag("elf");              //对精灵标签友好
        t.addEnemyTag("Carnivore");           //对食肉标签敌对
        t.addEnemyTag("Herbivore");           //对食草标签敌对

        CreateCamp(nameof(Good_treants));       //善树族阵营
        t.addTag(SK.neutral);                   //中立
        t.addTag(nameof(Good_treants));         //善树族标签
        t.addFriendlyTag(nameof(Good_treants)); //对善树族标签友好
        t.addFriendlyTag("elf");                //对精灵标签友好
        t.addEnemyTag("human");                 //对人类标签敌对
        t.addEnemyTag("Orcs");                  //对兽人标签敌对
        t.addEnemyTag("dwarf");                 //对矮人标签敌对

        CreateCamp(nameof(Evil_treants));       //恶树族阵营
        t.mobs = true;                          //nature(完全友善)，mobs(怪物)，mad（疯狂），attack_each_other（互相攻击）
        t.addTag(nameof(Evil_treants));         //恶树族标签
        t.addFriendlyTag(nameof(Evil_treants)); //对恶树族标签友好

        CreateCamp(nameof(Good_giant));       //善巨人族阵营
        t.addTag(SK.neutral);                 //中立
        t.addTag(nameof(Good_giant));         //善巨人族标签
        t.addFriendlyTag(nameof(Good_giant)); //对善巨人族标签友好
        t.addFriendlyTag("dwarf");            //对矮人标签友好
        t.addEnemyTag("elf");                 //对精灵标签敌对
        t.addEnemyTag("human");               //对人类标签敌对
        t.addEnemyTag("Orcs");                //对兽人标签敌对

        CreateCamp(nameof(Evil_giant));       //恶巨人族阵营
        t.mobs = true;                        //nature(完全友善)，mobs(怪物)，mad（疯狂），attack_each_other（互相攻击）
        t.addTag(nameof(Evil_giant));         //恶巨人族标签
        t.addFriendlyTag(nameof(Evil_giant)); //对恶巨人族标签友好

        CreateCamp(nameof(Undead));       //不死族阵营
        t.mobs = true;                    //nature(完全友善)，mobs(怪物)，mad（疯狂），attack_each_other（互相攻击）
        t.addTag(nameof(Undead));         //不死族标签
        t.addFriendlyTag(nameof(Undead)); //对不死族标签友好

        CreateCamp(nameof(Goblin));       //哥布林族阵营
        t.addTag(SK.neutral);             //中立
        t.addTag(nameof(Goblin));         //哥布林标签
        t.addFriendlyTag(nameof(Goblin)); //对哥布林族标签友好
        t.addFriendlyTag(SK.orc);         //对兽人标签友好
        t.addEnemyTag("human");           //对人类标签敌对
        t.addEnemyTag("elf");             //对兽人标签敌对
        t.addEnemyTag("dwarf");           //对矮人标签敌对
        AllFriendWith(nameof(Goblin), SK.orc);
    }

    internal void CreateCamp(string pID)
    {
        Add(new KingdomAsset()
        {
            id = pID
        });
        if (World.world.kingdoms.dict_hidden.ContainsKey(pID)) return;

        World.world.kingdoms.newHiddenKingdom(t);
    }

    /// <summary>
    /// 为拥有所有<paramref name="pIfHasTags"/>标签的阵营对<paramref name="pTag"/>标签友好
    /// </summary>
    internal void AllFriendWith(string pTag, params string[] pIfHasTags)
    {
        // 等新版本NML出来后再换成ForEach
        foreach (var camp in cached_library.list)
        {
            if (camp.list_tags.IsSupersetOf(pIfHasTags))
            {
                camp.addFriendlyTag(pTag);
            }
        }
    }

    /// <summary>
    /// 为拥有所有<paramref name="pIfHasTags"/>标签的阵营对<paramref name="pTag"/>标签敌对
    /// </summary>
    internal void AllEnemyWith(string pTag, params string[] pIfHasTags)
    {
        // 等新版本NML出来后再换成ForEach
        foreach (var camp in cached_library.list)
        {
            if (camp.list_tags.IsSupersetOf(pIfHasTags))
            {
                camp.addEnemyTag(pTag);
            }
        }
    }
}