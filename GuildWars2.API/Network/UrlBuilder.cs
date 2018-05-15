using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildWars2.API.Network
{
    internal class UrlBuilder
    {
        private static readonly string BASE_URL_V1 = "https://api.guildwars2.com/v1";
        private static readonly string BASE_URL_V2 = "https://api.guildwars2.com/v2";
        private static readonly string BASE_URL_PROFITS = "http://gw2profits.com/json/v3";
        private static readonly string BASE_URL_SHINIES = "https://www.gw2shinies.com/api/json";

        private int _parameterLimit = 200;
        private List<string> _directives = new List<string>();
        private List<ParameterHelper> _params = new List<ParameterHelper>();

        public UrlBuilder(params string[] endPoints) {
            if (endPoints.Count() > 0) {
                foreach (var directive in endPoints) {
                    _directives.Add(Escape(directive));
                }
            }
        }

        public async Task<T> RequestAsync<T>(API api = API.Guildwars2V2, int parameterLimit = 200) where T : class, new() {
            _parameterLimit = parameterLimit;
            var urls = GetURLs(api);
            if (!IsEnumerableType(typeof(T))) {
                return await WebHandler.GetRequestAsync<T>(urls.FirstOrDefault());
            }
            else {
                Type listItemType = typeof(T).GetGenericArguments()[0];
                Type genericListType = typeof(List<>).MakeGenericType(listItemType);
                var totalResult = (IList)Activator.CreateInstance(genericListType);
                
                foreach (var url in urls) {
                    var result = await WebHandler.GetRequestAsync<T>(url);
                    foreach (var item in (IList)result) {
                        totalResult.Add(item);
                    }
                }
                return totalResult as T;
            }
        }

        public async Task<T> RequestAsync<T>(string apiKey, API api = API.Guildwars2V2, int parameterLimit = 200) where T : class, new() {
            AddParam("access_token", apiKey);
            return await RequestAsync<T>(api, parameterLimit);
        }

        public UrlBuilder AddDirective(string directive) {
            _directives.Add(Escape(directive));
            return this;
        }

        public UrlBuilder AddParam(string name, string value) {
            _params.Add(new ParameterHelper { Name = name, Values = new List<string> { Escape(value) } });
            return this;
        }
        
        /// <summary>
        /// Can only be called once per UrlBuilder. If the collection is too big, it will attempt to break the request in several smaller chunks.
        /// Each chunk/url will have ALL one-property-sized parameter and only part of the many-property-sized paramenter.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public UrlBuilder AddParam<T>(string name, IEnumerable<T> values) {
            List<string> stringValues = new List<string>();
            foreach (var value in values) {
                stringValues.Add(Escape(value.ToString()));
            }
            _params.Add(new ParameterHelper { Name = name, Values = stringValues });
            return this;
        }

        private string GetBaseURL(API api) {
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

        private List<string> GetURLs(API api) { 
            var urls = new List<string>();
            var baseUrl = new StringBuilder(GetBaseURL(api));
            if (_directives.Count > 0) {
                baseUrl.Append('/');
                baseUrl.Append(string.Join("/", _directives));
            }
            if (_params.Count > 0) {
                baseUrl.Append('?');
                foreach (var param in _params) {
                    if(param.Values.Count() <= _parameterLimit) {
                        baseUrl.Append($"{param.Name}={ParameterCord(param.Values)}");
                        baseUrl.Append("&");
                    }
                }
            }

            //Create multiple urls for when a parameter is too big
            if (_params.Any(x => x.Values.Count() > _parameterLimit)) {
                var param = _params.FirstOrDefault(x => x.Values.Count() > _parameterLimit);
                while(param.Values.Count() != 0) {
                    if(param.Values.Count() >= _parameterLimit) {
                        var shardedBuilder = new StringBuilder(baseUrl.ToString());
                        shardedBuilder.Append($"{param.Name}={ParameterCord(param.Values.Take(_parameterLimit))}");
                        ((List<string>)param.Values).RemoveRange(0, _parameterLimit);
                        urls.Add(shardedBuilder.ToString());
                    }
                    else {
                        var shardedBuilder = new StringBuilder(baseUrl.ToString());
                        shardedBuilder.Append($"{param.Name}={ParameterCord(param.Values)}");
                        urls.Add(shardedBuilder.ToString());
                        break;
                    }
                }
            }
            else {
                if(_params.Count != 0)
                    baseUrl.Remove(baseUrl.Length - 1, 1);
                urls.Add(baseUrl.ToString());
            }

            return urls;
        }

        private static string Escape(string value) {
            if (!string.IsNullOrEmpty(value))
                return Uri.EscapeDataString(value.ToString());

            return string.Empty;
        }
        
        private static bool IsEnumerableType(Type type) {
            return (type.GetInterface(nameof(IEnumerable)) != null);
        }

        private static string ParameterCord(IEnumerable<string> values) {
            var result = new StringBuilder();
            foreach (var value in values) {
                result.Append(Escape(value.ToString()));
                result.Append(',');
            }
            if (result.Length > 0)
                result.Remove(result.Length - 1, 1);

            return result.ToString();
        }
    }

    public enum API {
        Guildwars2V1,
        Guildwars2V2,
        Profits,
        Shinies
    }

    internal class ParameterHelper
    {
        public string Name { get; set; }

        public IEnumerable<string> Values { get; set; }
    }
}