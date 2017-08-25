using AbpCompanyName.AbpProjectName.Configuration;
using AbpCompanyName.AbpProjectName.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace AbpCompanyName.AbpProjectName.EntityFrameworkCore
{
    /* This class is needed to run EF Core PMC commands. Not used anywhere else */
    public class AbpProjectNameDbContextFactory : IDesignTimeDbContextFactory<AbpProjectNameDbContext>
    {
        public AbpProjectNameDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<AbpProjectNameDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            DbContextOptionsConfigurer.Configure(
                builder,
                configuration.GetConnectionString(AbpProjectNameConsts.ConnectionStringName)
            );

            return new AbpProjectNameDbContext(builder.Options);
        }
    }
}