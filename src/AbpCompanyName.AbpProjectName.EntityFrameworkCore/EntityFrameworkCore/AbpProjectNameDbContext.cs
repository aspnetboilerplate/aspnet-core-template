using Abp.EntityFrameworkCore;
using AbpCompanyName.AbpProjectName.Products;
using Microsoft.EntityFrameworkCore;

namespace AbpCompanyName.AbpProjectName.EntityFrameworkCore
{
    public class AbpProjectNameDbContext : AbpDbContext
    {
        //TODO: Define an DbSet for each Entity...

        public DbSet<Product> Products { get; set; }

        public AbpProjectNameDbContext(DbContextOptions<AbpProjectNameDbContext> options) 
            : base(options)
        {

        }
    }
}
