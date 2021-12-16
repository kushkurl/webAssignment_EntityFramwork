using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EntityFrameworkEX.Models;

namespace EntityFrameworkEX.Data
{
    public class EntityFrameworkEXContext : DbContext
    {
        

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=EntityFrameworkEX;Integrated Security=true;");
            
            //builder.UseSqlite(@"Data Source=c:\Temp\mydb/db");
        }

        public DbSet<EntityFrameworkEX.Models.Product> Product { get; set; }
        public DbSet<EntityFrameworkEX.Models.SaleItem> SaleItem { get; set; }

        public static void Initialize(EntityFrameworkEXContext context)
        {
            //context.Database.EnsureCreated();

            // Look for any students.
            if (context.SaleItem.Any())
            {
                return;   // DB has been seeded
            }

            var product = new Product[]
           {
                new Product { ProductName = "Watch",     Price = 9000,
                    Description = "Test" },
                new Product { ProductName = "Bike",    Price = 230,
                    Description = "Test" },
                new Product { ProductName = "Car",   Price = 240,
                    Description = "Test" },
                new Product { ProductName = "Shirt", Price = 100,
                    Description = "Test" },
                new Product { ProductName = "Shoes",   Price = 20,
                    Description = "Test" }
           };
            var allprod = from c in context.Product select c;
            context.Product.RemoveRange(allprod);
            context.SaveChanges();

            foreach (Product i in product)
            {
                context.Product.Add(i);
            }
            context.SaveChanges();

            var saleitems = new SaleItem[]
            {
                new SaleItem { SalesName = "New Year",  EndDate = "10-12-2021",
                    StartDate = "10-12-2021",
                    Price  = 1200, ProductName  = (ICollection<Product>)product.Where( i => i.ProductName == "Shoes").ToList() },
                new SaleItem { SalesName = "Friday Sale",  EndDate = "10-12-2021",
                    StartDate = "10-12-2021",
                    Price  = 1200, ProductName  = (ICollection<Product>)product.Where( i => i.ProductName == "Bike").ToList() },
                new SaleItem { SalesName = "Christmas",  EndDate = "10-12-2021",
                    StartDate = "10-12-2021",
                    Price  = 1200, ProductName  = (ICollection<Product>)product.Where( i => i.ProductName == "Watch").ToList() }
                
            };
            var allsale = from c in context.SaleItem select c;
            context.SaleItem.RemoveRange(allsale);
            context.SaveChanges();
            foreach (SaleItem d in saleitems)
            {
                context.SaleItem.Add(d);
            }
            context.SaveChanges();


        }

        }
}