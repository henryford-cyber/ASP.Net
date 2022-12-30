using Microsoft.AspNetCore.Mvc;
using WebApp_MVC.Models;
using WebApp_MVC.Service;

namespace WebApp_MVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        //tiêm chích 
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            var model = new ProductViewModel();
            model.Products= _productService.GetList();
             
            return View(model);
        }
        public IActionResult Delete()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Update()
        {
            return View();
        }
         
    }
}
