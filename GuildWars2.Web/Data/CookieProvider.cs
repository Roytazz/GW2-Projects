using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;

namespace GuildWars2.Web.Data
{
    public class CookieTempDataProvider : ITempDataProvider
    {
        private readonly string CookieKey = "_tempdata";

        public IDictionary<string, object> LoadTempData(HttpContext context) {
            var cookieValue = context.Request.Cookies[this.CookieKey];
            if (string.IsNullOrWhiteSpace(cookieValue)) {
                return new Dictionary<string, object>();
            }

            var decoded = Convert.FromBase64String(cookieValue);
            var jsonAsString = Encoding.UTF8.GetString(decoded);
            var dictionary = JsonConvert.DeserializeObject<IDictionary<string, object>>(jsonAsString, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All, TypeNameAssemblyFormat = FormatterAssemblyStyle.Full });

            //context.Response.Cookies.Delete(this.CookieKey);

            return dictionary;
        }

        public void SaveTempData(HttpContext context, IDictionary<string, object> values) {
            if (values.ContainsKey("null") && values["null"] == null) { 
                context.Response.OnStarting(() => Task.Run(() => {
                    context.Response.Cookies.Delete(this.CookieKey);
                }));
                return;
            }

            var jsonAsString = JsonConvert.SerializeObject(values, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All, TypeNameAssemblyFormat = FormatterAssemblyStyle.Full });
            var bytes = Encoding.UTF8.GetBytes(jsonAsString);
            var encoded = Convert.ToBase64String(bytes);

            context.Response.Cookies.Append(this.CookieKey, encoded, new CookieOptions() { Expires = new DateTimeOffset(DateTime.Now.AddDays(1)) });
        }
    }
}