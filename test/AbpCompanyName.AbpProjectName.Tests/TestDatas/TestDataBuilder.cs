using AbpCompanyName.AbpProjectName.EntityFrameworkCore;
using AbpCompanyName.AbpProjectName.Products;

namespace AbpCompanyName.AbpProjectName.Tests.TestDatas
{
    public class TestDataBuilder
    {
        private readonly AbpProjectNameDbContext _context;

        public TestDataBuilder(AbpProjectNameDbContext context)
        {
            _context = context;
        }

        public void Build()
        {
            CreateProducts();
        }

        private void CreateProducts()
        {
            _context.Products.Add(new Product("Acme 23 inch monitor", 849));
            _context.Products.Add(new Product("Acme wireless keyboard and mouse set"));
        }
    }
}