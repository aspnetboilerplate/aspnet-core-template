using System;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;

namespace AbpCompanyName.AbpProjectName.Products
{
    [Table("Categories")]
    public class Category : Entity<Guid>
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override Guid Id { get; set; }

        public string Name { get; set; }
    }
}