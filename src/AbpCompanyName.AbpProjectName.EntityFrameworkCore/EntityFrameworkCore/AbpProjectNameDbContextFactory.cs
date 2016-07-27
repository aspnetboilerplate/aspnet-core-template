using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace AbpCompanyName.AbpProjectName.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line.
     */
    public class AbpProjectNameDbContextFactory : IDbContextFactory<AbpProjectNameDbContext>
    {
        public AbpProjectNameDbContext Create(DbContextFactoryOptions options)
        {
            //TODO: Get connection string from a common place
            var builder = new DbContextOptionsBuilder<AbpProjectNameDbContext>();
            builder.UseSqlServer("Server=localhost; Database=AbpProjectNameDb; Trusted_Connection=True;");
            return new AbpProjectNameDbContext(builder.Options);
        }
    }
}