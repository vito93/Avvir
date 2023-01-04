using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace Avvir.UnitTest.Middleware.Core
{
    [TestClass]
    public class UnitTest1
    {
        private const string APP_PATH = "https://localhost:44358";
        private static string token;

        [TestMethod]
        public void SaveFile()
        {
            /*using (var client = new HttpClient())
            {
                var url = "https://www.theidentityhub.com/{tenant}/api/identity/v1";
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);
                var response = await client.GetStringAsync(url);
                // Parse JSON response.
            }*/

            string userName = "evgeny";
            string email = "email@mail.ru";
            string password = "avvirSotel47!";

            var registerResult = Register(userName, email, password);

            Dictionary<string, string> tokenDictionary = GetTokenDictionary(userName, password);
            token = tokenDictionary["access_token"];

            string userInfo = GetUserInfo(token);
            string values = GetValues(token);
        }

        // регистрация
        static string Register(string userName, string email, string password)
        {
            var registerModel = new
            {
                userName = email,
                email = email,
                password = password
            };
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(APP_PATH);

                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                var responseT = client.GetAsync("/api/Test/Test").Result;
                var response = client.PostAsJsonAsync("/api/Authenticate/register", registerModel).Result;
                return response.StatusCode.ToString();
            }
        }
        // получение токена
        static Dictionary<string, string> GetTokenDictionary(string userName, string password)
        {
            var pairs = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>( "grant_type", "password" ),
                    new KeyValuePair<string, string>( "username", userName ),
                    new KeyValuePair<string, string> ( "Password", password )
                };
            var content = new FormUrlEncodedContent(pairs);

            using (var client = new HttpClient())
            {
                var response =
                    client.PostAsync(APP_PATH + "/Token", content).Result;
                var result = response.Content.ReadAsStringAsync().Result;
                // Десериализация полученного JSON-объекта
                Dictionary<string, string> tokenDictionary =
                    JsonConvert.DeserializeObject<Dictionary<string, string>>(result);
                return tokenDictionary;
            }
        }

        // создаем http-клиента с токеном 
        static HttpClient CreateClient(string accessToken = "")
        {
            var client = new HttpClient();
            if (!string.IsNullOrWhiteSpace(accessToken))
            {
                client.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
            }
            return client;
        }

        // получаем информацию о клиенте 
        static string GetUserInfo(string token)
        {
            using (var client = CreateClient(token))
            {
                var response = client.GetAsync(APP_PATH + "/api/Account/UserInfo").Result;
                return response.Content.ReadAsStringAsync().Result;
            }
        }

        // обращаемся по маршруту api/values 
        static string GetValues(string token)
        {
            using (var client = CreateClient(token))
            {
                var response = client.GetAsync(APP_PATH + "/api/values").Result;
                return response.Content.ReadAsStringAsync().Result;
            }
        }
    }
}
