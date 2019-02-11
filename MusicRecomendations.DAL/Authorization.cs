using Microsoft.Extensions.Options;
using MusicRecomendation.API;
using MusicRecomendations.DAL.interfaces;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicRecomendations.DAL
{
    public class Authorization
    {
        public IOptions<ApplicationConfig> Config { get; set; }
        public IClient Client { get; set; }
        public IRequest Request { get; set; }

        public Authorization(IOptions<ApplicationConfig> config, IClient client, IRequest request)
        {
            Config = config;
            Client = client;
            Request = request;
        }
        public void Get()
        {
            RestClient client = Client.Create("apiUrl");
            RestRequest request = Request.Create("some sub path", (int)Method.GET,
                new List<string[]>() { new string[] { "apikey", "aeutt" } },
                new List<string[]>() { new string[] { "apikey", "aeutt" } });

        }
    }
}
