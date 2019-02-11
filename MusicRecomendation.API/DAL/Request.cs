using MusicRecomendation.API.DAL.interfaces;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicRecomendation.API.DAL
{
    public class Request : IRequest
    {

        public RestRequest Create(string apiSubPath, int method, IEnumerable<string[]> headers = null, IEnumerable<string[]> parameters = null, object body = null)
        {
            var request = new RestRequest(apiSubPath, (Method)method);
            
            if (body != null)
                request.AddBody(body);
            if (parameters != null)
                foreach (var item in parameters)
                    request.AddParameter(item[0], item[1]);

            if (headers != null)
                foreach (var item in headers)
                    request.AddHeader(item[0], item[1]);

            return request;
        }
    }
}
