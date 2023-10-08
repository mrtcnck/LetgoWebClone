using AutoMapper;
using Letgo.BusinessLayer.API.Abstract;
using Letgo.BusinessLayer.Db.Abstract;
using Letgo.Entities.Concrete;
using Letgo.WebUI.DTO_s;
using Letgo.WebUI.Models.DTO_s;
using Microsoft.AspNetCore.Mvc;

namespace Letgo.WebUI.Controllers
{
    public class DB_AdvertController : Controller
    {
        private readonly IAdvertManagerDb advertManager;
        private readonly IAdvertStatusManagerDb statusManager;
        private readonly IMapper mapper;
        private readonly IWebHostEnvironment hostEnvironment;

        public DB_AdvertController
            (
            IAdvertManagerDb advertManager,
            IAdvertStatusManagerDb statusManager,
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
        [Route("/ilanolustur")]
        public IActionResult GetCreate()
        {
            return View();
        }

        [HttpPost]
        [Route("/ilanolustur")]
        public IActionResult PostCreate(AdvertCreateDTO dTO)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Fill in the mandatory fields!");
                return View(dTO);
            }
            try
            {
                string photoPath = "";
                if (Request.Form.Files.Count > 0)
                {
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
                }
                else
                {
                    photoPath = "/upload_image/No_image_available.png";
                }
                var advert = mapper.Map<Advert>(dTO);
                advert.Image = photoPath;
                advertManager.Create(advert);
                return Redirect("~/");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"An error was encountered.\nError message: {ex.Message}");
                return View(dTO);
            }
        }
        [HttpGet]
        [Route("/guncelle/{ObjectID}")]
        public IActionResult GetUpdate(string ObjectID)
        {
            try
            {
                var advert = advertManager.GetById(ObjectID);
                var newAdvert = mapper.Map<Advert>(advert);
                return View(newAdvert);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"An error was encountered.\nError message: {ex.Message}");
                return Redirect("~/");
            }
        }
        [HttpPost]
        public IActionResult PostUpdate(AdvertUpdateDTO dTO)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Fill in the mandatory fields!");
                return View(dTO);
            }
            try
            {
                var advert = mapper.Map<Advert>(dTO);
                advertManager.Update(advert);
                return Redirect("~/");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"An error was encountered.\nError message: {ex.Message}");
                return View(dTO);
            }
        }
        [HttpGet]
        [Route("/ilansil/{ObjectID}")]
        public IActionResult GetDelete(string ObjectID)
        {
            try
            {
                var advert = advertManager.GetById(ObjectID);
                return View(advert.Result);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"An error was encountered.\nError message: {ex.Message}");
                return Redirect("~/");
            }
        }
        [HttpPost]
        public IActionResult PostDelete(string ObjectID)
        {
            try
            {
                var advert = advertManager.GetById(ObjectID);
                advertManager.Delete(advert.Result);
                return Redirect("~/");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"An error was encountered.\nError message: {ex.Message}");
                return Redirect("~/");
            }
        }
        [HttpGet]
        [Route("/detay/{ObjectID}")]
        public IActionResult GetDetail(string ObjectID)
        {
            try
            {
                var advert = advertManager.GetById(ObjectID);
                return View(advert.Result);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"An error was encountered.\nError message: {ex.Message}");
                return Redirect("~/");
            }
        }
    }
}
