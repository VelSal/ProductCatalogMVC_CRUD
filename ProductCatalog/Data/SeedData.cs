using Microsoft.EntityFrameworkCore;
using ProductCatalog.Models;

namespace ProductCatalog.Data
{
    public class SeedData
    {
        public static void AddRecords(ModelBuilder modelBuilder)
        {
            //Seed data
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, Name = "Food"},
                new Category { CategoryId = 2, Name = "Book"},
                new Category { CategoryId = 3, Name = "Hardware"},
                new Category { CategoryId = 4, Name = "Software"}
                
            );
            modelBuilder.Entity<Product>().HasData(
                new Product { ProductId = 1, Name = "Banana", CategoryId = 1, Price = 2.35m},
                new Product { ProductId = 2, Name = "Monster", CategoryId = 2, Price = 15.9m},
                new Product { ProductId = 3, Name = "Laptop", CategoryId = 3, Price = 459.99m},
                new Product { ProductId = 4, Name = "Microsoft Office", CategoryId = 4, Price = 59.99m},
                new Product { ProductId = 5, Name = "Chips", CategoryId = 1, Price = 1.25m},
                new Product { ProductId = 6, Name = "Keyboard", CategoryId = 3, Price = 125.45m},
                new Product { ProductId = 7, Name = "Les Fleurs du Mal", CategoryId = 2, Price = 6.95m},
                new Product { ProductId = 8, Name = "Excel", CategoryId = 4, Price = 59.99m}
            );
        }
    }
}
