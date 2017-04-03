using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildWars2.API.Network
{
    internal class UrlBuilder
    {
        private static string BASE_URL_V1 = "https://api.guildwars2.com/v1";
        private static string BASE_URL_V2 = "https://api.guildwars2.com/v2";
        private static string BASE_URL_PROFITS = "http://gw2profits.com/json/v3";
        private static string BASE_URL_SHINIES = "https://www.gw2shinies.com/api/json";
        
        private List<string> _params = new List<string>();
        private List<string> _directives = new List<string>();

        public UrlBuilder(params string[] endPoints)
        {
            if(endPoints.Count() > 0)
                _directives.AddRange(endPoints);
        }

        public async Task<T> RequestAsync<T>(API api = API.Guildwars2V2) where T : new() {
            return await WebHandler.GetRequestAsync<T>(GetURL(api));
        }

        public async Task<T> RequestAsync<T>(string apiKey, API api = API.Guildwars2V2) where T : new() {
            return await WebHandler.GetRequestAsync<T>(GetURL(api), new Dictionary<string, string>() { { "Authorization", string.Format("Bearer {0}", apiKey) } });
        }

        public UrlBuilder AddDirective(string directive)
        {
            _directives.Add(Escape(directive));
            return this;
        }

        public UrlBuilder AddParam(string name, string value)
        {
            _params.Add($"{name}={Escape(value.ToString())}");
            return this;
        }

        public UrlBuilder AddParam<T>(string name, IEnumerable<T> values)   //Large requests might be a problem
        {
            var result = new StringBuilder();
            foreach (var value in values) {
                result.Append(Escape(value.ToString()));
                result.Append(',');
            }
            if(result.Length > 0)
                result.Remove(result.Length - 1, 1);

            _params.Add($"{name}={result.ToString()}");  
            return this;
        }



        private string GetBaseURL(API api)
        {
            switch (api) {
                case API.Guildwars2V1:
                return BASE_URL_V1;
                case API.Guildwars2V2:
                return BASE_URL_V2;
                case API.Profits:
                return BASE_URL_PROFITS;
                case API.Shinies:
                return BASE_URL_SHINIES;

                default:
                return BASE_URL_V2;
            }
        }

        public string GetURL(API api)
        {
            var url = new StringBuilder(GetBaseURL(api));
            if (_directives.Count > 0) {
                url.Append('/');
                url.Append(string.Join("/", _directives));
            }
            if (_params.Count > 0) {
                url.Append('?');
                url.Append(string.Join("&", _params));
            }
            return url.ToString();
        }

        private static string Escape(string value) {
            if (!string.IsNullOrEmpty(value))
                return Uri.EscapeDataString(value.ToString());

            return string.Empty;
        }
    }

    public enum API
    {
        Guildwars2V1,
        Guildwars2V2,
        Profits,
        Shinies
    }
}