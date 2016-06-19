using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using AbpCompanyName.AbpProjectName.EntityFrameworkCore;

namespace AbpCompanyName.AbpProjectName.EntityFrameworkCore.Migrations
{
    [DbContext(typeof(AbpProjectNameDbContext))]
    [Migration("20160619114439_Initial_Migration_Added_Product")]
    partial class Initial_Migration_Added_Product
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rc2-20901")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AbpCompanyName.AbpProjectName.Products.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreationTime");

                    b.Property<long?>("CreatorUserId");

                    b.Property<DateTime?>("LastModificationTime");

                    b.Property<long?>("LastModifierUserId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 128);

                    b.Property<float?>("Price");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });
        }
    }
}
