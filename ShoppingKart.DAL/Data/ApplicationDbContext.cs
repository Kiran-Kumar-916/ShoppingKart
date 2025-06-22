using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using ShoppingKart.Core.Models;

namespace ShoppingKart.DAL.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<MyCart> MyCartItems { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Additional model configurations can be added here

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "iPhone 16", Description = "Latest Apple iPhone with advanced features", Category = "Electronics", Price = 129999.00m, Discount = 10.00m, Quantity = 50 },
                new Product { Id = 2, Name = "Samsung Galaxy S23", Description = "Flagship Samsung smartphone with AMOLED screen", Category = "Electronics", Price = 99999.00m, Discount = 15.00m, Quantity = 30 },
                new Product { Id = 3, Name = "Nike Running Shoes", Description = "Lightweight and comfortable running shoes", Category = "Footwear", Price = 4999.00m, Discount = 5.00m, Quantity = 100 },
                new Product { Id = 4, Name = "Adidas Sports Shoes", Description = "Durable sports shoes for all terrains", Category = "Footwear", Price = 5999.00m, Discount = 10.00m, Quantity = 80 },
                new Product { Id = 5, Name = "Levi's Jeans", Description = "Slim fit jeans made with high-quality denim", Category = "Apparel", Price = 2999.00m, Discount = 20.00m, Quantity = 150 },
                new Product { Id = 6, Name = "T-shirt", Description = "Cotton T-shirt available in various colors", Category = "Apparel", Price = 799.00m, Discount = 5.00m, Quantity = 200 },
                new Product { Id = 7, Name = "Mi Smart TV", Description = "43-inch 4K Ultra HD Smart LED TV", Category = "Electronics", Price = 24999.00m, Discount = 12.00m, Quantity = 25 },
                new Product { Id = 8, Name = "HP Laptop", Description = "Intel Core i5 laptop with 8GB RAM, 512GB SSD", Category = "Electronics", Price = 59999.00m, Discount = 8.00m, Quantity = 40 },
                new Product { Id = 9, Name = "Coffee Mug", Description = "Ceramic mug with stylish print", Category = "Home Essentials", Price = 299.00m, Discount = 5.00m, Quantity = 500 },
                new Product { Id = 10, Name = "Blender", Description = "Multipurpose blender for kitchen use", Category = "Home Essentials", Price = 1999.00m, Discount = 18.00m, Quantity = 60 }
            );

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Electronics", Description = "Devices like smartphones, TVs, laptops, etc.", TaxRate = 18.00m },
                new Category { Id = 2, Name = "Footwear", Description = "Shoes, sandals, and other wearable foot items", TaxRate = 12.00m },
                new Category { Id = 3, Name = "Apparel", Description = "Clothing items including jeans, T-shirts, etc.", TaxRate = 5.00m },
                new Category { Id = 4, Name = "Home Essentials", Description = "Everyday household items and tools", TaxRate = 12.50m }
            );

            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, UserName = "Admin", PasswordHash = "jGl25bVBBBW96Qi9Te4V37Fnqchz/Eu4qB9vKrRIqRg=", Role = "Admin", FullName = "Admin Full Name", Email = "admin@gmail.com", PhoneNum = "9999999999", Address = "Mangalore, Karnataka, India, PIN: 575001" },
                new User { Id = 1004, UserName = "user1", PasswordHash = "CgQblGLKpKMbrDVn4Lbm/ZEAeH2yq0M9lvbReMq/zpA=", Role = "User", FullName = "Kiran Kumar", Email = "kiranshetty@outlook.com", PhoneNum = "1234567890", Address = "12345 MG Road, Bangalore, Karnataka" },
                new User { Id = 1005, UserName = "user2", PasswordHash = "YCXRj+SKvUUWhSjxioLiZd2Y1CGnCEqgn2GzQXA5AaM=", Role = "User", FullName = "Jeevitha Smitha", Email = "jeevitha@gmail.com", PhoneNum = "9876543210", Address = "32 Marine Drive, Kochi, Kerala" },
                new User { Id = 1006, UserName = "user3", PasswordHash = "WGD68CtrxiIrpaylI1YPDjZMzYtnvuSG/ov3wB1JLMs=", Role = "User", FullName = "Sachin Kumar", Email = "sachinkumar@hotmail.com", PhoneNum = "9123456789", Address = "7 Laxmi Nagar, Delhi" }
            );
        }
    }

}

