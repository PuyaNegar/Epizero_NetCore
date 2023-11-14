using Common.Enums;
using Common.Objects;
using Newtonsoft.Json; 
using System;
using System.Collections.Generic; 
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Threading.Tasks; 

namespace Common.Service
{
    public class HttpClientComponent : IDisposable
    {
        public async Task<ApiResponseDTOModel<TResponseResult>> Send<TResponseResult>(ApiRequestDTOModel apiRequest)
        {
            using (var httpClient = new HttpClient())
            {
                var httpRequestMessage = new HttpRequestMessage( ConvertApiTypeToMethod(apiRequest.ApiType) ,  apiRequest.Url);

                 

                foreach (var item in apiRequest.Headers)
                {
                    httpClient.DefaultRequestHeaders.Add(item.Key, item.Value);
                }

                if (apiRequest.HttpRequestDataType == HttpRequestDataType.X_Form_Url_Encoded)
                {
                    var formContent = new FormUrlEncodedContent(await ToFormUrlEncodedContent(apiRequest.Data));
                    httpRequestMessage.Content = formContent;
                    httpRequestMessage.Content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
                }

                if (apiRequest.HttpRequestDataType == HttpRequestDataType.Json)
                {
                    var jsonContent = new StringContent(JsonConvert.SerializeObject(apiRequest.Data));
                    httpRequestMessage.Content = jsonContent;
                    httpRequestMessage.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                }

                var response = await httpClient.SendAsync(httpRequestMessage);

                if (response.IsSuccessStatusCode)
                {
                    var result = JsonConvert.DeserializeObject<TResponseResult>(await response.Content.ReadAsStringAsync());

                    var apiResponse = new ApiResponseDTOModel<TResponseResult>()
                    {
                        responseResult = result,
                        Headers = ConvertResponseHeadersToList(response.Headers)
                    };
                    return apiResponse;
                }
                else
                {
                    throw new Exception("خطای داخلی بانک");
                }
            }
        }
        //==============================================================
        HttpMethod ConvertApiTypeToMethod(ApiType apiType)
        {
            HttpMethod method = HttpMethod.Get;
            switch (apiType)
            {
                case ApiType.DELETE:
                    method = HttpMethod.Delete;
                    break;
                case ApiType.GET:
                    method = HttpMethod.Get;
                    break;
                case ApiType.POST:
                    method = HttpMethod.Post;
                    break;
                case ApiType.PUT:
                    method = HttpMethod.Put;
                    break; 
            }
            return method;
        }
        //==============================================================
        async Task<List<KeyValuePair<string, string>>> ToFormUrlEncodedContent(object data)
        {
            Type type = data.GetType();
            var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var keyValues = new List<KeyValuePair<string, string>>();
            foreach (var property in properties)
            {
                var key = property.Name;
                var value = property.GetValue(data)?.ToString() ?? "";
                keyValues.Add(new KeyValuePair<string, string>(key, value));
            }
            return keyValues;
            //var content = new FormUrlEncodedContent(keyValues);
            //return await content.ReadAsStringAsync();
        }
        //==============================================================
        List<KeyValuePair<string, string>> ConvertResponseHeadersToList(HttpResponseHeaders headers)
        {
            var headerList = new List<KeyValuePair<string, string>>(); 
            foreach (var header in headers)
            {
                headerList.Add(new KeyValuePair<string, string>(header.Key, string.Join(",", header.Value)));
            } 
            return headerList;
        }
        //==============================================================
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
