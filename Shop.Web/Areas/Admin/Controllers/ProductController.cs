using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Shop.Entities.IRepositories;
using Shop.Entities.Models;
using Shop.Entities.ViewModels;

namespace Shop.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IMapper _mapper;

        public ProductController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
            _mapper = mapper;
        }


        public IActionResult Index()
        {

            var products = _unitOfWork.Product.GetAll(includeWord:"Category");
            var productsView = _mapper.Map< IEnumerable<ProductViewVM>>(products);
            return View(products);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var vm = new ProductVM
            {
                Categories = _unitOfWork.Category.GetAll().Select(c=> new SelectListItem
                {
                    Value=c.Id.ToString(),
                    Text=c.Name,

                })
            };
            return View(vm);
        }


        [HttpPost]

        public IActionResult Create(ProductVM product)
        {
            if (!ModelState.IsValid)
            {

                product.Categories = _unitOfWork.Category.GetAll().Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name,

                });
               
                return View(product);
            }
           var entity = _mapper.Map<Product>(product);
            if (product.ImgFile != null)
            {
                var filename=$"{Guid.NewGuid()}{Path.GetExtension(product.ImgFile.FileName)}" ;
                var path = Path.Combine(_webHostEnvironment.WebRootPath,@"Images\Products\");


                using var stream = System.IO.File.Create(path + filename);
               
                    product.ImgFile.CopyTo(stream);

              


                entity.Img = @"Images\Products\" + filename;


            }
            _unitOfWork.Product.Add(entity);
            _unitOfWork.Complete();
            TempData["message"] = "Product Created Successfully!";
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (id == 0)
                return NotFound();

            var Product = _unitOfWork.Product.GetFirstOrDefault(c => c.Id == id);
            var productVM = _mapper.Map<ProductVM>(Product);
            productVM.Categories = _unitOfWork.Category.GetAll().Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name,

            });
            return View(nameof(Create),productVM);
        }

        [HttpPost]
        public IActionResult Edit(ProductVM product)
        {
            if (product == null)
                return BadRequest();

            var entity = _unitOfWork.Product.GetFirstOrDefault(c => c.Id == product.Id);

            if (entity is null)
                return NotFound();
            entity = _mapper.Map<Product>(product);
            var fileName = "";
            if (product.ImgFile != null)
            {
                var oldImgPath = $"{_webHostEnvironment.WebRootPath}\\{entity.Img}";
                if (System.IO.File.Exists(oldImgPath))
                    System.IO.File.Delete(oldImgPath);

                fileName = $"{Guid.NewGuid()}{Path.GetExtension(product.ImgFile.FileName)}";
                var path = Path.Combine(_webHostEnvironment.WebRootPath, @"Images\Products\");
                using var stream = System.IO.File.Create(path + fileName);
                product.ImgFile.CopyTo(stream);
                entity.Img = @"/Images/Products" + fileName;
            }
      
            _unitOfWork.Product.Update(entity);

            _unitOfWork.Complete();
            TempData["message"] = "Product Edited Successfully!";
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Delete(int id)
        {
            var entity = _unitOfWork.Product.GetFirstOrDefault(c => c.Id == id);
            if (entity is null)
                return NotFound();

            _unitOfWork.Product.Remove(entity);
            _unitOfWork.Complete();

            TempData["message"] = "Product Deleted Successfully!";
            return RedirectToAction(nameof(Index));
        }

    }
}
