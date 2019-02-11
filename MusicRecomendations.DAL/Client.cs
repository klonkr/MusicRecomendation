using MusicRecomendations.DAL.interfaces;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicRecomendations.DAL
{
    public class Client : IClient
    {
        public RestClient Create(string apiURL)
        {
            var client = new RestClient(apiURL);

            return client;
        }
    }
}
