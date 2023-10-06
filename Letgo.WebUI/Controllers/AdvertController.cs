using AutoMapper;
using Letgo.BusinessLayer.Abstract;
using Letgo.Entities.Concrete;
using Letgo.WebUI.Models.DTO_s;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.Extensions.Hosting;
using System.Text.RegularExpressions;

namespace Letgo.WebUI.Controllers
{
    public class AdvertController : Controller
    {
        private readonly IAdvertManager advertManager;
        private readonly IAdvertStatusManager statusManager;
        private readonly IMapper mapper;
        private readonly IWebHostEnvironment hostEnvironment;

        public AdvertController
            (
            IAdvertManager advertManager,
            IAdvertStatusManager statusManager,
            IMapper mapper,
            IWebHostEnvironment hostEnvironment
            )
        {
            this.advertManager = advertManager;
            this.statusManager = statusManager;
            this.mapper = mapper;
            this.hostEnvironment = hostEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("/{controller}/ilanolustur")]
        public IActionResult PostCreate()
        {
            return View();
        }

        [HttpPost]
        [Route("/{controller}/ilanolustur")]
        public IActionResult PostCreate(AdvertCreateDTO dTO)
        {
            //if (!ModelState.IsValid)
            //{
            //    ModelState.AddModelError(string.Empty, "Fill in the mandatory fields!");
            //    return View(dTO);
            //}
            try
            {
                string photoPath = "";
                foreach (var image in Request.Form.Files)
                {
                    string path = Path.Combine(hostEnvironment.WebRootPath, "upload_image", image.FileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        image.CopyTo(stream);
                    }
                    path = "/upload_image/" + image.FileName;
                    photoPath += path;
                }
                var advert = mapper.Map<Advert>(dTO);
                advert.Image = photoPath;
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
