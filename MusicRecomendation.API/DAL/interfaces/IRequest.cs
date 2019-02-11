using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicRecomendation.API.DAL.interfaces
{
    public interface IRequest
    {
        RestRequest Create(string apiSubPath, int method, IEnumerable<string[]> headers = null, IEnumerable<string[]> parameters = null, object body = null);
    }
}
