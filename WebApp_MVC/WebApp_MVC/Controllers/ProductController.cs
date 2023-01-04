using Microsoft.AspNetCore.Mvc;
using WebApp_MVC.Models;
using WebApp_MVC.Service;

namespace WebApp_MVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        //tiêm chích 
        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
              
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            var model = new ProductViewModel();
            model.Categories=_categoryService.GetList();
            model.Products= _productService.GetList();
             
            return View(model);
        }
        [HttpPost] 
        public IActionResult Delete(ProductViewModel model)
        {
            _productService.Delete(model.ProductRequest.Id);
            var rs = _productService.GetList();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Create(ProductViewModel viewModal)
        {
           _productService.Create(viewModal);
            return RedirectToAction("Index");
        }
        public IActionResult Update()
        {
            return View();
        }
         
    }
}
