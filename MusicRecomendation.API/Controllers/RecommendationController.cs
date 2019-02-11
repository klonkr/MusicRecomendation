using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicRecomendation.API.DAL.interfaces;
using MusicRecomendation.API.Models;
using Newtonsoft.Json;
using RestSharp;

namespace MusicRecomendation.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RecommendationController : ControllerBase
    {
        public IAuthorization Authorization{ get; set; }
        public IRepository Repository { get; set; }

        public RecommendationController(IAuthorization auth, IRepository repo)
        {
            Authorization = auth;
            Repository = repo;
        }

        public JsonResult GetGenres()
        {
            var authorize = Authorization.Get();
            var headers = new List<string[]> { new string[] { "Authorization", $"Bearer {authorize.access_token}" } };

            var result = Repository.Read<SearchResult>("https://api.spotify.com/v1/", "recommendations/available-genre-seeds", (int)Method.GET, headers, null);
            var genres = JsonConvert.DeserializeObject(result.Genres);
            return new JsonResult(genres);
        }

        [HttpPost]
        public JsonResult Get(Query query)
        {
            var authorize = Authorization.Get();
            
            var headers = new List<string[]> { new string[] { "Authorization", $"Bearer {authorize.access_token}" } };
            var parameters = new List<string[]>();

            var artists = "";

            foreach (var item in query.SeedArtists)
            {
                artists += $"{item.id}";
                if (query.SeedArtists.Last() != item)
                    artists += ",";
            }

            var tracks = "";

            foreach (var item in query.Tracks)
            {
                tracks += $"{item.id}";
                if (query.Tracks.Last() != item)
                    tracks += ",";
            }

            var genres = "";

            foreach (var item in query.Genres)
            {
                genres += $"{item.GenreName}";
                if (query.Genres.Last() != item)
                    genres += ",";
            }

            parameters.Add(new string[] { "seed_artists", artists });
            parameters.Add(new string[] { "seed_tracks", tracks });
            parameters.Add(new string[] { "seed_genres", tracks });


            foreach (var item in query.Attributes)
            {
                parameters.Add(new string[] { $"target_{item.Attribute.Item1}", item.Attribute.Item2 });
            }

            var result = Repository.Read<Recommendation>("https://api.spotify.com/v1/", "recommendations", (int)Method.GET, headers, parameters);
            return new JsonResult(result);
        }
    }
}