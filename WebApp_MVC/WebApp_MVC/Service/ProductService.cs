using Microsoft.AspNetCore.Mvc;
using WebApp_MVC.Data;
using WebApp_MVC.Models;

namespace WebApp_MVC.Service
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _db;

        public ProductService(ApplicationDbContext db)
        {
            _db = db;
        }
        public List<ProductResponse> GetList()
        {
            var rs = _db.Products.Select(e => new ProductResponse
            {
                Id = e.Id,
                Name = e.Name,
                Description = e.Description,
                Price = e.Price,
                Image=e.Image,
                DateCreated = e.DateCreate,
                CategoryId = e.CategoryId,
                CategoryName =e.Category.Name
            }).ToList();
            return rs;
        }
        [HttpPost]
        public void Create(ProductViewModel viewModel)
        {
            var product = new Product
            {
                Name = viewModel.ProductRequest.Name,
                Description = viewModel.ProductRequest.Description,
                Price = viewModel.ProductRequest.Price,
                Image = viewModel.ProductRequest.Image, 
                CategoryId = viewModel.ProductRequest.CategoryId,
                DateCreate = DateTime.Now,
            };
            _db.Products.Add(product);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var rs = _db.Products.Where(e => e.Id == id).FirstOrDefault();
            if (rs != null)
            {
                _db.Products.Remove(rs);
                _db.SaveChanges();
            }
        }

       

        public void Update(ProductViewModel viewModel)
        {
            throw new NotImplementedException();
        }
    }
}
