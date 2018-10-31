using System;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net;

namespace Starter
{
    /// <summary>
    /// 
    /// </summary>
    class bNesis
    {
        private static string Service = string.Empty;

        private static string bNesisToken = string.Empty;

        static string bNesisAPIServerURL = string.Empty;

        static string bNesisDeveloperId = string.Empty;

        /// <summary>
        /// Initialize bNesis APIs server access before using services APIs
        /// </summary>
        /// <param name="Service">Name of used Cloud Service</param>
        /// <param name="bNesisToken">bNesis Cloud Service access token</param>
        /// <param name="bNesisAPIServerURL">bNesis APIs server URL (use: https://server2.bnesis.com for demonstration)</param>
        /// <param name="bNesisDeveloperId">bNesis developer ID, visit: https://admin.bnesis.com to get here</param>
        public static void Init(string Service, string bNesisToken, string bNesisAPIServerURL, string bNesisDeveloperId)
        {
            bNesis.Service = Service;
            bNesis.bNesisToken = bNesisToken;
            bNesis.bNesisAPIServerURL = bNesisAPIServerURL;
            bNesis.bNesisDeveloperId = bNesisDeveloperId;
        }

        /// <summary>
        /// Execute Cloud Service API (method Init must be called before call this method)
        /// </summary>
        /// <param name="api">API execute perameters string</param>
        /// <returns>API result</returns>
        public static string Call(string api)
        {
            return Call(api, Service, bNesisToken, bNesisAPIServerURL, bNesisDeveloperId);
        }

        /// <summary>
        /// Execute Cloud Service API
        /// </summary>
        /// <param name="api">API execute perameters string</param>
        /// <param name="_Service">Name of used Cloud Service</param>
        /// <param name="_bNesisToken">bNesis Cloud Service access token</param>
        /// <param name="_bNesisAPIServerURL">bNesis APIs server URL (use: https://server2.bnesis.com for demonstration)</param>
        /// <param name="_bNesisDeveloperId">bNesis developer ID, visit: https://admin.bnesis.com to get here</param>
        /// <returns>API result</returns>
        public static string Call(string api, string _Service, string _bNesisToken, string _bNesisAPIServerURL, string _bNesisDeveloperId)
        {
            string result = "Bad API parameters: ";
            try
            {
                if (string.IsNullOrEmpty(api))
                {
                    result += "api content is empty, please set parameter 'api' value";
                }
                else
                if (string.IsNullOrEmpty(_Service))
                {
                    result += "Service content is empty, please set parameter 'Service' value";
                }
                else
                if (string.IsNullOrEmpty(_bNesisToken))
                {
                    result += "bNesisToken content is empty, please set parameter 'bNesisToken' value";
                }
                else
                if (string.IsNullOrEmpty(_bNesisAPIServerURL))
                {
                    result += "bNesisAPIServerURL content is empty, please set parameter 'bNesisAPIServerURL' value";
                }
                else
                if (string.IsNullOrEmpty(_bNesisDeveloperId))
                {
                    result += "bNesisDeveloperId content is empty, please set parameter 'bNesisDeveloperId' value";
                }
                else
                {
                    api = api.Insert(1,
                        "'service':'" + _Service + "'," +
                        "'token':'" + _bNesisToken + "'," +
                        "'server':'" + _bNesisAPIServerURL + "'," +
                        "'devid':'" + _bNesisDeveloperId + "',");
                    api = api.Replace('\'', '"');

                    using (HttpClient client = new HttpClient())
                    {
                        if (Uri.TryCreate(_bNesisAPIServerURL, UriKind.Absolute, out var uri))
                        {
                            client.BaseAddress = uri;
                            client.DefaultRequestHeaders.Accept.Clear();
                            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));

                            byte[] byt = System.Text.Encoding.UTF8.GetBytes(api);
                            string strModified = Convert.ToBase64String(byt);
                            strModified = "Base64String" + strModified;

                            var response = client.PostAsync("api/serviceclient/callJson", new StringContent($"={strModified}", Encoding.UTF8, "application/x-www-form-urlencoded")).Result;

                            if (response.IsSuccessStatusCode)
                            {
                                var newResponse = new HttpResponseMessage(HttpStatusCode.OK)
                                {
                                    Content = new StreamContent(response.Content.ReadAsStreamAsync().Result)
                                };
                                newResponse.Content.Headers.ContentType = response.Content.Headers.ContentType;
                                result = newResponse.Content.ReadAsStringAsync().Result;                                
                                if (string.IsNullOrEmpty(result) || result.ToLower().Equals("null"))
                                {
                                    result = "The service return empty result, it maybe you need REFRESH bNesis Token for access to this service, cose token live time is end";
                                }
                            }
                            else
                            {
                                result = "bNesis API server response, API call not success, HTTP Status code: " + response.StatusCode + " " + response.ReasonPhrase;
                            }
                           
                            return result;
                        }
                        else
                        {
                            result += "_bNesisAPIServerURL not is valid URL format, use 'https://server2.bnesis.com' like sample";
                        }
                    }
                }
            }
            catch (Exception e)
            {
                result = "bNesis API Server or API parameters problem (please check your service access bNesis token first): " + e.Message;
            }
            return result;
        }

    }
}
