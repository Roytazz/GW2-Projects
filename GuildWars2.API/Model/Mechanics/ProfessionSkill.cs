namespace GuildWars2.API.Model.Mechanics
{
    public class ProfessionSkill {

        public int ID { get; set; }

        public WeaponSlot Slot { get; set; }

        public SkillType Profession { get; set; }

        public Attunement Attunement { get; set; }

        public Profession Source { get; set; }
    }

    public enum Attunement {
        Fire,
        Water,
        Air,
        Earth
    }
}
