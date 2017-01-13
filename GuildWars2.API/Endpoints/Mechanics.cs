using GuildWars2API.Model;
using GuildWars2API.Model.Mechanics;
using System.Collections.Generic;

namespace GuildWars2API
{
    public static class MechanicsAPI
    {
        private static UrlBuilder Builder { get { return new UrlBuilder(); } }

        #region Profession
        public static List<string> ProfessionIDs()
        {
            return Builder.AddDirective("professions")
                .Request<List<string>>();
        }

        public static List<ProfessionInfo> Professions()
        {
            return Builder.AddDirective("professions")
                .AddParam("ids", "all")
                .Request<List<ProfessionInfo>>();
        }

        public static List<ProfessionInfo> Professions(int pageCount, int page)
        {
            return Builder.AddDirective("professions")
                .AddParam("page", page.ToString())
                .AddParam("page_size", pageCount.ToString())
                .Request<List<ProfessionInfo>>();
        }

        public static ProfessionInfo Professions(string ID)
        {
            return Builder.AddDirective("professions")
                .AddDirective(ID)
                .Request<ProfessionInfo>();
        }

        public static List<ProfessionInfo> Professions(List<string> IDs)
        {
            return Builder.AddDirective("professions")
                .AddParam("ids", IDs)
                .Request<List<ProfessionInfo>>();
        }
        #endregion Profession

        #region Specialization
        public static List<int> SpecializationIDs()
        {
            return Builder.AddDirective("specializations")
                .Request<List<int>>();
        }

        public static List<Specialization> Specializations()
        {
            return Builder.AddDirective("specializations")
                .AddParam("ids", "all")
                .Request<List<Specialization>>();
        }

        public static List<Specialization> Specializations(int pageCount, int page)
        {
            return Builder.AddDirective("specializations")
                .AddParam("page", page.ToString())
                .AddParam("page_size", pageCount.ToString())
                .Request<List<Specialization>>();
        }

        public static Specialization Specializations(int ID)
        {
            return Builder.AddDirective("specializations")
                .AddDirective(ID.ToString())
                .Request<Specialization>();
        }

        public static List<Specialization> Specializations(List<int> IDs)
        {
            return Builder.AddDirective("specializations")
                .AddParam("ids", IDs)
                .Request<List<Specialization>>();
        }
        #endregion Specialization

        #region Skills
        public static List<int> SkillIDs()
        {
            return Builder.AddDirective("skills")
                .Request<List<int>>();
        }

        public static List<Skill> Skills()
        {
            return Builder.AddDirective("skills")
                .AddParam("ids", "all")
                .Request<List<Skill>>();
        }

        public static List<Skill> Skills(int pageCount, int page)
        {
            return Builder.AddDirective("skills")
                .AddParam("page", page.ToString())
                .AddParam("page_size", pageCount.ToString())
                .Request<List<Skill>>();
        }

        public static Skill Skills(int ID)
        {
            return Builder.AddDirective("skills")
                .AddDirective(ID.ToString())
                .Request<Skill>();
        }

        public static List<Skill> Skills(List<int> IDs)
        {
            return Builder.AddDirective("skills")
                .AddParam("ids", IDs)
                .Request<List<Skill>>();
        }
        #endregion Skills

        #region Traits
        public static List<int> TraitIDs()
        {
            return Builder.AddDirective("traits")
                .Request<List<int>>();
        }

        public static List<Trait> Traits()
        {
            return Builder.AddDirective("traits")
                .AddParam("ids", "all")
                .Request<List<Trait>>();
        }

        public static List<Trait> Traits(int pageCount, int page)
        {
            return Builder.AddDirective("traits")
                .AddParam("page", page.ToString())
                .AddParam("page_size", pageCount.ToString())
                .Request<List<Trait>>();
        }

        public static Trait Traits(int ID)
        {
            return Builder.AddDirective("traits")
                .AddDirective(ID.ToString())
                .Request<Trait>();
        }

        public static List<Trait> Traits(List<int> IDs)
        {
            return Builder.AddDirective("traits")
                .AddParam("ids", IDs)
                .Request<List<Trait>>();
        }
        #endregion Traits

        #region Legends
        public static List<LegendType> LegendIDs()
        {
            return Builder.AddDirective("legends")
                .Request<List<LegendType>>();
        }

        public static List<Legend> Legends()
        {
            return Builder.AddDirective("legends")
                .AddParam("ids", "all")
                .Request<List<Legend>>();
        }

        public static Legend Legends(LegendType ID)
        {
            return Builder.AddDirective("legends")
                .AddDirective(ID.ToString())
                .Request<Legend>();
        }

        public static List<Legend> Legends(List<LegendType> IDs)
        {
            return Builder.AddDirective("legends")
                .AddParam("ids", IDs)
                .Request<List<Legend>>();
        }
        #endregion Legends
    }
}
