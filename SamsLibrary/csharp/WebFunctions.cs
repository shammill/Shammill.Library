using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Sockets;
using System.Net;
using System.Text;

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

        public async Task SendUDP()
        {
            Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram,
            ProtocolType.Udp);

            IPAddress serverAddr = IPAddress.Parse("192.168.2.255");

            IPEndPoint endPoint = new IPEndPoint(serverAddr, 11000);

            string text = "Hello";
            byte[] send_buffer = Encoding.ASCII.GetBytes(text);

            sock.SendTo(send_buffer, endPoint);
        }
    }
}

