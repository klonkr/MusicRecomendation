using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MusicRecomendation.API.Models
{
    public class SearchResult
    {
        public IEnumerable<Album> Albums { get; set; }
        public Artist Artists { get; set; }
        public IEnumerable<Playlist> Playlists { get; set; }
        public Track Tracks { get; set; }
        public string Genres { get; set; }

        public HttpStatusCode StatusCode { get; set; }
        public string StatusCodeDescription { get; set; }
    }
}
