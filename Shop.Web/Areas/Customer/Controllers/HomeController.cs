using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Shop.Entities.IRepositories;
using Shop.Entities.ViewModels;

namespace Shop.Web.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public HomeController(IUnitOfWork unitOfWork , IMapper mapper)
        {
                _unitOfWork=unitOfWork;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            var products = _unitOfWork.Product.GetAll();
            return View(products);
        }

        public IActionResult Details(int id)
        {
            var entity = _unitOfWork.Product.GetFirstOrDefault(includeWord: "Category");
            var product=_mapper.Map<ProductViewVM>(entity);
            var mdl = new ShoppingCardVM
            {
                Product = product,
                Quantity = 1

            };
            return View(mdl);
        }   
    }
}
