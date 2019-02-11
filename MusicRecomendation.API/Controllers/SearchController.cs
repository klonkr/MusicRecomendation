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
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        public IRepository Repository { get; set; }
        public IAuthorization Authorization { get; set; }

        public SearchController(IRepository repository, IAuthorization auth)
        {
            Repository = repository;
            Authorization = auth;
        }
        public JsonResult Search(string query, string types)
        {
            var authorize = Authorization.Get();

            var headers = new List<string[]> { new string[] { "Authorization", $"Bearer {authorize.access_token}" } };
            var parameters = new List<string[]> { new string[] { "q", query }, new string[] { "type", types } };
            var something = Repository.Read<SearchResult>("https://api.spotify.com/v1", "search", (int)Method.GET, headers, parameters);
            return new JsonResult(something);
        }
    }
}