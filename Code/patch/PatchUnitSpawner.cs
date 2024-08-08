using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using HarmonyLib;

namespace CW_FantasyCreatures.patch{
    static class PatchUnitSpawner{
        [HarmonyPrefix, HarmonyPatch(typeof(UnitSpawner), nameof(UnitSpawner.spawnUnit))]
        private static bool Prefix_spawnUnit(UnitSpawner __instance){
            if (__instance.building.asset.id == "GoblinTower"){
                var building = __instance.building;
                var asset = __instance.building.asset;
                var spawn_unit_string = asset.spawnUnits_asset;
                var spawn_unit_list = DeparseSpawnUnitString(spawn_unit_string);

                var possble_list = new List<KeyValuePair<string, int>>();
                foreach(var id_amount_pair in spawn_unit_list){
                    building.data.get($"curr_amount_{id_amount_pair.Key}", out int curr_amount);
                    if (curr_amount <= id_amount_pair.Value){
                        possble_list.Add(id_amount_pair);
                    }
                }
                
                var total_weight = possble_list.Sum(x=>x.Value);
                int random_weight_idx = Toolbox.randomInt(0, total_weight);
                int curr_weight_idx = 0;

                string unit_id_to_spawn = "";
                foreach(var pair in possble_list){
                    curr_weight_idx += pair.Value;
                    if (curr_weight_idx > random_weight_idx){
                        unit_id_to_spawn = pair.Key;
                        break;
                    }
                }
                if (!string.IsNullOrEmpty(unit_id_to_spawn)){
                    var unit = World.world.units.createNewUnit(unit_id_to_spawn, building.currentTile);
                    __instance.setUnitFromHere(unit);
                    string data_key = $"curr_amount_{unit_id_to_spawn}";
                    building.data.get(data_key, out int curr_amount);
                    building.data.set(data_key, curr_amount+1);
                }

                return false;
            }
            else{
                return true;
            }
        }
        [HarmonyPostfix, HarmonyPatch(typeof(UnitSpawner), nameof(UnitSpawner.callbackUnitDied))]
        private static void Postfix_callbackUnitDied(UnitSpawner __instance, Actor pActor)
        {
            string data_key = $"curr_amount_{pActor.asset.id}";
            __instance.building.data.get(data_key, out int curr_amount);
            __instance.building.data.set(data_key, Math.Max(0, curr_amount-1));
        }
        private static List<KeyValuePair<string, int>> DeparseSpawnUnitString(string str){
            var list = new List<KeyValuePair<string, int>>();
            var raw_str_list = str.Split(',');
            foreach(var raw_str in raw_str_list){
                var raw_id_amount_pair = raw_str.Split(':');
                string id = raw_id_amount_pair[0];
                int amount = 1;
                if (raw_id_amount_pair.Length == 2){
                    if (!int.TryParse(raw_id_amount_pair[1], out amount)){
                        amount = 1;
                    }
                }

                list.Add(new(id, amount));
            }
            return list;
        }
    }
}