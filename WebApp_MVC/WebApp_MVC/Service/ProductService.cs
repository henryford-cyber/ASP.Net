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
                DateCreated = e.DateCreate,
                CatedoryId = e.CategoryId
            }).ToList();
            return rs;
        }

    }
}
