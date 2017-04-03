using GuildWars2.API;
using GuildWars2.API.Model;
using GuildWars2.API.Model.Character;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Text;

namespace GuildWars2.Web.Data.Extensions
{
    public static class Extensions
    {
        public static string Specialization(this Character character) {
            var eliteSpecs = MechanicsAPI.EliteSpecializationIDs(character.Profession);
            var result = character.Specializations[GameType.PvE].FirstOrDefault(c => {
                if (c != null) {
                    return eliteSpecs.Contains(c.ID);
                }
                return false;
            });
            return result == null ? character.Profession.ToString() : MechanicsAPI.EliteSpecializations(character.Profession).ToString();
        }

        public static IHtmlContent Load(this IHtmlHelper helper, int id, string url, bool createNewDiv = true)
        {
            var result = new StringBuilder();
            if(createNewDiv)
                result.Append($"<div id={id}></div>");

            result.Append("<script type='text/javascript'>");
            result.Append("(function($){ $(function() { $('#" + id + "').load('" + url + "'); });})(jQuery); ");
            result.Append("</script>");
            return helper.Raw(result.ToString());
        }

        public static IHtmlContent AjaxActionUrl(this IHtmlHelper helper, string url, AjaxMode mode, string updateDOM, AjaxMethod method, string innerContent) {
            var result = new StringBuilder();

            result.Append("<a data-ajax-url=" + url);
            result.Append(" data-ajax='true'");
            result.Append($" data-ajax-mode='{mode.ToString()}'");
            result.Append($" data-ajax-update='{updateDOM}'");
            result.Append($"data-ajax-method='{method.ToString()}'>");
            result.Append(innerContent);
            result.Append("</a>");

            return helper.Raw(result.ToString());
        }
    }

    public enum AjaxMode
    {
        Replace
    }

    public enum AjaxMethod
    {
        GET,
        POST
    }
}
/*
(function($){
    $(function() { 
        $("#id").load("url"); 
    });
})(jQuery); 
*/
