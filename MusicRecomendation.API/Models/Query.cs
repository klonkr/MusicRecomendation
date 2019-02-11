using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicRecomendation.API.Models
{
    public class Query
    {
        public int Limit { get; set; }
        public string Market { get; set; }
        public IEnumerable<Artist> SeedArtists { get; set; }
        public IEnumerable<Genre> Genres { get; set; }
        public IEnumerable<Track> Tracks { get; set; }
        public IEnumerable<TrackAttribute> Attributes { get; set; }
    }
}
