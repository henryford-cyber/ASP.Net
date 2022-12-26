using Microsoft.EntityFrameworkCore;
using WebApp_MVC.Models;

namespace WebApp_MVC.Service
{
    public class CategoryService : ICategoryService
    {
        private static List<CategoryResponse> rs;
        static CategoryService()
        {
            rs = new List<CategoryResponse>
            {
                new CategoryResponse {Id=1,Name="Samsung"},
                new CategoryResponse {Id=2,Name="Macbook"},
                new CategoryResponse {Id=3,Name="Huawei"},
                new CategoryResponse {Id=4,Name="Lenovo"},
                new CategoryResponse {Id=5,Name="Dell"},
                new CategoryResponse {Id=6,Name="MSI"},
                new CategoryResponse {Id=7,Name="Asus"},
                new CategoryResponse {Id=8,Name="Acer"},
            };
        }
        public List<CategoryResponse> GetList()
        {

            return rs;
        }
        public CategoryResponse Get(int id)
        {
            return rs.Where(e => e.Id == id).FirstOrDefault();
        }
        public void Delete(int id)
        {
            var obj = rs.Where(e => e.Id == id).FirstOrDefault();
            if (obj != null)
            {
                rs.Remove(obj);
            }
        }
        public string Insert(CategoryResponse category) 
        {
            var idMax= rs.Select(e => e.Id).Max();
            category.Id = idMax + 1;


            var exist = rs.Where(e=>e.Name== category.Name).FirstOrDefault();
            if (exist != null)
            {
                return "Danh muc nay da ton tai";
            }
            rs.Add(category);
            return string.Empty;
        }

        public string Update(CategoryResponse category) 
        { 
            var obj= rs.Where(e=>e.Id==category.Id).FirstOrDefault();
            if(obj != null)
            {
                obj.Name= category.Name;
                return string.Empty;
            }
            else
            {
                return "Không tìm thấy ";
            }
        }
    }
}
