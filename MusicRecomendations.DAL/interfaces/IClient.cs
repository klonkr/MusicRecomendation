using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicRecomendations.DAL.interfaces
{
    public interface IClient
    {
        RestClient Create(string apiUrl);
    }
}
