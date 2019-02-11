using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicRecomendation.API.DAL.interfaces;
using MusicRecomendation.API.Models;
using RestSharp;

namespace MusicRecomendation.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ArtistController : ControllerBase
    {
        public IRepository Repository { get; set; }
        public IAuthorization Authorization { get; set; }

        public ArtistController(IAuthorization authorization, IRepository artistRepository)
        {
            Authorization = authorization;
            Repository = artistRepository;
        }

        public JsonResult GetArtist(string id)
        {
            var authorize = Authorization.Get();

            var headers = new List<string[]> { new string[] { "Authorization", $"Bearer {authorize.access_token}" } };
            //var parameters = new List<string[]> { new string[] { "id", id }};
            var something = Repository.Read<Artist>("https://api.spotify.com/v1", $"artists/{id}", (int)Method.GET, headers, null);
            return new JsonResult(something);
        }
    }
}