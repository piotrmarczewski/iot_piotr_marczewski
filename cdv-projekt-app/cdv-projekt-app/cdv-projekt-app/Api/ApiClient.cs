using cdv_projekt_app.Models;
using Newtonsoft.Json;
using RestEase;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace cdv_projekt_app.Api
{
    public class ApiClient
    {
        #region User

        public static async Task<bool> RegisterUser(string name, string email, string password, string passwordConfirmation)
        {
            var register = new Register()
            {
                name = name,
                email = email,
                password = password,
                password_confirmation = passwordConfirmation
            };

            var httpClient = new HttpClient();

            var jsonSerialized = JsonConvert.SerializeObject(register);
            var content = new StringContent(jsonSerialized, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync(Settings.Url + "/auth/register", content);
            if (!response.IsSuccessStatusCode) return false;
            return true;
        }

        public static async Task<bool> LoginUser(string email, string password)
        {
            var login = new Login()
            {
                email = email,
                password = password
            };

            var httpClient = new HttpClient();

            var jsonSerialized = JsonConvert.SerializeObject(login);
            var content = new StringContent(jsonSerialized, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync(Settings.Url + "/auth/login", content);
            if (!response.IsSuccessStatusCode) return false;

            var jsonResult = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<LoginToken>(jsonResult);

            Preferences.Set("accessToken", result.access_token);
            Preferences.Set("userId", result.user_id);
            Preferences.Set("userName", result.user_name);

            return true;
        }

        public static async Task<bool> LogoutUser()
        {
            var httpClient = new HttpClient();

            var content = new StringContent("{}", Encoding.UTF8, "application/json");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("accessToken", string.Empty));

            var response = await httpClient.PostAsync(Settings.Url + "/auth/logout", content);
            if (!response.IsSuccessStatusCode) return false;


            return true;
        }

        public static async Task<User> GetUserInfo()
        {
            var httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("accessToken", string.Empty));
            var response = await httpClient.GetStringAsync(Settings.Url + "/auth/user-profile");

            return JsonConvert.DeserializeObject<User>(response);
        }

        #endregion


        #region UserWeight
        public static async Task<bool> AddWeightUser(decimal weight, DateTime date, string description)
        {
            var register = new AddWeight()
            {
                weight = weight,
                date = date,
                description = description
            };

            var httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("accessToken", string.Empty));
            var jsonSerialized = JsonConvert.SerializeObject(register);
            var content = new StringContent(jsonSerialized, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync(Settings.Url + "/weight", content);
            if (!response.IsSuccessStatusCode) return false;
            return true;
        }

        public static async Task<List<WeightInfo>> GetWeightUser()
        {
            var httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("accessToken", string.Empty));
            var response = await httpClient.GetStringAsync(Settings.Url + "/weight");

            return JsonConvert.DeserializeObject<List<WeightInfo>>(response);
        }

        public static async Task<WeightInfo> GetOneWeightUser(string id)
        {
            var httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("accessToken", string.Empty));
            var response = await httpClient.GetStringAsync(Settings.Url + "/weight/" + id);

            return JsonConvert.DeserializeObject<WeightInfo>(response);
        }

        #endregion
    }
}
