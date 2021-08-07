using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PowerShop.Models;

namespace PowerShop.Data
{
    public class MyPowershopContext : DbContext
    {
        public MyPowershopContext(DbContextOptions<MyPowershopContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryrelProduct> CategoryrelProducts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

       


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

           
            #region columnType

            modelBuilder.Entity<Item>(i =>
            {
                i.Property(i => i.PriceItem).HasColumnType("Money");
                i.HasKey(i => i.IdItem);
            });


            #endregion
            #region productForeignkey

            modelBuilder.Entity<Item>()
                .HasOne(i => i.Product)
                .WithOne(p => p.Item)
                .HasForeignKey<Product>(p => p.IdItem);
            #endregion

            modelBuilder.Entity<CategoryrelProduct>().HasKey(c => new { c.CategoryId, c.ProductId });
            #region seed data category
            modelBuilder.Entity<Category>().HasData(new Category()
            {
                CategoryId = 1,
                CategoryName = "Power",
                CategoryDescription = "Powerlessly Product  For Strong Mind"
            },
            new Category()
            {
                CategoryId = 2,
                CategoryName = "Speed",
                CategoryDescription = "Speedily Product  For Speedily Mind"
            },
            new Category()
            {
                CategoryId = 3,
                CategoryName = "Other",
                CategoryDescription = "Other Product  For healthy Mind"
            }
            );
            #endregion

            #region Seed Data Item

            modelBuilder.Entity<Item>().HasData(new Item()
            {
                IdItem = 1,
                PriceItem = 888.0M,
                QuantityInStock = 2
            },
            new Item()
            {
                IdItem = 2,
                PriceItem = 999.0M,
                QuantityInStock = 4
            },
            new Item()
            {
                IdItem = 3,
                PriceItem = 999.0M,
                QuantityInStock = 1
            },
            new Item()
            {
                IdItem = 4,
                PriceItem = 999.0M,
                QuantityInStock = 1
            });

            #endregion

            #region Seed Data Product

            modelBuilder.Entity<Product>().HasData(new Product()
            {
                ProductId = 1,
                IdItem = 1,
                ProductName = "The product of peace of mind for the power of the mind",
                ProductDescription = "This course takes thirty days"
            },
                new Product()
                {
                    ProductId = 2,
                    IdItem = 2,
                    ProductName = "The product of peace of mind for the Speed of the mind",
                    ProductDescription = "This course takes thirty days"
                },
                new Product()
                {
                    ProductId = 3,
                    IdItem = 3,
                    ProductName = "The product of peace of mind for the health of the mind",
                    ProductDescription = "This course takes thirty days"
                });

            #endregion

            #region Category Relation

            modelBuilder.Entity<CategoryrelProduct>().HasData(new CategoryrelProduct()
            {
                CategoryId = 1,
                ProductId = 1
            },
                new CategoryrelProduct()
                {
                    CategoryId = 2,
                    ProductId = 2
                },
                new CategoryrelProduct()
                {
                    ProductId = 3,CategoryId = 3
                });

            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}
