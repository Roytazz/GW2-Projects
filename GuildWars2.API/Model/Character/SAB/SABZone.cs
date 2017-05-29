namespace GuildWars2.API.Model.Character
{
    public class SABZone
    {
        public int ID { get; set; }

        public SABMode Mode { get; set; }

        public int World { get; set; }

        public int Zone { get; set; }
    }

    public enum SABMode
    {
        Infantile,
        Normal,
        Tribulation
    }
}