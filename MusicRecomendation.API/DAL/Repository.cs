using MusicRecomendation.API.DAL.interfaces;
using MusicRecomendation.API.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicRecomendation.API.DAL
{
    public class Repository : IRepository
    {
        public IClient Client { get; set; }
        public IRequest Request { get; set; }
        public Repository(IClient client, IRequest request)
        {
            Client = client;
            Request = request;
        }
        //public Artist Read(string apiUrl, string resource, int method, IEnumerable<string[]> headers, IEnumerable<string[]> parameters) 
        //{
        //    RestClient client = Client.Create(apiUrl);
        //    RestRequest request = Request.Create(resource, method, headers, parameters);

        //    IRestResponse<Artist> response = client.Execute<Artist>(request);
        //    var result = response.Data == null ? new Artist() : response.Data;
        //    result.StatusCode = response.StatusCode;
        //    result.StatusCodeDescription = response.StatusDescription;

        //    var content = response.Data;
        //    return result;
        //}

        T IRepository.Read<T>(string apiUrl, string resource, int method, IEnumerable<string[]> headers, IEnumerable<string[]> parameters)
        {
            RestClient client = Client.Create(apiUrl);
            RestRequest request = Request.Create(resource, method, headers, parameters);

            IRestResponse<T> response = client.Execute<T>(request);
            var result = response.Data == null ? new T() : response.Data;
           
            return result;
        }
    }
}
