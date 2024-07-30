using ASP_3_Lesson.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ASP_3_Lesson.Services
{
    public interface IProductService
    {
        Task<List<Product>> GetAllByKey(string key = "");
        Task<Product> GetById(int id);
        Task Add(Product product);
        void Delete(Product product);
        void Update(Product product);

    }
}
