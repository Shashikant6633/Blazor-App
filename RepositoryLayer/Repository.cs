﻿using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Core;
using RepositoryLayer.Models;
using System.Linq;
using System.Threading.Tasks;

namespace RepositoryLayer
{
    public class Repository : IRepository
    {
        private readonly AppDbContext _db;

        public Repository(AppDbContext db)
        {
            _db = db;
        }

        // public Task<IQueryable<Product>> GetProducts()
        public IQueryable<Product> GetProducts()
        {
            //   return Task.FromResult(_db.Product.AsQueryable());
            return _db.Product;
        }
        public async Task<Product> AddProduct(Product product)
        {
            _db.Product.Add(product);
            await _db.SaveChangesAsync();
            return product;
        }

        public async Task<Product> GetProductById(int productId)
        {
            return await _db.Product.FindAsync(productId);
        }

        public async Task UpdateProduct(Product product)
        {
            _db.Entry(product).State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }

        public async Task DeleteProduct(int productId)
        {
            var productToDelete = await _db.Product.FindAsync(productId);
            if (productToDelete != null)
            {
                _db.Product.Remove(productToDelete);
                await _db.SaveChangesAsync();
            }
        }

        public Task<IQueryable<Student>> GetStudents()
        {
            return Task.FromResult(_db.Student.AsQueryable());
        }
        public async Task<Student> AddStudent(Student student)
        {
            _db.Student.Add(student);
            await _db.SaveChangesAsync();
            return student;
        }


        public async Task<Student> GetStudentById(int studentId)
        {
            return await _db.Student.FindAsync(studentId);
        }

        public async Task UpdateStudent(Student student)
        {
            _db.Entry(student).State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }

        public async Task DeleteStudent(int studentId)
        {
            var studentToDelete = await _db.Student.FindAsync(studentId);
            if (studentToDelete != null)
            {
                _db.Student.Remove(studentToDelete);
                await _db.SaveChangesAsync();
            }
        }

        public IQueryable<Order> GetOrders()
        {
            //   return Task.FromResult(_db.Product.AsQueryable());
            return _db.Order;
        }

        public async Task<List<Order>> GetOrdersByProductId(int productId)
        {
            return await _db.Order.Where(o => o.ProductId == productId).ToListAsync();
        }
    }
}
