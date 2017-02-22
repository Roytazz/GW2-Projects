using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildWars2API.Model.PvP
{
    public class Game
    {
        [JsonProperty("id")]
        public string ID { get; set; }

        [JsonProperty("map_id")]
        public int MapID { get; set; }

        [JsonProperty("started")]
        public DateTime Started { get; set; }

        [JsonProperty("ended")]
        public DateTime Ended { get; set; }

        [JsonProperty("result")]
        public GameResult Result { get; set; }

        [JsonProperty("team")]
        public Team Team { get; set; }

        [JsonProperty("profession")]
        public Profession Profession { get; set; }

        [JsonProperty("scores")]
        public object Scores { get; set; }

        [JsonProperty("rating_type")]
        public GameRating RatingType { get; set; }

        [JsonProperty("rating_change")]
        public int RatingChange { get; set; }

        [JsonProperty("season")]
        public string Season { get; set; }
    }

    public enum GameResult
    {
        Victory,
        Defeat,
        Bye
    }

    public enum Team
    {
        Red, 
        Blue
    }

    public enum GameRating
    {
        None,
        Unranked,
        Ranked,
        SoloArenaRated, //deprecated
        TeamArenaRated  //deprecated
    }
}
