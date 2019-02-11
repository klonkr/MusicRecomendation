using MusicRecomendation.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicRecomendation.API.DAL.interfaces
{
    public interface IArtistRepository
    {
        Artist Read(string apiUrl, string resource, int method, IEnumerable<string[]> headers, IEnumerable<string[]> parameters);
    }
}
