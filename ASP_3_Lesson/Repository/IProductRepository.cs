using ASP_3_Lesson.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ASP_3_Lesson.Repository
{
    public interface IProductRepository
    {
        Task<List<Product>> GetProductsAsync();
        Task Add(Product product);
        void Update(Product product);
        void Delete(Product product);
    }
}
