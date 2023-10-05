using Algolia.Search.Clients;
using Letgo.BusinessLayer.Abstract;
using Letgo.BusinessLayer.Concrete;
using Letgo.Entities.Concrete;
using Letgo.WebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Letgo.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISearchClient searchClient;
        private readonly IAdvertManager advertManager;

        public HomeController(ILogger<HomeController> logger, ISearchClient searchClient, IAdvertManager advertManager)
        {
            _logger = logger;
            this.searchClient = searchClient;
            this.advertManager = advertManager;
        }
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var adverts = advertManager.GetAllAsync("letgo_NAME");
            //foreach (var item in await adverts)
            //{
            //    if (item.ObjectID == "fe1ca572-29a9-438c-afc7-eb537b766845")
            //    {
            //        return View(item);
            //    }
            //}
            return View(adverts);
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