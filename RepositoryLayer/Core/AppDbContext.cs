using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Core
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options):base(options) { 
            
        }
        public DbSet<Product> Product { get; set; }

        public DbSet<Student> Student { get; set; }

        public DbSet<Order> Order { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 1,
                Name = "Product1",
                Price = 1000,
                Description = "Description1"
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 2,
                Name = "Product2",
                Price = 2000,
                Description = "Description2"
            });

            modelBuilder.Entity<Student>().HasData(new Student
            {
                Id = 1,
                Name = "Shashi",
                Course = "Full-Stack"
            });

            modelBuilder.Entity<Order>().HasData(new Order
            {
                Id = 1,
                ProductId = 1,
                OrderBy = "Shashi"
            });

            modelBuilder.Entity<Order>().HasData(new Order
            {
                Id = 2,
                ProductId = 1,
                OrderBy = "Tejas"
            });

            modelBuilder.Entity<Order>().HasData(new Order
            {
                Id = 3,
                ProductId = 2,
                OrderBy = "Rohan"
            });

            modelBuilder.Entity<Order>().HasData(new Order
            {
                Id = 4,
                ProductId = 2,
                OrderBy = "Vipul"
            });


        }
    }
}
