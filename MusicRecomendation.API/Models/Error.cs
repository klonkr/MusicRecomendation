using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicRecomendation.API.Models
{
    public class Error
    {
        public int Status { get; set; }
        public string Message { get; set; }
    }
}
