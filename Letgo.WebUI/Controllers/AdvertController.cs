﻿using AutoMapper;
using Letgo.BusinessLayer.Abstract;
using Letgo.Entities.Concrete;
using Letgo.WebUI.DTO_s;
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
        [Route("/ilanolustur")]
        public IActionResult PostCreate()
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
                advertManager.CreateAsync("adverts", advert);
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
                var advert = advertManager.GetByIdAsync("adverts", ObjectID);
                AdvertUpdateDTO mappedAdvertModel = new()
                {
                    ObjectID = advert.Result.ObjectID,
                    CreationDate = advert.Result.CreationDate,
                    UpdateDate = advert.Result.UpdateDate,
                    Name = advert.Result.Name,
                    Image = advert.Result.Image,
                    Description = advert.Result.Description,
                    Price = advert.Result.Price,
                    Slug = advert.Result.Slug,
                    StatusId = advert.Result.StatusId,
                    SellerId = advert.Result.SellerId,
                    hierarchicalCategories = advert.Result.hierarchicalCategories
                };
                return View(mappedAdvertModel);
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
                advertManager.UpdateAsync("adverts", advert);
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
        public IActionResult PostDelete(string ObjectID)
        {
            try
            {
                advertManager.DeleteAsync("adverts", ObjectID);
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
                var advert = advertManager.GetByIdAsync("adverts", ObjectID);
                return View(advert);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"An error was encountered.\nError message: {ex.Message}");
                return Redirect("~/");
            }
        }
    }
}
