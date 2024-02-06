using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace BusinessLayer
{
    public interface IBusiness
    {
        Task<List<ProductVM>> GetProducts();
        Task<int> AddProduct(ProductVM product);
        Task UpdateProduct(int productId, ProductVM updatedProduct);

       // Task<ProductVM> GetProductById(int productId);

        Task DeleteProduct(int productId);

        Task<List<StudentVM>> GetStudents();
        Task<int> AddStudent(StudentVM student);

        Task UpdateStudent(int studentId, StudentVM updatedStudent);

        Task<StudentVM> GetStudentById(int studentId);

        Task DeleteStudent(int studentId);

        //Task<ProductVM> GetProductsById(int id);
        Task<ProductVM> GetProductById(int productId);
        Task<ProductVM> GetById(int id);
        Task<List<OrderVM>> GetOrders();
        Task<List<OrderVM>> GetOrdersByProductId(int productId);
        Task<int> AddOrder(int productId, OrderVM order);
        Task DeleteOrder(int orderId);

    }
}
