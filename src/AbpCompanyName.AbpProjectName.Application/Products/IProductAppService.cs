using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using AbpCompanyName.AbpProjectName.Products.Dtos;

namespace AbpCompanyName.AbpProjectName.Products
{
    public interface IProductAppService : IApplicationService
    {
        Task<ListResultOutput<ProductDto>> GetAllProducts();
    }
}
