using Abp.Application.Services.Dto;
using AbpCompanyName.AbpProjectName.Products.Dtos;

namespace AbpCompanyName.AbpProjectName.Products
{
    public class ProductAppService : AbpProjectNameAppServiceBase, IProductAppService
    {
        public ListResultOutput<ProductDto> GetAllProducts()
        {
            return new ListResultOutput<ProductDto>(new []
            {
                new ProductDto
                {
                    Name = "Acme 23 inch monitor.",
                    Price = 899.9f
                },
                new ProductDto
                {
                    Name = "Acme wireless keyboard and mouse set.",
                    Price = 95.0f
                }
            });
        }
    }
}