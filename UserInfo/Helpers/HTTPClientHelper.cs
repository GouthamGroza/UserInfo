using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace UserInfo.Helpers
{
    public class HTTPClientHelper
    {
        public async static Task<T> Get<T>(string url)
        {
            T result = default(T);
            using (var httpClient = new HttpClient())
            {
                var response = httpClient.GetAsync(new System.Uri(url)).Result;
                
                response.EnsureSuccessStatusCode();

               await response.Content.ReadAsStringAsync().ContinueWith((Task<string> res) =>
                {
                    if (res.IsFaulted)
                    {
                        throw res.Exception;
                    }
                    else
                    {
                        result = JsonConvert.DeserializeObject<T>(res.Result);
                    }
                });


            }
            return result;

        }
    }
}
