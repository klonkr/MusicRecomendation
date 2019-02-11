using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicRecomendation.API.DAL.interfaces
{
    public interface IRepository
    {
        T Read<T>(string apiUrl, string resource, int method, IEnumerable<string[]> headers, IEnumerable<string[]> parameters) where T : new();
    }
}
