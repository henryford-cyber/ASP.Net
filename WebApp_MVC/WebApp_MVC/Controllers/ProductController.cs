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
        public IActionResult Delete(int id)
        {
            _productService.Delete(id);
            var rs = _productService.GetList();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Create(ProductViewModel viewModal)
        {
           _productService.Create(viewModal);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Update(int id) 
        {
            var model = new ProductViewModel();
            model.ProductResponse = _productService.Get(id);
            return View(model);
        }
        [HttpPost]
        public IActionResult Update(ProductViewModel viewmodel)
        {
            var rs = _productService.Update(viewmodel.ProductRequest);
            if (string.IsNullOrEmpty(rs))
            {
                return RedirectToAction("Index");
            }
            else
            { 
                return View();
            }
            return View(viewmodel);
        }
         
    }
}
