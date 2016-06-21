using System;
using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities.Auditing;
using Abp.Extensions;

namespace AbpCompanyName.AbpProjectName.Products
{
    public class Product : AuditedEntity
    {
        public const int MaxNameLength = 128;

        [Required]
        [StringLength(MaxNameLength)]
        public string Name { get; set; }

        public float? Price { get; set; }

        public Product()
        {
            
        }

        public Product(string name, float? price = null)
        {
            if (name.IsNullOrEmpty())
            {
                throw new ArgumentException($"nameof(name) can not be null or empty", nameof(name));
            }

            Name = name;
            Price = price;
        }
    }
}
