using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TicTacToeBot_EmmaLevi
{
    public class APICaller
    {
        private HttpClient client;

        public async Task<ResponseObject> Post(string endpoint)
        {
            client = new HttpClient();

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json")); // text/plain // application/json

            var baseUrl = "https://localhost:7046/";
            string url = baseUrl + endpoint;

            var res = await client.PostAsync(url, null);
            var json = await res.Content.ReadAsStringAsync();

            Console.Write(json);

            try
            {
                var parsedJson = JsonSerializer.Deserialize<ResponseObject>(json);
                return parsedJson;
            }
            catch
            {
                Console.WriteLine("Error parsing json response");
            }
            return null;
        }

        /// <summary>
        /// GetGameStatus always
        /// </summary>
        /// <param name="endpoint"></param>
        /// <returns></returns>
        public async Task<ResponseObject> Get(string endpoint)
        {
            client = new HttpClient();

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json")); // text/plain // application/json

            var baseUrl = "https://localhost:7046/";
            string url = baseUrl + endpoint;

            var json = await client.GetStringAsync(url);
            Console.Write(json);

            try
            {
                var parsedJson = JsonSerializer.Deserialize<ResponseObject>(json);
                return parsedJson;
            }
            catch
            {
                Console.WriteLine("Error parsing json response");
            }
            return null;
        }

        /// <summary>
        /// JoinGame always
        /// </summary>
        /// <param name="endpoint"></param>
        /// <returns></returns>
        public async Task<ResponseObject> Put(string endpoint)
        {
            client = new HttpClient();

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json")); // text/plain // application/json

            var baseUrl = "https://localhost:7046/";
            string url = baseUrl + endpoint;

            var res = await client.PutAsync(url, null);
            var json = await res.Content.ReadAsStringAsync();

            try
            {
                var parsedJson = JsonSerializer.Deserialize<ResponseObject>(json);
                return parsedJson;
            }
            catch
            {
                Console.WriteLine("Error parsing json response");
            }
            return null;
        }
    }
}
