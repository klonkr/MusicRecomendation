using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicRecomendation.API.Models
{
    public class Recommendation
    {
        public IEnumerable<Track> Tracks { get; set; }
    }
}
