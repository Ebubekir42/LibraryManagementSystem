using Microsoft.AspNetCore.Mvc;
using LMS.Services.Contracts;
using LMS.Entities.RequestParameters;
using LMS.App.Models;
using Microsoft.AspNetCore.Authorization;
using LMS.Entities.Dtos;

namespace LMS.App.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {
        private readonly IServiceManager _manager;
        public CategoryController(IServiceManager manager)
        {
            _manager = manager;
        }
        public IActionResult Index([FromQuery] CategoryRequestParameter c)
        {
            ViewData["Title"] = "Kategoriler";
            var categories = _manager.CategoryService.GetAllCategories(false);
            //var pagination = new Pagination()
            //{
            //    CurrentPage = c.PageNumber,
            //    ItemsPerPage = c.PageSize,
            //    TotalItems = categories.Count()
            //};
            return View(new CategoryListViewModel()
            {
                Categories = categories.ToList()
            });

        }
        public IActionResult Create()
        {
            TempData["info"] = "Lütfen alanları doldurun.";
            return View();
        }
        [HttpPost]
        public IActionResult Create([FromForm] CategoryDtoForInsertion categoryDto)
        {
            if (categoryDto.CategoryName is null)
                ModelState.AddModelError("Error", "Lütfen kategori adını girin.");
            else
            {
                _manager.CategoryService.CreateOneCategory(categoryDto);
                TempData["success"] = $"{categoryDto.CategoryName} isimli bir kategori başarıyla eklendi";
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Update([FromRoute(Name = "id")] int id)
        {
            var categoryDto = _manager.CategoryService.GetOneCategoryDtoForUpdate(id, false);
            ViewData["Title"] = categoryDto.CategoryName;
            return View(categoryDto);
        }
        [HttpPost]
        public IActionResult Update([FromForm] CategoryDtoForUpdate categoryDto)
        {
            if (categoryDto.CategoryName is null)
                ModelState.AddModelError("Error", "Lütfen kategori adını girin.");
            else
            {
                _manager.CategoryService.UpdateOneCategory(categoryDto);
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Delete([FromRoute(Name = "id")] int id)
        {
            _manager.CategoryService.DeleteOneCategory(id);
            TempData["danger"] = "Seçilen kategori kaldırıldı.";
            return RedirectToAction("Index");
        }


    }
}
