using System;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace AbpCompanyName.AbpProjectName.Products.Dtos
{
    [AutoMapFrom(typeof(Product))]
    public class ProductDto : EntityDto
    {
        public Guid CategoryId { get; set; }

        public string Name { get; set; }

        public float? Price { get; set; }
    }
}
