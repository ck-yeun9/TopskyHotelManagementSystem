using jvncorelib.EntityLib;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace EOM.TSHotelManagement.Shared
{
    /// <summary>
    /// 文件上传帮助类
    /// </summary>
    public static class HttpHelper
    {
#if DEBUG
        /// <summary>
        /// WebApi URL
        /// </summary>
        public const string apiUrl = "http://localhost:63001/api/";
#elif RELEASE
        /// <summary>
        /// WebApi URL
        /// </summary>
        public const string apiUrl = "https://tshotel.oscode.top/api/";
#endif

        public class IgnoreNullValuesConverter : JsonConverter
        {
            private readonly bool _convertEmptyStringToNull;

            public IgnoreNullValuesConverter(bool convertEmptyStringToNull = false)
            {
                _convertEmptyStringToNull = convertEmptyStringToNull;
            }

            public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
            {
                JObject obj = JObject.FromObject(value ?? new object(), serializer);

                foreach (var prop in obj.Properties().ToList())
                {
                    if (prop.Value == null || string.IsNullOrEmpty(prop.Value.ToString()))
                    {
                        if (_convertEmptyStringToNull && prop.Value?.Type == JTokenType.String)
                        {
                            prop.Value = JValue.CreateNull();
                        }
                        else
                        {
                            prop.Remove();
                        }
                    }
                }

                obj.WriteTo(writer);
            }

            public override object ReadJson(JsonReader? reader, Type? objectType, object? existingValue, JsonSerializer? serializer)
            {
                throw new NotImplementedException();
            }

            public override bool CanConvert(Type? objectType)
            {
                return objectType == typeof(JObject);
            }

            public override bool CanRead => false;
        }

        /// <summary>
        /// 使用 RestSharp 上传文件（multipart/form-data）
        /// </summary>
        /// <param name="url">API地址</param>
        /// <param name="filePath">本地文件路径</param>
        /// <param name="additionalParams">其他参数</param>
        /// <param name="dicHeaders">自定义Headers</param>
        /// <returns>响应结果</returns>
        public static ResponseMsg UploadFile(
            string url,
            string filePath,
            Dictionary<string, string>? additionalParams = null,
            Dictionary<string, string>? dicHeaders = null)
        {
            var sourceStr = url.Replace("​", string.Empty);

            var requestUrl = apiUrl + sourceStr;

            var client = new RestClient(requestUrl);
            var request = new RestRequest();


            request.AddHeader("Content-Type", "multipart/form-data");
            request.AddHeader("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.0.0 Safari/537.36");


            if (!string.IsNullOrEmpty(LoginInfo.UserToken))
            {
                request.AddHeader("Authorization", $"Bearer {LoginInfo.UserToken}");
            }


            if (dicHeaders != null)
            {
                foreach (var key in dicHeaders.Keys)
                {
                    request.AddHeader(key, dicHeaders[key]);
                }
            }

            if (additionalParams != null)
            {
                foreach (var kv in additionalParams)
                {
                    request.AddParameter(kv.Key, kv.Value, ParameterType.GetOrPost);
                }
            }

            request.AddFile(
                name: "file",
                path: filePath,
                contentType: GetMimeType(filePath)
            );

            var response = client.ExecutePost(request);

            return new ResponseMsg
            {
                statusCode = (int)response.StatusCode,
                message = response.Content
            };
        }

        /// <summary>
        /// 统一请求方法
        /// </summary>
        /// <param name="url"></param>
        /// <param name="json"></param>
        /// <param name="dic"></param>
        /// <returns></returns>
        public static ResponseMsg Request(string url)
        {
            ResponseMsg msg = new ResponseMsg();

            //处理url
            var sourceStr = url.Replace("​", string.Empty);

            var requestUrl = apiUrl + sourceStr;

            msg = DoGet(requestUrl);

            return msg;
        }

        /// <summary>
        /// 统一请求方法
        /// </summary>
        /// <param name="url"></param>
        /// <param name="json"></param>
        /// <param name="dic"></param>
        /// <returns></returns>
        public static ResponseMsg Request(string url, string? json = null)
        {
            ResponseMsg msg = new ResponseMsg();

            //处理url
            var sourceStr = url.Replace("​", string.Empty);

            var requestUrl = apiUrl + sourceStr;

            if (!json.IsNullOrEmpty())
            {
                msg = DoPost(requestUrl, json);
            }
            else
            {
                msg = DoGet(requestUrl);
            }

            return msg;
        }

        /// <summary>
        /// 统一请求方法
        /// </summary>
        /// <param name="url"></param>
        /// <param name="json"></param>
        /// <param name="dic"></param>
        /// <returns></returns>
        public static ResponseMsg Request(string url, Dictionary<string, string>? dic = null)
        {
            ResponseMsg msg = new ResponseMsg();

            //处理url
            var sourceStr = url.Replace("​", string.Empty);

            var requestUrl = apiUrl + sourceStr;

            if (!dic.IsNullOrEmpty())
            {
                msg = DoGet(requestUrl, dic);
            }
            else
            {
                msg = DoGet(requestUrl);
            }

            return msg;
        }

        /// <summary>
        /// GET请求
        /// </summary>
        /// <param name="url"></param>
        /// <param name="parameters"></param>
        /// <param name="contentType"></param>
        /// <param name="referer"></param>
        /// <param name="cookie"></param>
        /// <param name="dicHeaders"></param>
        /// <returns></returns>
        public static ResponseMsg DoGet(string url, IDictionary<string, string>? parameters = null, string? contentType = null, string? referer = null, string? cookie = null, Dictionary<string, string>? dicHeaders = null)
        {
            if (parameters != null && parameters.Count > 0)
            {
                if (url.Contains("?"))
                {
                    url = url + "&" + BuildQuery(parameters);
                }
                else
                {
                    url = url + "?" + BuildQuery(parameters);
                }
            }

            var reponse = new RestResponse();
            var client = new RestClient(url);
            var request = new RestRequest();

            string? resultContent = null;
            RestResponse? rsp = null;

            try
            {
                if (!string.IsNullOrEmpty(referer))
                {
                    request.AddHeader("Referer", referer);
                }

                if (!string.IsNullOrEmpty(cookie))
                {
                    request.AddHeader("Cookie", cookie);
                }

                request.AddHeader("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.0.0 Safari/537.36");

                if (dicHeaders != null)
                {
                    foreach (var key in dicHeaders.Keys)
                    {
                        request.AddHeader(key, dicHeaders[key]);
                    }
                }

                var token = LoginInfo.UserToken;

                request.AddHeader("Authorization", string.Format("Bearer {0}", token));
                rsp = client.ExecuteGet(request);

                resultContent = rsp.Content;
            }
            catch (Exception)
            {
                throw;
            }

            return new ResponseMsg() { message = resultContent };
        }

        /// <summary>
        /// Post请求
        /// </summary>
        /// <param name="url"></param>
        /// <param name="jsonParam"></param>
        /// <param name="contentType"></param>
        /// <param name="referer"></param>
        /// <param name="cookie"></param>
        /// <param name="dicHeaders"></param>
        /// <returns></returns>
        public static ResponseMsg DoPost(string url, string? jsonParam = null, string? contentType = null, string? referer = null, string? cookie = null, Dictionary<string, string>? dicHeaders = null)
        {
            var reponse = new RestResponse();
            var client = new RestClient(url);
            var request = new RestRequest();
            if (!string.IsNullOrEmpty(contentType))
            {
                request.AddHeader("Content-Type", contentType);
            }
            else
            {
                request.AddHeader("Content-Type", ContentType.Json);
            }

            if (!string.IsNullOrEmpty(referer))
            {
                request.AddHeader("Referer", referer);
            }

            if (!string.IsNullOrEmpty(cookie))
            {
                request.AddHeader("Cookie", cookie);
            }

            if (dicHeaders != null)
            {
                foreach (var key in dicHeaders.Keys)
                {
                    request.AddHeader(key, dicHeaders[key]);
                }
            }

            request.AddHeader("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.0.0 Safari/537.36");

            request.AddBody(jsonParam!);

            var token = LoginInfo.UserToken;

            request.AddHeader("Authorization", string.Format("Bearer {0}", token));

            if (LoginInfo.NeedRefreshCsrfToken)
            {
                CsrfTokenHelper.RefreshCsrfToken();
            }

            request.AddHeader("X-CSRF-TOKEN-HEADER", LoginInfo.CsrfToken ?? CsrfTokenHelper.RefreshCsrfToken());

            reponse = client.ExecutePost(request);

            var responseString = reponse.Content;

            return new ResponseMsg() { message = responseString };
        }

        /// <summary>
        /// 获取文件的MIME类型
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string GetMimeType(string fileName)
        {
            var extension = Path.GetExtension(fileName).ToLowerInvariant();
            return extension switch
            {
                ".jpg" => "image/jpeg",
                ".jpeg" => "image/jpeg",
                ".png" => "image/png",
                _ => "application/octet-stream"
            };
        }

        /// <summary>
        /// 组装普通文本请求参数。
        /// </summary>
        /// <param name="parameters">Key-Value形式请求参数字典</param>
        /// <returns>URL编码后的请求数据</returns>
        public static string BuildQuery(IDictionary<string, string> parameters)
        {
            StringBuilder postData = new StringBuilder();
            bool hasParam = false;

            IEnumerator<KeyValuePair<string, string>> dem = parameters.GetEnumerator();
            while (dem.MoveNext())
            {
                string name = dem.Current.Key;
                string value = dem.Current.Value;
                // 忽略参数名或参数值为空的参数
                if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(value))
                {
                    if (hasParam)
                    {
                        postData.Append("&");
                    }

                    postData.Append(name);
                    postData.Append("=");
                    postData.Append(UrlEncode(value, Encoding.UTF8));
                    hasParam = true;
                }
            }

            return postData.ToString();
        }

        /**
        * C#的URL encoding有两个问题：
        * 1.左右括号没有转移（Java的URLEncoder.encode有）
        * 2.转移符合都是小写的，Java是大写的
        */
        public static string? UrlEncode(string? str, Encoding e)
        {
            var REG_URL_ENCODING = new Regex(@"%[a-f0-9]{2}");

            if (str == null)
            {
                return null;
            }

            String stringToEncode = HttpUtility.UrlEncode(str, e).Replace("+", "%20").Replace("*", "%2A").Replace("(", "%28").Replace(")", "%29");
            return REG_URL_ENCODING.Replace(stringToEncode, m => m.Value.ToUpperInvariant());
        }

        /// <summary>
        /// Json转实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="input"></param>
        /// <returns></returns>
        public static T? JsonToModel<T>(this string input)
        {
            return JsonConvert.DeserializeObject<T>(input);
        }
    }
}
