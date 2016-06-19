using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using AbpCompanyName.AbpProjectName.Products.Dtos;

namespace AbpCompanyName.AbpProjectName.Products
{
    public class ProductAppService : AbpProjectNameAppServiceBase, IProductAppService
    {
        private readonly IRepository<Product> _productRepository;

        public ProductAppService(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ListResultOutput<ProductDto>> GetAllProducts()
        {
            var products = await _productRepository.GetAllListAsync();
            return new ListResultOutput<ProductDto>(
                ObjectMapper.Map<List<ProductDto>>(products)
            );
        }
    }
}