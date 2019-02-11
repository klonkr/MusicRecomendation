using MusicRecomendation.API.DAL.interfaces;
using MusicRecomendation.API.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace MusicRecomendation.API.DAL
{
    public class SearchRepository : ISearchRepository
    {
        public IClient Client { get; set; }
        public IRequest Request { get; set; }
        public SearchRepository(IClient client, IRequest request)
        {
            Client = client;
            Request = request;
        }
        
        public SearchResult Read(string apiUrl, string resource, int method, IEnumerable<string[]> headers, IEnumerable<string[]> parameters)
        {
            RestClient client = Client.Create(apiUrl);
            RestRequest request = Request.Create(resource, method, headers, parameters);

            IRestResponse<SearchResult> response = client.Execute<SearchResult>(request);
            var result = response.Data == null ? new SearchResult() : response.Data;
            result.StatusCode = response.StatusCode;
            result.StatusCodeDescription = response.StatusDescription;

            //var content = response.Data;
            return result;
        }
    }
}
