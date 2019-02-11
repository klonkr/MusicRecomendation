using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Text;
using MusicRecomendation.API.Models;

namespace MusicRecomendation.API.DAL.interfaces
{
    public interface ISearchRepository
    {
        SearchResult Read(string apiUrl, string resource, int method, IEnumerable<string[]> headers, IEnumerable<string[]> parameters);
        
    }
}
