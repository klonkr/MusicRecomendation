using MusicRecomendations.DAL.interfaces;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace MusicRecomendations.DAL
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public IClient Client { get; set; }
        public IRequest Request { get; set; }
        public Repository(IClient client, IRequest request)
        {
            Client = client;
            Request = request;
        }
        public bool Create(T t)
        {
            throw new NotImplementedException();
        }

        public bool Delete(T t)
        {
            throw new NotImplementedException();
        }

        public RestResponse<T> Read(params Expression<Func<T, object>>[] includes)
        {
            RestClient client = Client.Create("someurl");
            RestRequest request = Request.Create("some sub path", (int)Method.GET, new List<string[]>() { new string[] { "apikey", "aeutt" }}, new List<string[]>() { new string[] { "apikey", "aeutt" }});

            RestResponse<T> response = (RestResponse<T>)client.Execute(request);
            //var content = response.Data;
            return response;
        }

        public bool Update(T t)
        {
            throw new NotImplementedException();
        }

        IQueryable<T> IRepository<T>.Read(params Expression<Func<T, object>>[] includes)
        {
            throw new NotImplementedException();
        }
    }
}
