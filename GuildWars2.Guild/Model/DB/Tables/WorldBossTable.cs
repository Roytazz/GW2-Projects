using System.Data.SQLite;
using System.Collections.Generic;
using System;
using GuildWars2API.Model.Event;

namespace GuildWars2Guild.Model.DB.Tables
{
    [Obsolete]
    public class WorldBossTable : SqliteTable<WorldBossEntry>, ISqliteTable<WorldBossEntry>
    {
        public string Name { get { return "WorldBoss"; } }

        public SqliteTable CreateTable() {
            SqliteTable table = new SqliteTable(Name);
            table.Columns.Add(new SqliteColumn("ID", ColType.Text, true, true, true, "-1"));
            table.Columns.Add(new SqliteColumn("Name", ColType.Text));
            table.Columns.Add(new SqliteColumn("Description", ColType.Text));
            table.Columns.Add(new SqliteColumn("Waypoint", ColType.Text));
            table.Columns.Add(new SqliteColumn("Level", ColType.Integer));

            table.Columns.Add(new SqliteColumn("Time", ColType.Text));
            table.Columns.Add(new SqliteColumn("DragoniteLootMinimum", ColType.Integer));
            table.Columns.Add(new SqliteColumn("DragoniteLootMaximum", ColType.Integer));
            table.Columns.Add(new SqliteColumn("ItemLoot", ColType.Integer));
            table.Columns.Add(new SqliteColumn("BoxesLoot", ColType.Integer));
            
            return table;
        }

        public IEnumerable<Dictionary<string, object>> Seed() {
            var rows = new List<Dictionary<string, object>>();
            foreach(var boss in GetBosses()) {
                for(int i = 0; i < (boss["Times"] as List<string>).Count; i++) {
                    rows.Add(new Dictionary<string, object> {
                        {"Name", boss["Name"] },
                        {"Description", boss["Description"] },
                        {"Waypoint", boss["Waypoint"] },
                        {"Level", boss["Level"] },

                        {"Time", (boss["Times"] as List<string>)[i] },
                        {"DragoniteLootMinimum", boss["DragoniteLootMinimum"] },
                        {"DragoniteLootMaximum", boss["DragoniteLootMaximum"] },
                        {"ItemLoot", boss["ItemLoot"] },
                        {"BoxesLoot", boss["BoxesLoot"] },
                    });
                }
            }
            return rows;
        }

