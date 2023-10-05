using AutoMapper;
using Letgo.BusinessLayer.Abstract;
using Letgo.Entities.Concrete;
using Letgo.WebUI.Models.DTO_s;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System.Text.RegularExpressions;

namespace Letgo.WebUI.Controllers
{
    public class AdvertController : Controller
    {
        private readonly IAdvertManager advertManager;
        private readonly IAdvertStatusManager statusManager;
        private readonly IMapper mapper;

        public AdvertController
            (
            IAdvertManager advertManager,
            IAdvertStatusManager statusManager,
            IMapper mapper
            )
        {
            this.advertManager = advertManager;
            this.statusManager = statusManager;
            this.mapper = mapper;
        }
        [Route("/ilanlar")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult PostCreate(AdvertCreateDTO dTO)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Fill in the mandatory fields!");
                return View(dTO);
            }
            try
            {
                var advert = mapper.Map<Advert>(dTO);
                advertManager.CreateAsync("adverts", advert);
                return Redirect("~/");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"An error was encountered.\nError message: {ex.Message}");
                return View("_CreateModal", dTO);
            }
        }
        [HttpGet]
        public IActionResult GetUpdate(string ObjectID)
        {
            try
            {
                var advert = advertManager.GetByIdAsync("adverts", ObjectID);
                return View(advert);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"An error was encountered.\nError message: {ex.Message}");
                return Redirect("~/");
            }
        }
        [HttpPost]
        public IActionResult PostUpdate(AdvertCreateDTO dTO)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Fill in the mandatory fields!");
                return View(dTO);
            }
            try
            {
                var advert = mapper.Map<Advert>(dTO);
                advertManager.UpdateAsync("adverts", advert);
                return Redirect("~/");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"An error was encountered.\nError message: {ex.Message}");
                return View("_CreateModal", dTO);
            }
        }
        [HttpGet]
        public IActionResult GetDelete(string ObjectID)
        {
            try
            {
                var advert = advertManager.GetByIdAsync("adverts", ObjectID);
                return View(advert);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"An error was encountered.\nError message: {ex.Message}");
                return Redirect("~/");
            }
        }
        [HttpPost]
        public IActionResult PostDelete(Advert advert)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Fill in the mandatory fields!");
                return View(advert);
            }
            try
            {
                advertManager.DeleteAsync("adverts", advert);
                return Redirect("~/");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"An error was encountered.\nError message: {ex.Message}");
                return View("_CreateModal", advert);
            }
        }
    }
}
