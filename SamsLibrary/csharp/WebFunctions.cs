using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace SamsLibrary
{
    public class WebFunctions
    {
        const string apiKey = "";
        public WebFunctions()
        {

        }

        public async Task GetWeather(string option = "Melbourne,AU")
        {
            string response;

            using (var http = new HttpClient())
            {
                http.DefaultRequestHeaders.Add("Cache-Control", "no-cache");
                http.DefaultRequestHeaders.Add("Authorization", "Bearer " + "token");
                response = await http.GetStringAsync($"http://api.openweathermap.org/data/2.5/weather?q={option}&appid={apiKey}&units=metric").ConfigureAwait(false);
            }
        }

        //Json Deserialize
        public async Task Time(string arg)
        {
            using (var http = new HttpClient())
            {
                var res = await http.GetStringAsync($"https://maps.googleapis.com/maps/api/geocode/json?address={arg}&key=XXX").ConfigureAwait(false);
                var obj = JsonConvert.DeserializeObject<string>(res);
            }

        }
    }
}

