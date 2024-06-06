using Microsoft.AspNetCore.Mvc;
using Shop.DataAccess;
using Shop.DataAccess.Repositories;
using Shop.Entities.Models;
using Shop.Entities.IRepositories;

namespace Shop.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public IActionResult Index()
        {
            var categories = _unitOfWork.Category.GetAll();
            return View(categories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]

        public IActionResult Create(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View(category);
            }
            _unitOfWork.Category.Add(category);
            _unitOfWork.Complete();
            TempData["message"] = "Category Created Successfully!";
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (id == 0)
                return NotFound();

            var category = _unitOfWork.Category.GetFirstOrDefault(c => c.Id == id);
            return View(nameof(Create), category);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (category == null)
                return BadRequest();

            var entity = _unitOfWork.Category.GetFirstOrDefault(c => c.Id == category.Id);

            if (entity is null)
                return NotFound();
            _unitOfWork.Category.Update(category);

            _unitOfWork.Complete();
            TempData["message"] = "Category Edited Successfully!";
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Delete(int id)
        {
            var entity = _unitOfWork.Category.GetFirstOrDefault(c => c.Id == id);
            if (entity is null)
                return NotFound();

            _unitOfWork.Category.Remove(entity);
            _unitOfWork.Complete();

            TempData["message"] = "Category Deleted Successfully!";
            return RedirectToAction(nameof(Index));
        }

    }
}
