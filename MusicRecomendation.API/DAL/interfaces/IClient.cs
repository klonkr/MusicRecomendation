using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicRecomendation.API.DAL.interfaces
{
    public interface IClient
    {
        RestClient Create(string apiUrl);
    }
}
