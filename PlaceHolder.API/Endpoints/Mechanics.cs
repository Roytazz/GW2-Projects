using GuildWars2APIPlaceHolder.Model;
using GuildWars2APIPlaceHolder.Model.Mechanics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildWars2APIPlaceHolder
{
    public static class MechanicsAPI
    {
        private static UrlBuilder Builder { get { return new UrlBuilder(); } }

        #region Profession
        public static List<string> ProfessionIDs()
        {
            return Builder.AddPointer("professions")
                .Request<List<string>>();
        }

        public static List<ProfessionInfo> Professions()
        {
            return Builder.AddPointer("professions")
                .AddParam("ids", "all")
                .Request<List<ProfessionInfo>>();
        }

        public static List<ProfessionInfo> Professions(int pageCount, int page)
        {
            return Builder.AddPointer("professions")
                .AddParam("page", page.ToString())
                .AddParam("page_size", pageCount.ToString())
                .Request<List<ProfessionInfo>>();
        }

        public static ProfessionInfo Professions(string ID)
        {
            return Builder.AddPointer("professions")
                .AddPointer(ID)
                .Request<ProfessionInfo>();
        }

        public static List<ProfessionInfo> Professions(List<string> IDs)
        {
            return Builder.AddPointer("professions")
                .AddParam("ids", IDs)
                .Request<List<ProfessionInfo>>();
        }
        #endregion Profession

        #region Specialization
        public static List<int> SpecializationIDs()
        {
            return Builder.AddPointer("specializations")
                .Request<List<int>>();
        }

        public static List<Specialization> Specializations()
        {
            return Builder.AddPointer("specializations")
                .AddParam("ids", "all")
                .Request<List<Specialization>>();
        }

        public static List<Specialization> Specializations(int pageCount, int page)
        {
            return Builder.AddPointer("specializations")
                .AddParam("page", page.ToString())
                .AddParam("page_size", pageCount.ToString())
                .Request<List<Specialization>>();
        }

        public static Specialization Specializations(int ID)
        {
            return Builder.AddPointer("specializations")
                .AddPointer(ID.ToString())
                .Request<Specialization>();
        }

        public static List<Specialization> Specializations(List<int> IDs)
        {
            return Builder.AddPointer("specializations")
                .AddParam("ids", IDs)
                .Request<List<Specialization>>();
        }
        #endregion Specialization

        #region Skills
        public static List<int> SkillIDs()
        {
            return Builder.AddPointer("skills")
                .Request<List<int>>();
        }

        public static List<Skill> Skills()
        {
            return Builder.AddPointer("skills")
                .AddParam("ids", "all")
                .Request<List<Skill>>();
        }

        public static List<Skill> Skills(int pageCount, int page)
        {
            return Builder.AddPointer("skills")
                .AddParam("page", page.ToString())
                .AddParam("page_size", pageCount.ToString())
                .Request<List<Skill>>();
        }

        public static Skill Skills(int ID)
        {
            return Builder.AddPointer("skills")
                .AddPointer(ID.ToString())
                .Request<Skill>();
        }

        public static List<Skill> Skills(List<int> IDs)
        {
            return Builder.AddPointer("skills")
                .AddParam("ids", IDs)
                .Request<List<Skill>>();
        }
        #endregion Skills

        #region Traits
        public static List<int> TraitIDs()
        {
            return Builder.AddPointer("traits")
                .Request<List<int>>();
        }

        public static List<Trait> Traits()
        {
            return Builder.AddPointer("traits")
                .AddParam("ids", "all")
                .Request<List<Trait>>();
        }

        public static List<Trait> Traits(int pageCount, int page)
        {
            return Builder.AddPointer("traits")
                .AddParam("page", page.ToString())
                .AddParam("page_size", pageCount.ToString())
                .Request<List<Trait>>();
        }

        public static Trait Traits(int ID)
        {
            return Builder.AddPointer("traits")
                .AddPointer(ID.ToString())
                .Request<Trait>();
        }

        public static List<Trait> Traits(List<int> IDs)
        {
            return Builder.AddPointer("traits")
                .AddParam("ids", IDs)
                .Request<List<Trait>>();
        }
        #endregion Traits

        #region Legends
        public static List<LegendType> LegendIDs()
        {
            return Builder.AddPointer("legends")
                .Request<List<LegendType>>();
        }

        public static List<Legend> Legends()
        {
            return Builder.AddPointer("legends")
                .AddParam("ids", "all")
                .Request<List<Legend>>();
        }

        public static Legend Legends(LegendType ID)
        {
            return Builder.AddPointer("legends")
                .AddPointer(ID.ToString())
                .Request<Legend>();
        }

        public static List<Legend> Legends(List<LegendType> IDs)
        {
            return Builder.AddPointer("legends")
                .AddParam("ids", IDs)
                .Request<List<Legend>>();
        }
        #endregion Legends
    }
}
