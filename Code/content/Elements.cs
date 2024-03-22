using Cultivation_Way.Abstract;
using Cultivation_Way.Constants;
using Cultivation_Way.Library;

namespace CW_FantasyCreatures.content;

internal class Elements : ExtendedLibrary<ElementAsset, Elements>
{
    
    public static readonly ElementAsset cw_lightning;//雷灵根
    public static readonly ElementAsset cw_wind;//风灵根
    public static readonly ElementAsset cw_dark;//暗灵根
    public static readonly ElementAsset cw_light;//光灵根
    public static readonly ElementAsset cw_sun;//日灵根
    public static readonly ElementAsset cw_month;//月灵根
    public static readonly ElementAsset cw_star;//星灵根
    public static readonly ElementAsset cw_ice;//冰灵根
    public static readonly ElementAsset cw_blood;//血灵根
    public static readonly ElementAsset cw_time;//时间灵根
    public static readonly ElementAsset cw_space;//空间灵根
    public static readonly ElementAsset cw_rain;//雨灵根

    internal Elements()//promot 强化系数、rarity 稀有度
    {
        CreateElement("cw_lightning", 20, 20, 10, 40, 10, 2f, 2f);//雷灵根
        t.base_stats[S.mod_damage] = 1f;//攻击100%
        t.base_stats[CW_S.mod_cultivelo] = 0.5f;//修炼速度50%

        CreateElement("cw_wind", 20, 20, 40, 10, 10, 2f, 2f);//风灵根
        t.base_stats[S.mod_damage] = 1f;//攻击100%
        t.base_stats[CW_S.mod_cultivelo] = 0.5f;//修炼速度50%
        
        CreateElement("cw_dark", 40, 5, 10, 5, 40, 7f, 7f);//暗灵根
        t.base_stats[S.mod_damage] = 1f;//攻击100%
        t.base_stats[CW_S.mod_cultivelo] = 0.5f;//修炼速度50%
        
        CreateElement("cw_light", 10, 40, 5, 40, 5, 7f, 7f);//光灵根
        t.base_stats[S.mod_damage] = 1f;//攻击100%
        t.base_stats[CW_S.mod_cultivelo] = 0.5f;//修炼速度50%
        
        CreateElement("cw_sun", 15, 40, 15, 15, 15, 6f, 6f);//日灵根
        t.base_stats[S.mod_damage] = 1f;//攻击100%
        t.base_stats[CW_S.mod_cultivelo] = 0.5f;//修炼速度50%
        
        CreateElement("cw_month", 40, 15, 15, 15, 15, 5f, 5f);//月灵根
        t.base_stats[S.mod_damage] = 1f;//攻击100%
        t.base_stats[CW_S.mod_cultivelo] = 0.5f;//修炼速度50%
        
        CreateElement("cw_star", 15, 15, 15, 40, 15, 4f, 4f);//星灵根
        t.base_stats[S.mod_damage] = 1f;//攻击100%
        t.base_stats[CW_S.mod_cultivelo] = 0.5f;//修炼速度50%
        
        CreateElement("cw_ice", 80, 5, 5, 5, 5, 2f, 2f);//冰灵根
        t.base_stats[S.mod_damage] = 1f;//攻击100%
        t.base_stats[CW_S.mod_cultivelo] = 0.5f;//修炼速度50%
        
        CreateElement("cw_blood", 40, 10, 40, 5, 5, 2f, 2f);//血灵根
        t.base_stats[S.mod_damage] = 1f;//攻击100%
        t.base_stats[CW_S.mod_cultivelo] = 0.5f;//修炼速度50%
        
        CreateElement("cw_time", 15, 30, 20, 30, 15, 9f, 9f);//时间灵根
        t.base_stats[S.mod_damage] = 1f;//攻击100%
        t.base_stats[CW_S.mod_cultivelo] = 2f;//修炼速度200%
        
        CreateElement("cw_space", 25, 15, 20, 15, 25, 9f, 9f);//空间灵根
        t.base_stats[S.mod_damage] = 1f;//攻击100%
        t.base_stats[CW_S.mod_cultivelo] = 2f;//修炼速度200%
                
        CreateElement("cw_rain", 25, 15, 25, 10, 25, 2f, 2f);//雨灵根
        t.base_stats[S.mod_damage] = 1f;//攻击100%
        t.base_stats[CW_S.mod_cultivelo] = 0.5f;//修炼速度50%
        
        CreateElement("cw_sky", 30, 30, 10, 20, 10, 8f, 8f);//天灵根

        t.base_stats[S.mod_damage] = 1f;//攻击100%
        t.base_stats[CW_S.mod_cultivelo] = 0.5f;//修炼速度50%
                
        CreateElement("cw_earth", 25, 20, 10, 15, 30, 2f, 2f);//地灵根
        t.base_stats[S.mod_damage] = 1f;//攻击100%
        t.base_stats[CW_S.mod_cultivelo] = 0.5f;//修炼速度50%
                        
        CreateElement("cw_rock", 30, 15, 10, 20, 25, 2f, 2f);//岩灵根
        t.base_stats[S.mod_damage] = 1f;//攻击100%
        t.base_stats[CW_S.mod_cultivelo] = 0.5f;//修炼速度50%
                                
        CreateElement("cw_sand", 10, 30, 10, 20, 30, 2f, 2f);//沙灵根
        t.base_stats[S.mod_damage] = 1f;//攻击100%
        t.base_stats[CW_S.mod_cultivelo] = 0.5f;//修炼速度50%
                                        
        CreateElement("cw_grass", 30, 10, 30, 10, 20, 2f, 2f);//草灵根
        t.base_stats[S.mod_damage] = 1f;//攻击100%
        t.base_stats[CW_S.mod_cultivelo] = 0.5f;//修炼速度50%
                                        
        CreateElement("cw_pills", 20, 30, 30, 10, 10, 3f, 3f);//丹灵根
        t.base_stats[S.mod_damage] = 1f;//攻击100%
        t.base_stats[CW_S.mod_cultivelo] = 0.5f;//修炼速度50%
                                        
        CreateElement("cw_water", 80, 5, 5, 5, 5, 1f, 1f);//水灵根
        t.base_stats[S.mod_damage] = 1f;//攻击100%
        t.base_stats[CW_S.mod_cultivelo] = 0.5f;//修炼速度50%
                                        
        CreateElement("cw_fire", 5, 80, 5, 5, 5, 1f, 1f);//火灵根
        t.base_stats[S.mod_damage] = 1f;//攻击100%
        t.base_stats[CW_S.mod_cultivelo] = 0.5f;//修炼速度50%
                                        
        CreateElement("cw_wood", 5, 5, 80, 5, 5, 1f, 1f);//木灵根
        t.base_stats[S.mod_damage] = 1f;//攻击100%
        t.base_stats[CW_S.mod_cultivelo] = 0.5f;//修炼速度50%
                                        
        CreateElement("cw_metal", 5, 5, 5, 80, 5, 1f, 1f);//金灵根
        t.base_stats[S.mod_damage] = 1f;//攻击100%
        t.base_stats[CW_S.mod_cultivelo] = 0.5f;//修炼速度50%
                                        
        CreateElement("cw_soil", 5, 5, 5, 5, 80, 1f, 1f);//土灵根
        t.base_stats[S.mod_damage] = 1f;//攻击100%
        t.base_stats[CW_S.mod_cultivelo] = 0.5f;//修炼速度50%
                                                
        CreateElement("cw_water_fire", 40, 40, 5, 10, 5, 1f, 1f);//水火灵根
        t.base_stats[S.mod_damage] = 1f;//攻击100%
        t.base_stats[CW_S.mod_cultivelo] = 0.5f;//修炼速度50%
                                                
        CreateElement("cw_water_wood", 40, 5, 40, 5, 10, 1f, 1f);//水木灵根
        t.base_stats[S.mod_damage] = 1f;//攻击100%
        t.base_stats[CW_S.mod_cultivelo] = 0.5f;//修炼速度50%
                                                
        CreateElement("cw_water_metal", 40, 5, 10, 40, 5, 1f, 1f);//水金灵根
        t.base_stats[S.mod_damage] = 1f;//攻击100%
        t.base_stats[CW_S.mod_cultivelo] = 0.5f;//修炼速度50%
                                                
        CreateElement("cw_water_soil", 40, 10, 5, 5, 40, 1f, 1f);//水土灵根
        t.base_stats[S.mod_damage] = 1f;//攻击100%
        t.base_stats[CW_S.mod_cultivelo] = 0.5f;//修炼速度50%
                                                        
        CreateElement("cw_fire_wood", 5, 40, 40, 5, 10, 1f, 1f);//火木灵根
        t.base_stats[S.mod_damage] = 1f;//攻击100%
        t.base_stats[CW_S.mod_cultivelo] = 0.5f;//修炼速度50%
                                                                
        CreateElement("cw_fire_metal", 10, 40, 5, 40, 5, 1f, 1f);//火金灵根
        t.base_stats[S.mod_damage] = 1f;//攻击100%
        t.base_stats[CW_S.mod_cultivelo] = 0.5f;//修炼速度50%
                                                                
        CreateElement("cw_fire_soil", 5, 40, 10, 5, 40, 1f, 1f);//火土灵根
        t.base_stats[S.mod_damage] = 1f;//攻击100%
        t.base_stats[CW_S.mod_cultivelo] = 0.5f;//修炼速度50%
                                                                
        CreateElement("cw_wood_metal", 5, 10, 40, 40, 5, 1f, 1f);//木金灵根
        t.base_stats[S.mod_damage] = 1f;//攻击100%
        t.base_stats[CW_S.mod_cultivelo] = 0.5f;//修炼速度50%
                                                                        
        CreateElement("cw_wood_soil", 10, 5, 40, 5, 40, 1f, 1f);//木土灵根
        t.base_stats[S.mod_damage] = 1f;//攻击100%
        t.base_stats[CW_S.mod_cultivelo] = 0.5f;//修炼速度50%
                                                                                
        CreateElement("cw_metal_soil", 5, 10, 5, 40, 40, 1f, 1f);//金土灵根
        t.base_stats[S.mod_damage] = 1f;//攻击100%
        t.base_stats[CW_S.mod_cultivelo] = 0.5f;//修炼速度50%
                                                                                        
        CreateElement("cw_water_fire_wood", 30, 30, 30, 5, 5, 1f, 0.1f);//水火木灵根
        t.base_stats[S.mod_damage] = 1f;//攻击100%
        t.base_stats[CW_S.mod_cultivelo] = 0.5f;//修炼速度50%
                                                                                                
        CreateElement("cw_water_fire_metal", 30, 30, 5, 30, 5, 1f, 0.1f);//水火金灵根
        t.base_stats[S.mod_damage] = 1f;//攻击100%
        t.base_stats[CW_S.mod_cultivelo] = 0.5f;//修炼速度50%
                                                                                                
        CreateElement("cw_water_fire_soil", 30, 30, 5, 5, 30, 1f, 0.1f);//水火土灵根
        t.base_stats[S.mod_damage] = 1f;//攻击100%
        t.base_stats[CW_S.mod_cultivelo] = 0.5f;//修炼速度50%
                                                                                                
        CreateElement("cw_water_wood_metal", 30, 5, 30, 30, 5, 1f, 0.1f);//水木金灵根
        t.base_stats[S.mod_damage] = 1f;//攻击100%
        t.base_stats[CW_S.mod_cultivelo] = 0.5f;//修炼速度50%
                                                                                                        
        CreateElement("cw_water_wood_soil", 30, 5, 30, 5, 30, 1f, 0.1f);//水木土灵根
        t.base_stats[S.mod_damage] = 1f;//攻击100%
        t.base_stats[CW_S.mod_cultivelo] = 0.5f;//修炼速度50%
                                                                                                        
        CreateElement("cw_water_metal_soil", 30, 5, 5, 30, 30, 1f, 0.1f);//水金土灵根
        t.base_stats[S.mod_damage] = 1f;//攻击100%
        t.base_stats[CW_S.mod_cultivelo] = 0.5f;//修炼速度50%
                                                                                                        
        CreateElement("cw_fire_wood_metal", 5, 30, 30, 30, 5, 1f, 0.1f);//火木金灵根
        t.base_stats[S.mod_damage] = 1f;//攻击100%
        t.base_stats[CW_S.mod_cultivelo] = 0.5f;//修炼速度50%
                                                                                                                
        CreateElement("cw_fire_wood_soil", 5, 30, 30, 5, 30, 1f, 0.1f);//火木土灵根
        t.base_stats[S.mod_damage] = 1f;//攻击100%
        t.base_stats[CW_S.mod_cultivelo] = 0.5f;//修炼速度50%
                                                                                                                
        CreateElement("cw_fire_metal_soil", 5, 30, 5, 30, 30, 1f, 0.1f);//火金土灵根
        t.base_stats[S.mod_damage] = 1f;//攻击100%
        t.base_stats[CW_S.mod_cultivelo] = 0.5f;//修炼速度50%
                                                                                                                
        CreateElement("cw_wood_metal_soil", 5, 5, 30, 30, 30, 1f, 0.1f);//木金土灵根
        t.base_stats[S.mod_damage] = 1f;//攻击100%
        t.base_stats[CW_S.mod_cultivelo] = 0.5f;//修炼速度50%
                                                                                                                
        CreateElement("cw_hybrid", 20, 20, 20, 20, 20, 1f, 0.1f);//杂灵根
        t.base_stats[S.mod_damage] = 1f;//攻击100%
        t.base_stats[CW_S.mod_cultivelo] = 0.5f;//修炼速度50%
                                                                                                                
        CreateElement("cw_chaos", 20, 20, 20, 20, 20, 10f, 10f);//混沌灵根
        t.base_stats[S.mod_damage] = 1f;//攻击100%
        t.base_stats[CW_S.mod_cultivelo] = 0.5f;//修炼速度50%
    }
    protected void CreateElement(string pID, int water, int fire, int wood, int iron, int ground, float promot, float rarity)
    {
        Add(new ElementAsset(pID, water, fire, wood, iron, ground, promot, rarity));
    }
}
