using RepositoryLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer
{
    public interface IRepository
    {
        // Task<IQueryable<Product>> GetProducts();
        IQueryable<Product> GetProducts();
        Task<Product> AddProduct(Product product);
        Task UpdateProduct(Product product);
        Task<Product> GetProductById(int productId);
        Task DeleteProduct(int productId);

        Task<IQueryable<Student>> GetStudents();
        Task<Student> AddStudent(Student student);

        Task UpdateStudent(Student student);
        Task<Student> GetStudentById(int studentId);
        Task DeleteStudent(int studentId);

        IQueryable<Order> GetOrders();
        Task<List<Order>> GetOrdersByProductId(int productId);
        Task<Order> AddOrder(Order order);
        Task DeleteOrder(int orderId);
    }
}
