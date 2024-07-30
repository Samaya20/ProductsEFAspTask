using ASP_3_Lesson.Entities;
using ASP_3_Lesson.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_3_Lesson.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task Add(Product product)
        {
            await _productRepository.Add(product);
        }

        public void Delete(Product product)
        {
            _productRepository.Delete(product);
        }

        public async Task<List<Product>> GetAllByKey(string key = "")
        {
            var data = await _productRepository.GetProductsAsync();
            return key != "" ? data.Where(p => p.Name.ToLower().Contains(key.ToLower())).ToList()
            : data;
        }

        public async Task<Product> GetById(int id)
        {
            var data = await _productRepository.GetProductsAsync();
            return data.SingleOrDefault(p => p.Id == id);
        }

        public void Update(Product product)
        {
            _productRepository.Update(product);
        }
    }
}
