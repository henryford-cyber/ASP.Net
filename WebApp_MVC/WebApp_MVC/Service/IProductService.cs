using WebApp_MVC.Models;

namespace WebApp_MVC.Service
{
    public interface IProductService
    {
        List<ProductResponse> GetList();
        ProductResponse Get(int id);
        void Create(ProductViewModel viewModel);
        string Update(ProductRequest product);
        void Delete(int id);
        
    }
}