namespace WebApp_MVC.Models
{
    public class ProductViewModel
    {
        public List<ProductResponse> Products { get; set; }
        
        public ProductRequest ProductRequest { get; set; }
        // đây dữ liệu lên serveeer
        
        
        public List<CategoryResponse> Categories { get; set; }
    }
}
