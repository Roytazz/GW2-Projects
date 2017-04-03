using GuildWars2.API.Model;
using GuildWars2.API.Model.Mechanics;
using GuildWars2.API.Network;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GuildWars2.API
{
    public static class MechanicsAPI
    {
        private static UrlBuilder Builder { get { return new UrlBuilder(); } }

        #region Profession
        public static Task<List<string>> ProfessionIDs()
        {
            return Builder.AddDirective("professions")
                .RequestAsync<List<string>>();
        }

        public static Task<List<ProfessionInfo>> Professions()
        {
            return Builder.AddDirective("professions")
                .AddParam("ids", "all")
                .RequestAsync<List<ProfessionInfo>>();
        }

        public static Task<List<ProfessionInfo>> Professions(int pageCount, int page)
        {
            return Builder.AddDirective("professions")
                .AddParam("page", page.ToString())
                .AddParam("page_size", pageCount.ToString())
                .RequestAsync<List<ProfessionInfo>>();
        }

        public static Task<ProfessionInfo> Professions(string ID)
        {
            return Builder.AddDirective("professions")
                .AddDirective(ID)
                .RequestAsync<ProfessionInfo>();
        }

        public static Task<List<ProfessionInfo>> Professions(List<string> IDs)
        {
            return Builder.AddDirective("professions")
                .AddParam("ids", IDs)
                .RequestAsync<List<ProfessionInfo>>();
        }
        #endregion Profession

        #region Specialization
        public static Task<List<int>> SpecializationIDs()
        {
            return Builder.AddDirective("specializations")
                .RequestAsync<List<int>>();
        }

        public static Task<List<Specialization>> Specializations()
        {
            return Builder.AddDirective("specializations")
                .AddParam("ids", "all")
                .RequestAsync<List<Specialization>>();
        }

        public static Task<List<Specialization>> Specializations(int pageCount, int page)
        {
            return Builder.AddDirective("specializations")
                .AddParam("page", page.ToString())
                .AddParam("page_size", pageCount.ToString())
                .RequestAsync<List<Specialization>>();
        }

        public static Task<Specialization> Specializations(int ID)
        {
            return Builder.AddDirective("specializations")
                .AddDirective(ID.ToString())
                .RequestAsync<Specialization>();
        }

        public static Task<List<Specialization>> Specializations(List<int> IDs)
        {
            return Builder.AddDirective("specializations")
                .AddParam("ids", IDs)
                .RequestAsync<List<Specialization>>();
        }

        #region Elite Specializations

        public static List<int> EliteSpecializationIDs(Profession profession) {
            var eliteSpecs = new Dictionary<Profession, List<int>> {
                { Profession.Warrior, new List<int> { 18 } },
                { Profession.Guardian, new List<int> { 27 } },
                { Profession.Revenant, new List<int> { 52 } },
                { Profession.Ranger, new List<int> { 5 } },
                { Profession.Engineer, new List<int> { 43 } },
                { Profession.Thief, new List<int> { 5 } },
                { Profession.Elementalist, new List<int> { 48 } },
                { Profession.Mesmer, new List<int> { 40 } },
                { Profession.Necromancer, new List<int> { 34 } }
            };
            return eliteSpecs[profession];
        }

        public static EliteSpecialization EliteSpecializations(Profession profession) {
            switch (profession) {
                case Profession.Guardian:
                return EliteSpecialization.Dragonhunter;

                case Profession.Warrior:
                return EliteSpecialization.Berserker;

                case Profession.Revenant:
                return EliteSpecialization.Herald;

                case Profession.Ranger:
                return EliteSpecialization.Druid;

                case Profession.Engineer:
                return EliteSpecialization.Scrapper;

                case Profession.Thief:
                return EliteSpecialization.Daredevil;

                case Profession.Elementalist:
                return EliteSpecialization.Tempest;

                case Profession.Mesmer:
                return EliteSpecialization.Chronomancer;

                case Profession.Necromancer:
                return EliteSpecialization.Reaper;

                default:
                return default(EliteSpecialization);
            }
        }
        #endregion Elite Specializations

        #endregion Specialization

        #region Skills
        public static Task<List<int>> SkillIDs()
        {
            return Builder.AddDirective("skills")
                .RequestAsync<List<int>>();
        }

        public static Task<List<Skill>> Skills()
        {
            return Builder.AddDirective("skills")
                .AddParam("ids", "all")
                .RequestAsync<List<Skill>>();
        }

        public static Task<List<Skill>> Skills(int pageCount, int page)
        {
            return Builder.AddDirective("skills")
                .AddParam("page", page.ToString())
                .AddParam("page_size", pageCount.ToString())
                .RequestAsync<List<Skill>>();
        }

        public static Task<Skill> Skills(int ID)
        {
            return Builder.AddDirective("skills")
                .AddDirective(ID.ToString())
                .RequestAsync<Skill>();
        }

        public static Task<List<Skill>> Skills(List<int> IDs)
        {
            return Builder.AddDirective("skills")
                .AddParam("ids", IDs)
                .RequestAsync<List<Skill>>();
        }
        #endregion Skills

        #region Traits
        public static Task<List<int>> TraitIDs()
        {
            return Builder.AddDirective("traits")
                .RequestAsync<List<int>>();
        }

        public static Task<List<Trait>> Traits()
        {
            return Builder.AddDirective("traits")
                .AddParam("ids", "all")
                .RequestAsync<List<Trait>>();
        }

        public static Task<List<Trait>> Traits(int pageCount, int page)
        {
            return Builder.AddDirective("traits")
                .AddParam("page", page.ToString())
                .AddParam("page_size", pageCount.ToString())
                .RequestAsync<List<Trait>>();
        }

        public static Task<Trait> Traits(int ID)
        {
            return Builder.AddDirective("traits")
                .AddDirective(ID.ToString())
                .RequestAsync<Trait>();
        }

        public static Task<List<Trait>> Traits(List<int> IDs)
        {
            return Builder.AddDirective("traits")
                .AddParam("ids", IDs)
                .RequestAsync<List<Trait>>();
        }
        #endregion Traits

        #region Legends
        public static Task<List<LegendType>> LegendIDs()
        {
            return Builder.AddDirective("legends")
                .RequestAsync<List<LegendType>>();
        }

        public static Task<List<Legend>> Legends()
        {
            return Builder.AddDirective("legends")
                .AddParam("ids", "all")
                .RequestAsync<List<Legend>>();
        }

        public static Task<Legend> Legends(LegendType ID)
        {
            return Builder.AddDirective("legends")
                .AddDirective(ID.ToString())
                .RequestAsync<Legend>();
        }

        public static Task<List<Legend>> Legends(List<LegendType> IDs)
        {
            return Builder.AddDirective("legends")
                .AddParam("ids", IDs)
                .RequestAsync<List<Legend>>();
        }
        #endregion Legends
    }
}
