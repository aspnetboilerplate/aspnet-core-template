using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities.Auditing;

namespace AbpCompanyName.AbpProjectName.Products
{
    public class Product : AuditedEntity
    {
        public const int MaxNameLength = 128;

        [Required]
        [StringLength(MaxNameLength)]
        public string Name { get; set; }

        public float? Price { get; set; }
    }
}
