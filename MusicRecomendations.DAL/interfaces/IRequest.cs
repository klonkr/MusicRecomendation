using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicRecomendations.DAL.interfaces
{
    public interface IRequest
    {
        RestRequest Create(string apiSubPath, int method, IEnumerable<string[]> parameters, IEnumerable<string[]> headers);
    }
}
