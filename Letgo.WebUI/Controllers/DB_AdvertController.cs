using AutoMapper;
using Letgo.BusinessLayer.API.Abstract;
using Letgo.BusinessLayer.Db.Abstract;
using Letgo.BusinessLayer.Db.Concrete;
using Letgo.Entities.Concrete;
using Letgo.WebUI.DTO_s;
using Letgo.WebUI.Models.DTO_s;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Letgo.WebUI.Controllers
{
    public class DB_AdvertController : Controller
    {
        private readonly IAdvertManagerDb advertManagerDb;
        private readonly IAdvertStatusManagerDb statusManagerDb;
        private readonly IMapper mapper;
        private readonly IWebHostEnvironment hostEnvironment;
        private readonly IhierarchicalCategoriesManagerDb categoryManagerDb;
        private readonly IAdvertManager advertManagerApi;
        private readonly UserManager<User> userManager;

        public DB_AdvertController
            (
            IAdvertManagerDb advertManager,
            IAdvertStatusManagerDb statusManager,
            IMapper mapper,
            IWebHostEnvironment hostEnvironment,
            IhierarchicalCategoriesManagerDb categoryManager,
            IAdvertManager advertManagerApi,
            UserManager<User> userManager
            )
        {
            this.advertManagerDb = advertManager;
            this.statusManagerDb = statusManager;
            this.mapper = mapper;
            this.hostEnvironment = hostEnvironment;
            this.categoryManagerDb = categoryManager;
            this.advertManagerApi = advertManagerApi;
            this.userManager = userManager;
        }
        [Authorize(Roles ="Member, Admin, Manager")]
        [Route("/dashboard")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("/myadverts")]
        public IActionResult MyAdverts()
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
        public async Task<IActionResult> PostCreate(AdvertCreateDTO dTO)
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
                    photoPath = "/upload_image/No_image_available.png;";
                }
                
                var advert = mapper.Map<Advert>(dTO);
                advert.Image = photoPath;
                await advertManagerDb.Create(advert);

                AdvertStatus advertStatusModel = new();
                advertStatusModel.AdvertObjectID = advert.ObjectID;
                await statusManagerDb.Create(advertStatusModel);

                hierarchicalCategories categories = new()
                {
                    Lvl0 = dTO.Categories.Lvl0,
                    Lvl1 = dTO.Categories.Lvl1,
                    Lvl2 = dTO.Categories.Lvl2,
                    AdvertObjectID = advert.ObjectID
                };
                categoryManagerDb.Create(categories);

                advert.CategoriesObjectID = categories.ObjectID;
                advert.StatusObjectID = advertStatusModel.ObjectID;
                await advertManagerDb.Update(advert);

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
                var advert = advertManagerDb.GetById(ObjectID).Result;
                var category = categoryManagerDb.GetAll(c => c.AdvertObjectID == advert.ObjectID).Result.FirstOrDefault();
                advert.Categories = category;
                return View(advert);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"An error was encountered.\nError message: {ex.Message}");
                return Redirect("~/");
            }
        }
        [HttpPost]
        public async Task<IActionResult> PostUpdate(Advert advert)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Fill in the mandatory fields!");
                return View(advert);
            }
            try
            {
                advert.Categories = categoryManagerDb.GetAll(c => c.AdvertObjectID == advert.ObjectID).Result.FirstOrDefault();
                advert.Status = statusManagerDb.GetById(advert.StatusObjectID).Result;
                advert.Status.IsModify=true;
                await advertManagerDb.Update(advert);
                await advertManagerApi.UpdateAsync("adverts", advert);
                return Redirect("~/");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"An error was encountered.\nError message: {ex.Message}");
                return View(advert);
            }
        }
        [HttpGet]
        [Route("/ilansil/{ObjectID}")]
        public IActionResult GetDelete(string ObjectID)
        {
            try
            {
                var advert = advertManagerDb.GetById(ObjectID).Result;
                return View(advert);
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
                var advert = advertManagerDb.GetById(ObjectID).Result;
                var status = statusManagerDb.GetById(advert.StatusObjectID).Result;
                status.IsOnAir = false;
                status.IsSold = false;
                status.IsRemove = true;
                status.IsApproved = false;
                status.IsDenied = false;
                status.IsModify = false;
                statusManagerDb.Update(status);
                advertManagerApi.DeleteAsync("adverts", advert.ObjectID);

                return Redirect("~/");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"An error was encountered.\nError message: {ex.Message}");
                return Redirect("~/");
            }
        }
        //[HttpGet]
        //[Route("/admin/detay/{ObjectID}")]
        //public async Task<IActionResult> GetDetail(string ObjectID)
        //{
        //    try
        //    {
        //        var advert = advertManagerDb.GetById(ObjectID).Result;
        //        var status = statusManagerDb.GetById(advert.StatusObjectID).Result;
        //        var user = await userManager.GetUserAsync(User);
        //        if (status.IsOnAir != true && user.Id != advert.SellerId)
        //        {
        //            return Redirect("/Identity/Account/AccessDenied");
        //        }
        //        return View(advert);
        //    }
        //    catch (Exception ex)
        //    {
        //        ModelState.AddModelError("", $"An error was encountered.\nError message: {ex.Message}");
        //        return Redirect("~/");
        //    }
        //}
        [HttpPost]
        public async Task<IActionResult> AdvertDenied(string ObjectID)
        {
            try
            {
                var advertStatus = statusManagerDb.GetById(ObjectID).Result;
                advertStatus.IsDenied = true;
                await statusManagerDb.Update(advertStatus);
                return Redirect("~/dashboard");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"An error was encountered.\nError message: {ex.Message}");
                return Redirect("~/dashboard");
            }
        }
        [HttpPost]
        public async Task<IActionResult> IsSold(string ObjectID)
        {
            try
            {
                advertManagerApi.DeleteAsync("adverts", ObjectID);
                var advert = advertManagerDb.GetById( ObjectID ).Result;
                var status = statusManagerDb.GetById(advert.StatusObjectID).Result;
                status.IsOnAir = false;
                status.IsSold = true;
                status.IsRemove = false;
                status.IsApproved = false;
                status.IsDenied = false;
                status.IsModify = false;
                await statusManagerDb.Update(status);
                return Redirect("~/");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"An error was encountered.\nError message: {ex.Message}");
                return Redirect("~/");
            }
        }
    }
}
