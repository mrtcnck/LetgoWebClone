using AutoMapper;
using Letgo.BusinessLayer.Abstract;
using Letgo.Entities.Concrete;
using Letgo.WebUI.DTO_s;
using Letgo.WebUI.Models.DTO_s;
using Microsoft.AspNetCore.Mvc;

namespace Letgo.WebUI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryManager categoryManager;
        private readonly IMapper mapper;

        public CategoryController
            (
            ICategoryManager categoryManager,
            IMapper mapper
            )
        {
            this.categoryManager = categoryManager;
            this.mapper = mapper;
        }
        [Route("/kategoriler")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult PostCreate(CategoryCreateDTO dTO)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Fill in the mandatory fields!");
                return View(dTO);
            }
            try
            {
                var category = mapper.Map<Category>(dTO);
                categoryManager.CreateAsync("categories", category);
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
                var category = categoryManager.GetByIdAsync("categories", ObjectID);
                return View(category);
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
                var category = mapper.Map<Category>(dTO);
                categoryManager.UpdateAsync("categories", category);
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
                var category = categoryManager.GetByIdAsync("categories", ObjectID);
                return View(category);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"An error was encountered.\nError message: {ex.Message}");
                return Redirect("~/");
            }
        }
        [HttpPost]
        public IActionResult PostDelete(Category category)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Fill in the mandatory fields!");
                return View(category);
            }
            try
            {
                categoryManager.DeleteAsync("categories", category);
                return Redirect("~/");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"An error was encountered.\nError message: {ex.Message}");
                return View("_CreateModal", category);
            }
        }
    }
}
