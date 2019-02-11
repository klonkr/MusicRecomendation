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
    public class TrackController : ControllerBase
    {
        public IAuthorization Authorization { get; set; }
        public IRepository Repository { get; set; }

        public TrackController(IAuthorization auth, IRepository repository)
        {
            Authorization = auth;
            Repository = repository;
        }

        [HttpGet]
        public JsonResult GetTrack(string id)
        {
            var auth = Authorization.Get();

            var headers = new List<string[]> { new string[] { "Authorization", $"Bearer {auth.access_token}" } };
            var something = Repository.Read<Track>("https://api.spotify.com/v1", $"tracks/{id}", (int)Method.GET, headers, null);
            return new JsonResult(something);
        }
    }
}