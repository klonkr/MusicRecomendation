using MusicRecomendations.DAL.interfaces;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicRecomendations.DAL
{
    public class Request : IRequest
    {
        public RestRequest Create(string apiSubPath, int method, IEnumerable<string[]> parameters, IEnumerable<string[]> headers)
        {
            var request = new RestRequest(apiSubPath, (Method)method);

            foreach (var item in parameters)
                request.AddParameter(item[0], item[1]);

            foreach (var item in headers)
                request.AddHeader(item[0], item[1]);

            return request;
        }
    }
}
