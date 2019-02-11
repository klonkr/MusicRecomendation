using MusicRecomendation.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicRecomendation.API.DAL.interfaces
{
    public interface IAuthorization
    {
        Token Get(/*string apiUrl, string resource, int method, IEnumerable<string[]> parameters, IEnumerable<string[]> headers, bool getToken*/);
    }
}
