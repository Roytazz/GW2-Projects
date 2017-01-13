using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Utility.Logger;

namespace Utility.Network
{
    public class WebRequestHandler : IWebHandler
{
        public T GetRequest<T>(string url, Dictionary<string, string> headers = null) => ReadResponse<T>(CreateRequest(url, headers));

        private WebRequest CreateRequest(string url, Dictionary<string, string> headers) {
            var request = WebRequest.Create(url);
            if(headers != null) {
                foreach(KeyValuePair<string, string> header in headers) {
                    request.Headers[header.Key] = header.Value;
                }
            }
            return request;
        }

        private T ReadResponse<T>(WebRequest request) {
            string responseJson;
            try {
                using(var response = (HttpWebResponse)request.GetResponse()) {
                    using(Stream data = response.GetResponseStream()) {
                        using(var sr = new StreamReader(data)) {
                            responseJson = sr.ReadToEnd();
                            return JsonConvert.DeserializeObject<T>(responseJson);
                        }
                    }
                }
            }
            catch(WebException ex) {
                LogManager.LogMessage(string.Format("[ERROR] NetworkManager couldn't resolve the result: {0}", GetWebExDetail(ex)), false);
                return default(T);
            }
            catch(Exception ex) {
                LogManager.LogException(ex, "NetworkManager couldn't resolve the result", false);
                return default(T);
            }
        }

        private string GetWebExDetail(WebException ex) {
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
