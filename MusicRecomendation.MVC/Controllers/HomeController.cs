using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MusicRecomendation.MVC.Models;

namespace MusicRecomendation.MVC.Controllers
{
    public class HomeController : Controller
    {
        public IOptions<ApplicationConfig> Config { get; set; }
        public HomeController(IOptions<ApplicationConfig> config)
        {
            Config = config;
        }

        public IActionResult Index()
        {
            var viewModel = new HomeViewModel
            {
                BaseUrl = Config.Value.BaseUrl
            };
            return View(viewModel);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
