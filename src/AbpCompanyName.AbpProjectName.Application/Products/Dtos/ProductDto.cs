using Abp.Application.Services.Dto;

namespace AbpCompanyName.AbpProjectName.Products.Dtos
{
    public class ProductDto : EntityDto
    {
        public string Name { get; set; }

        public float Price { get; set; }
    }
}
