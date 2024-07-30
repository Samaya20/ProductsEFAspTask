using ASP_3_Lesson.Entities;
using Microsoft.EntityFrameworkCore;

namespace ASP_3_Lesson.Data
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext>
            contextOptions) 
            : base(contextOptions)
        {
            
        }

        public DbSet<Product> Products { get; set; }
    }
}
