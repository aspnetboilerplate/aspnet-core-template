using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace AbpCompanyName.AbpProjectName.EntityFrameworkCore
{
    public class AbpProjectNameDbContextFactory : IDbContextFactory<AbpProjectNameDbContext>
    {
        public AbpProjectNameDbContext Create()
        {
            var builder = new DbContextOptionsBuilder<AbpProjectNameDbContext>();
            builder.UseSqlServer("Server=localhost; Database=AbpProjectNameDb; Trusted_Connection=True;");
            return new AbpProjectNameDbContext(builder.Options);
        }
    }
}