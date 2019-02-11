using Microsoft.Extensions.Options;
using MusicRecomendation.API;
using MusicRecomendation.API.DAL.interfaces;
using MusicRecomendation.API.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicRecomendation.API.DAL
{
    public class Authorization : IAuthorization
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
        //public Token Get(string apiUrl, string resource, int method, IEnumerable<string[]> parameters, IEnumerable<string[]> headers, bool getToken)
        //{
        //    IRestClient client = Client.Create(apiUrl);
        //    IRestRequest request = Request.Create(resource, method, parameters, headers);
        //    if(getToken)
        //        request.AddParameter("grant_type", "client_credentials", ParameterType.GetOrPost);

        //    IRestResponse<Token> response = client.Execute<Token>(request);
        //    //var token = response.Content.
        //    return response.Data;
        //}

        public Token Get()
        {
            var clientIdSecret = $"{Config.Value.ClientId}:{Config.Value.ClientSecret}";
            var secret = MusicRecomendation.API.ExtensionMethods.Extensions.ToBase64(clientIdSecret);

            var headers = new List<string[]>() { new string[] { "Authorization", $"Basic {secret}" },
            new string[] { "Content-Type", "application/x-www-form-urlencoded" } };

            //var token = Authorization.Get("https://accounts.spotify.com", "api/token", (int)Method.POST, null, headers, true);
            //Authorization a = new Authorization();
            //return new JsonResult(token);

            IRestClient client = Client.Create("https://accounts.spotify.com");
            IRestRequest request = Request.Create("api/token", (int)Method.POST, headers);
            request.AddParameter("grant_type", "client_credentials", ParameterType.GetOrPost);

            IRestResponse<Token> response = client.Execute<Token>(request);
            //var token = response.Content.
            return response.Data;
        }
    }
}