        private List<Dictionary<string, object>> GetBosses() {
            var bosses = new List<Dictionary<string, object>>();
            bosses.Add(new Dictionary<string, object>() {
                {"Name","Tequatl the Sunless"}, {"Description","Defeat Tequatl the Sunless"}, {"Waypoint","[&BNABAAA=]"}, {"Level","65"},
                {"DragoniteLootMinimum","15"}, {"DragoniteLootMaximum","25"}, {"ItemLoot","2"} , {"BoxesLoot","2"},
                {"Times", new List<string> {
                    "0:00:00", "3:00:00", "7:00:00", "11:30:00", "16:00:00", "19:00:00"
                }}
            });
            bosses.Add(new Dictionary<string, object>() {
                {"Name","Frozen Maw"}, {"Description","Kill the Svanir shaman chief to break his control over the Ice elemental"}, {"Waypoint","[&BMIDAAA=]"}, {"Level","10"},
                {"DragoniteLootMinimum","3"}, {"DragoniteLootMaximum","5"}, {"ItemLoot","1"} , {"BoxesLoot","0"},
                {"Times", new List<string> {
                    "0:15:00", "2:15:00", "4:15:00", "6:15:00", "8:15:00", "10:15:00", "12:15:00", "14:15:00", "16:15:00", "18:15:00", "20:15:00", "22:15:00"
                }}
            });
            bosses.Add(new Dictionary<string, object>() {
                {"Name","Modniir Ulgoth"}, {"Description","Defeat Ulgoth the Modniir and his minions"}, {"Waypoint","[&BLAAAAA=]"}, {"Level","43"},
                {"DragoniteLootMinimum","3"}, {"DragoniteLootMaximum","5"}, {"ItemLoot","1"} , {"BoxesLoot","1"},
                {"Times", new List<string> {
                    "1:30:00", "4:30:00", "7:30:00", "10:30:00", "13:30:00", "16:30:00", "19:30:00", "22:30:00"
                }}
            });
            bosses.Add(new Dictionary<string, object>() {
                {"Name","Fire Elemental"}, {"Description","Destroy the Fire Elemental created from chaotic energy fusing with the C.L.E.A.N. 5000's energy core"}, {"Waypoint","[&BEcAAAA=]"}, {"Level","15"},
                {"DragoniteLootMinimum","3"}, {"DragoniteLootMaximum","5"}, {"ItemLoot","1"} , {"BoxesLoot","2"},
                {"Times", new List<string> {
                    "0:45:00", "2:45:00", "4:45:00", "6:45:00", "8:45:00", "10:45:00", "12:45:00", "14:45:00", "16:45:00", "18:45:00", "20:45:00", "22:45:00"
                }}
            });
            bosses.Add(new Dictionary<string, object>() {
                {"Name","Karka Queen"}, {"Description","Defeat the Karka Queen threatening the settlements"}, {"Waypoint","[&BNUGAAA=]"}, {"Level","80"},
                {"DragoniteLootMinimum","30"}, {"DragoniteLootMaximum","30"}, {"ItemLoot","2"} , {"BoxesLoot","2"},
                {"Times", new List<string> {
                    "2:00:00", "6:00:00", "10:30:00", "15:00:00", "18:00:00", "23:00:00"
                }}
            });
            bosses.Add(new Dictionary<string, object>() {
                {"Name","Golem Mark II"}, {"Description","Defeat the Inquest's Golem Mark II"}, {"Waypoint","[&BNQCAAA=]"}, {"Level","68"},
                {"DragoniteLootMinimum","15"}, {"DragoniteLootMaximum","25"}, {"ItemLoot","1"} , {"BoxesLoot","2"},
                {"Times", new List<string> {
                    "2:00:00", "5:00:00", "8:00:00", "11:00:00", "14:00:00", "17:00:00", "20:00:00", "23:00:00"
                }}
            });
            bosses.Add(new Dictionary<string, object>() {
                {"Name","Claw of Jormag"}, {"Description","Defeat the Claw of Jormag"}, {"Waypoint","[&BHoCAAA=]"}, {"Level","80"},
                {"DragoniteLootMinimum","15"}, {"DragoniteLootMaximum","25"}, {"ItemLoot","1"} , {"BoxesLoot","2"},
                {"Times", new List<string> {
                    "2:30:00", "5:30:00", "8:30:00", "11:30:00", "14:30:00", "17:30:00", "20:30:00", "23:30:00"
                }}
            });
            bosses.Add(new Dictionary<string, object>() {
                {"Name","Shadow Behemoth"}, {"Description","Defeat the Shadow Behemoth"}, {"Waypoint","[&BPcAAAA=]"}, {"Level","15"},
                {"DragoniteLootMinimum","3"}, {"DragoniteLootMaximum","5"}, {"ItemLoot","1"} , {"BoxesLoot","0"},
                {"Times", new List<string> {
                    "1:45:00", "3:45:00", "5:45:00", "7:45:00", "9:45:00", "11:45:00", "13:45:00", "15:45:00", "17:45:00", "19:45:00", "21:45:00", "23:45:00"
                }}
            });
            bosses.Add(new Dictionary<string, object>() {
                {"Name","Taidha Covington"}, {"Description","Kill Admiral Taidha Covington"}, {"Waypoint","[&BKgBAAA=]"}, {"Level","50"},
                {"DragoniteLootMinimum","3"}, {"DragoniteLootMaximum","5"}, {"ItemLoot","1"} , {"BoxesLoot","0"},
                {"Times", new List<string> {
                    "0:00:00", "3:00:00", "6:00:00", "9:00:00", "12:00:00", "15:00:00", "18:00:00", "21:00:00"
                }}
            });
            bosses.Add(new Dictionary<string, object>() {
                {"Name","Megadestroyer"}, {"Description","Kill the Megadestroyer before it blows everyone up"}, {"Waypoint","[&BM0CAAA=]"}, {"Level","66"},
                {"DragoniteLootMinimum","0"}, {"DragoniteLootMaximum","0"}, {"ItemLoot","1"} , {"BoxesLoot","0"},
                {"Times", new List<string> {
                    "0:30:00", "3:30:00", "6:30:00", "9:30:00", "12:30:00", "15:30:00", "18:30:00", "21:30:00"
                }}
            });
            bosses.Add(new Dictionary<string, object>() {
                {"Name","The Shatterer"}, {"Description","Slay the Shatterer"}, {"Waypoint","[&BE4DAAA=]"}, {"Level","50"},
                {"DragoniteLootMinimum","15"}, {"DragoniteLootMaximum","25"}, {"ItemLoot","1"} , {"BoxesLoot","0"},
                {"Times", new List<string> {
                    "1:00:00", "4:00:00", "7:00:00", "10:00:00", "13:00:00", "16:00:00", "19:00:00", "22:00:00"
                }}
            });
            bosses.Add(new Dictionary<string, object>() {
                {"Name","Jungle Wurm"}, {"Description","Defeat the Great Jungle Wurm"}, {"Waypoint","[&BEEFAAA=]"}, {"Level","15"},
                {"DragoniteLootMinimum","3"}, {"DragoniteLootMaximum","5"}, {"ItemLoot","1"} , {"BoxesLoot","0"},
                {"Times", new List<string> {
                    "1:15:00", "3:15:00", "5:15:00", "7:15:00", "9:15:00", "11:15:00", "13:15:00", "15:15:00", "17:15:00", "19:15:00", "21:15:00", "23:15:00"
                }}
            });
            bosses.Add(new Dictionary<string, object>() {
                {"Name","Triple Trouble"}, {"Description","The three heads of a Great Jungle wurm are attacking Bloodtide Coast"}, {"Waypoint","[&BKoBAAA=]"}, {"Level","52"},
                {"DragoniteLootMinimum","40"}, {"DragoniteLootMaximum","40"}, {"ItemLoot","2"} , {"BoxesLoot","2"},
                {"Times", new List<string> {
                    "1:00:00", "4:00:00", "8:00:00", "12:30:00", "17:00:00", "20:00:00"
                }}
            });
            return bosses;
        }
    }

    [Obsolete]
    public class WorldBossEntry : WorldBoss
    {
        public int ID { get; set; }
        public string Time { get; set; }
    }
}