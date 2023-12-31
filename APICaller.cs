﻿using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace TicTacToeBot_EmmaLevi
{
    public class APICaller
    {
        private HttpClient client;
        private string baseUrl = "https://gamemanager20230712151202.azurewebsites.net/"; // https://gamemanager20230712151202.azurewebsites.net/
        //private string baseUrl = "https://localhost:7046/"; // https://localhost:7046/

        public async Task<ResponseObject> Post(string endpoint, object? body = null)
        {
            client = new HttpClient();

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json")); // text/plain // application/json

            string url = baseUrl + endpoint;

            HttpResponseMessage res = null;
            if (body != null)
            {
                string jsonPost = JsonSerializer.Serialize(body);
                var content = new StringContent(jsonPost, Encoding.UTF8, "application/json");
                res = await client.PostAsync(url, content);
            }
            else
            {
                Landmine mine = new Landmine();
                string jsonPost = JsonSerializer.Serialize(mine);
                var content = new StringContent(jsonPost, Encoding.UTF8, "application/json");
                res = await client.PostAsync(url, content);
            }

            if (!res.IsSuccessStatusCode)
            {
                Console.WriteLine("Failed to post");
                Console.WriteLine(res.StatusCode);
                Console.WriteLine(res.ReasonPhrase);
                Console.WriteLine(res.ToString());

                return null;
            }

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

            string url = baseUrl + endpoint;

            var json = await client.GetStringAsync(url);

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
        public async Task<ResponseObject> Put(string endpoint, object? body = null)
        {
            client = new HttpClient();

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json")); // text/plain // application/json

            string url = baseUrl + endpoint;
            HttpResponseMessage res = null;
            if (body != null)
            {
                string jsonPost = JsonSerializer.Serialize(body);
                var content = new StringContent(jsonPost, Encoding.UTF8, "application/json");
                res = await client.PutAsync(url, content);
            }
            else
            {
                Landmine mine = new Landmine();
                string jsonPost = JsonSerializer.Serialize(mine);
                var content = new StringContent(jsonPost, Encoding.UTF8, "application/json");
                res = await client.PutAsync(url, content);
            }

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
