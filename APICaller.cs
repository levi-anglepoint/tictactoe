using System.Net;
using System.Net.Http.Headers;

namespace TicTacToeBot_EmmaLevi
{
    public class APICaller
    {
        private HttpClient client;

        public async Task<string> PostGenerate(string endpoint)
        {
            client = new HttpClient();

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json")); // text/plain // application/json

            var baseUrl = "https://localhost:7046/";
            string url = baseUrl + endpoint;

            var res = await client.PostAsync(url, null);
            var json = await res.Content.ReadAsStringAsync();

            Console.Write(json);

            return json;
        }

        public async Task<string> Get(string endpoint)
        {
            client = new HttpClient();

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json")); // text/plain // application/json

            var baseUrl = "https://localhost:7046/";
            string url = baseUrl + endpoint;

            var json = await client.GetStringAsync(url);

            Console.Write(json);

            return json;
        }

        public async Task<string> Put(string endpoint)
        {
            client = new HttpClient();

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json")); // text/plain // application/json

            var baseUrl = "https://localhost:7046/";
            string url = baseUrl + endpoint;

            var res = await client.PutAsync(url, null);
            var json = await res.Content.ReadAsStringAsync();

            Console.Write(json);

            return json;
        }
    }
}
