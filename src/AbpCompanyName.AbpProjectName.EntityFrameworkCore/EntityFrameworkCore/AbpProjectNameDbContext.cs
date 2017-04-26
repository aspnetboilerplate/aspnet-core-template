using Abp.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AbpCompanyName.AbpProjectName.EntityFrameworkCore
{
    public class AbpProjectNameDbContext : AbpDbContext
    {
        //Add DbSet properties for your entities...

        public AbpProjectNameDbContext(DbContextOptions<AbpProjectNameDbContext> options) 
            : base(options)
        {

        }
    }
}
