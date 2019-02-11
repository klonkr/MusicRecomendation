using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MusicRecomendation.API.DAL.interfaces;
using MusicRecomendation.API.Models;
using RestSharp;

namespace MusicRecomendation.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        public IOptions<ApplicationConfig> Config { get; set; }
        public IAuthorization Authorization { get; set; }
        //public IRepository<Token> TokenRepository { get; set; }

        public TokenController(IOptions<ApplicationConfig> config, IAuthorization authorization/*, IRepository<Token> tokenRepository*/)
        {
            Config = config;
            Authorization = authorization;
            //TokenRepository = tokenRepository;
        }

        //public JsonResult Get()
        //{
        //    var clientIdSecret = $"{Config.Value.ClientId}:{Config.Value.ClientSecret}";
        //    var secret = ExtensionMethods.Extensions.ToBase64(clientIdSecret);
            
        //    var headers = new List<string[]>() { new string[] { "Authorization", $"Basic {secret}" },
        //    new string[] { "Content-Type", "application/x-www-form-urlencoded" } };

        //    var token = Authorization.Get("https://accounts.spotify.com", "api/token", (int)Method.POST,null , headers, true);
        //    //Authorization a = new Authorization();
        //    return new JsonResult(token);
        //}

    }
}