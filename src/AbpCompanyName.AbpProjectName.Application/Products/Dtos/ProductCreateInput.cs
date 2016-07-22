using System;
using Abp.AutoMapper;

namespace AbpCompanyName.AbpProjectName.Products.Dtos
{
    [AutoMapTo(typeof(Product))]
    public class ProductCreateInput
    {
        public Guid CategoryId { get; set; }

        public string Name { get; set; }

        public float? Price { get; set; }
    }
}