using MusicRecomendation.API.DAL.interfaces;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicRecomendation.API.DAL
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
