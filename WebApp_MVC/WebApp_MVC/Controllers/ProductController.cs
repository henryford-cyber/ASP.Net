using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using WebApp_MVC.Models;
using WebApp_MVC.Service;

namespace WebApp_MVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly IWebHostEnvironment _whostEnvironment;
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        //tiêm chích 
        public ProductController(IProductService productService, ICategoryService categoryService, IWebHostEnvironment whostEnvironment)
        {
            _productService = productService;
              
            _categoryService = categoryService;
            _whostEnvironment = whostEnvironment;
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
            if (viewModal.ProductRequest.Image != null)
            {
                var fileName = Guid.NewGuid().ToString() + ".png";
                var path = Path.Combine(_whostEnvironment.WebRootPath, "image", fileName);
                var stream= System.IO.File.Create(path);
                viewModal.ProductRequest.Image.CopyTo(stream);
                stream.Close();
                viewModal.ProductRequest.ImageURL = Path.Combine("image", fileName);
            }

            // truyền file vào wwwroot
           _productService.Create(viewModal);
            return RedirectToAction("Index");
        }
        
        [HttpPost]
        public IActionResult Update(ProductViewModel viewmodel)
        {
            if (viewmodel.ProductRequest.Image != null)
            {
                var fileName = Guid.NewGuid().ToString() + ".png";
                var path = Path.Combine(_whostEnvironment.WebRootPath, "image", fileName);
                var stream = System.IO.File.Create(path);
                viewmodel.ProductRequest.Image.CopyTo(stream);
                stream.Close();
                viewmodel.ProductRequest.ImageURL = Path.Combine("image", fileName);
            }
            _productService.Update(viewmodel);
            
                return RedirectToAction("Index");
            
        }
         
    }
}
