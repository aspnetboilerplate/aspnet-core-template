using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using AbpCompanyName.AbpProjectName.Products.Dtos;
using Microsoft.EntityFrameworkCore;

namespace AbpCompanyName.AbpProjectName.Products
{
    public class ProductAppService : AbpProjectNameAppServiceBase, IProductAppService
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<Category, Guid> _categoryRepository;

        public ProductAppService(
            IRepository<Product> productRepository,
            IRepository<Category, Guid> categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<ListResultOutput<ProductListDto>> GetAllProducts()
        {
            var products = await _productRepository
                .GetAll()
                .Include(product => product.Category)
                .ToListAsync();

            return new ListResultOutput<ProductListDto>(
                ObjectMapper.Map<List<ProductListDto>>(products)
            );
        }

        public void Create(ProductCreateInput input)
        {
            var product = ObjectMapper.Map<Product>(input);

            product.Category = input.CategoryId == default(Guid)
                ? _categoryRepository.GetAll().First()
                : _categoryRepository.Get(input.CategoryId);

            _productRepository.Insert(product);

            CurrentUnitOfWork.SaveChanges();
        }
    }
}