using Abp.Application.Services;
using Abp.Application.Services.Dto;
using AbpCompanyName.AbpProjectName.Products.Dtos;

namespace AbpCompanyName.AbpProjectName.Products
{
    public interface IProductAppService : IApplicationService
    {
        ListResultOutput<ProductDto> GetAllProducts();
    }
}
