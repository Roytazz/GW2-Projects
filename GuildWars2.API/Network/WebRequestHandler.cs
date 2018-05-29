using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace GuildWars2.API.Network
{
    internal static class WebHandler
    {
        public static async Task<T> GetRequestAsync<T>(string url, Dictionary<string, string> headers = null) where T : new() {
            return await ReadResponseAsync<T>(CreateRequest(url, headers));
        }

        private static WebRequest CreateRequest(string url, Dictionary<string, string> headers) {
            var request = WebRequest.Create(url);
            if(headers != null) {
                foreach(KeyValuePair<string, string> header in headers) {
                    request.Headers[header.Key] = header.Value;
                }
            }
            return request;
        }

        private static async Task<T> ReadResponseAsync<T>(WebRequest request) where T : new() {
            string responseJson;
            try {
                var response = await request.GetResponseAsync();
                using (Stream data = response.GetResponseStream()) {
                    using (var sr = new StreamReader(data)) {
                        responseJson = await sr.ReadToEndAsync();
                        return await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<T>(responseJson));
                    }
                }
            }
            catch (WebException ex) {
                Debug.WriteLine($"[ERROR] {request.RequestUri.PathAndQuery}");
                Debug.WriteLine(GetWebExDetail(ex));
                return new T();
            }
            catch (Exception ex) {
                Debug.WriteLine($"NetworkManager couldn't resolve the result: {ex.Message}");
                return new T();
            }
        }

        private static string GetWebExDetail(WebException ex) {
            WebResponse errResp = ex.Response;
            if(errResp != null) {
                using(Stream respStream = errResp.GetResponseStream()) {
                    var reader = new StreamReader(respStream);
                    return reader.ReadToEnd();
                }
            }
            return null;
        }
    }
}
