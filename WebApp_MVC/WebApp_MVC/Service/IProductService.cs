using WebApp_MVC.Models;

namespace WebApp_MVC.Service
{
    public interface IProductService
    {
        List<ProductResponse> GetList();
    }
}