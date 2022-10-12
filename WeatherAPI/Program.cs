using System;
using System.Runtime.CompilerServices;
using System.Text.Json.Nodes;
using System.Net.Http;
using System.IO;
using System.Web;
using Newtonsoft.Json.Linq;

namespace WeatherAPI
{
    class Program
    {
        static void Main()
        {
            string _APIKey = "93834e1fffa7fc224993ad5a1c1be3b3";
            string city = "New York";
            var client = new HttpClient();
            
            var geolocationUrl = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={_APIKey}&units=imperial";
            var geoResponse = client.GetStringAsync(geolocationUrl).Result;

            var tempObject = JObject.Parse(geoResponse).GetValue("main").ToString();
            var currentTemp = JObject.Parse(tempObject).GetValue("temp");
            Console.WriteLine($"Current temperature in {city}: {currentTemp} degrees F");
        }
    }
}