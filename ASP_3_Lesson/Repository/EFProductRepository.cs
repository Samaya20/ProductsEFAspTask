using ASP_3_Lesson.Data;
using ASP_3_Lesson.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_3_Lesson.Repository
{
    public class EFProductRepository : IProductRepository
    {
        private readonly ProductDbContext _dbContext;

        public EFProductRepository(ProductDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(Product product)
        {
            await _dbContext.Products.AddAsync(product);
            await _dbContext.SaveChangesAsync();
        }

        public void Delete(Product product)
        {
            _dbContext.Products.Remove(product);
            _dbContext.SaveChanges();
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            return await _dbContext.Products.ToListAsync();
        }

        public void Update(Product product)
        {
            _dbContext.Update(product);
            _dbContext.SaveChanges();
        }
    }
}
