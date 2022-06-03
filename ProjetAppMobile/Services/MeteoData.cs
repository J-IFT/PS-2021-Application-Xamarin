using Newtonsoft.Json;
using ProjetAppMobile.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ProjetAppMobile.Services
{
    public class MeteoData
    {
        public static string OpenWeatherMapEndpoint = "https://api.openweathermap.org/data/2.5/weather?q=";
        public static string OpenWeatherMapAPIKey = "token_here";
        HttpClient _httpClient = new HttpClient();

        public async Task<List<string>> GetAllMeteos(string ville)
        {
            List<string> meteo = new List<string>();
            var url = OpenWeatherMapEndpoint + ville + "&lang=fr&units=metric&APPID=" + OpenWeatherMapAPIKey;
            var json = await _httpClient.GetAsync(url);
            try
            {
                var response = await json.Content.ReadAsStringAsync();
                Meteo WeatherDecomposed = JsonConvert.DeserializeObject<Meteo>(response);
                var retour = WeatherDecomposed.weather[0].description;
                meteo.Add(retour);
                retour = WeatherDecomposed.main.temp.ToString();
                meteo.Add(retour);
                return meteo;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }

            return null;
        }
    }
}
