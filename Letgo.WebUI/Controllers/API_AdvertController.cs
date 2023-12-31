﻿using AutoMapper;
using Letgo.BusinessLayer.API.Abstract;
using Letgo.BusinessLayer.Db.Abstract;
using Letgo.BusinessLayer.Db.Concrete;
using Letgo.Entities.Concrete;
using Letgo.WebUI.DTO_s;
using Letgo.WebUI.Models;
using Letgo.WebUI.Models.DTO_s;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.Extensions.Hosting;
using NuGet.Protocol.Plugins;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace Letgo.WebUI.Controllers
{
    public class API_AdvertController : Controller
    {
        private readonly IAdvertManager advertManager;
        private readonly IAdvertStatusManager statusManager;
        private readonly IMapper mapper;
        private readonly IWebHostEnvironment hostEnvironment;
        private readonly IAdvertManagerDb advertManagerDb;
        private readonly IhierarchicalCategoriesManagerDb categoryManagerDb;
        private readonly IAdvertStatusManagerDb statusManagerDb;
        private readonly UserManager<User> userManager;
        private readonly IChatManagerDb chatManager;

        public API_AdvertController
            (
            IAdvertManager advertManager,
            IAdvertStatusManager statusManager,
            IMapper mapper,
            IWebHostEnvironment hostEnvironment,
            IAdvertManagerDb advertManagerDb,
            IhierarchicalCategoriesManagerDb categoryManagerDb,
            IAdvertStatusManagerDb statusManagerDb,
            UserManager<User> userManager,
            IChatManagerDb chatManager
            )
        {
            this.advertManager = advertManager;
            this.statusManager = statusManager;
            this.mapper = mapper;
            this.hostEnvironment = hostEnvironment;
            this.advertManagerDb = advertManagerDb;
            this.categoryManagerDb = categoryManagerDb;
            this.statusManagerDb = statusManagerDb;
            this.userManager = userManager;
            this.chatManager = chatManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("/admin/ilanolustur/{ObjectID}")]
        public IActionResult GetCreate(string ObjectID)
        {
            var advert = advertManagerDb.GetById(ObjectID).Result;
            advert.Categories = categoryManagerDb.GetAll(c => c.AdvertObjectID == advert.ObjectID).Result.FirstOrDefault();
            return View(advert);
        }

        [HttpPost]
        public IActionResult PostCreate(Advert advert)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Fill in the mandatory fields!");
                return View(advert);
            }
            try
            {
                advertManager.CreateAsync("adverts", advert);
                var status = statusManagerDb.GetById(advert.StatusObjectID).Result;
                status.IsOnAir = true;
                status.IsSold = false;
                status.IsRemove = false;
                status.IsApproved = false;
                status.IsDenied = false;
                status.IsModify = false;
                statusManagerDb.Update(status);
                return Redirect("~/");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"An error was encountered.\nError message: {ex.Message}");
                return View(advert);
            }
        }
        [HttpGet]
        [Route("/admin/guncelle/{ObjectID}")]
        public IActionResult GetUpdate(string ObjectID)
        {
            try
            {
                var advert = advertManager.GetByIdAsync("adverts", ObjectID);
                var newAdvert = mapper.Map<Advert>(advert.Result);
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
        [Route("/admin/ilansil/{ObjectID}")]
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
        [AllowAnonymous]
        [HttpGet]        
        [Route("/detay/{ObjectID}")]
        public async Task<IActionResult> GetDetail(string ObjectID)
        {
            try
            {
                var advert = advertManager.GetByIdAsync("adverts", ObjectID);
                var chats = await chatManager.GetAll(c => c.AdvertObjectID == advert.Result.ObjectID);

                foreach (var chat in chats)
                {
                    if (chat.AdvertObjectID != advert.Result.ObjectID && chat.SenderId != await getUserId() && chat.ReceiverId != advert.Result.SellerId)
                    {
                        Chat chatModel = new()
                        {
                            AdvertObjectID = advert.Result.ObjectID,
                            SenderId = await getUserId(),
                            ReceiverId = advert.Result.SellerId
                        };
                        await chatManager.Create(chatModel);
                    }
                }

                return View(advert);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"An error was encountered.\nError message: {ex.Message}");
                return Redirect("~/");
            }
        }

        public async Task<string> getUserId()
        {
            var user = await userManager.GetUserAsync(User);
            return user.Id;
        }
    }
}
