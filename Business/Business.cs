using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer;
using RepositoryLayer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using ViewModels;

namespace BusinessLayer
{
    public class Business : IBusiness
    {
        private readonly IRepository _repo;
        private readonly IMapper _mapper;

        public Business(IRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<List<ProductVM>> GetProducts()
        {
            // Await the Task<IQueryable<Product>> to get the actual IQueryable<Product>
            var data =  _repo.GetProducts();

            // Use ToListAsync on the IQueryable<Product> result
            var products = await data.ToListAsync();

            // Use _mapper.Map to map the data to ProductVM
            var productVMs = _mapper.Map<List<ProductVM>>(products);

            return productVMs;
        }

        public async Task<int> AddProduct(ProductVM product)
        {
            var data = _mapper.Map<ProductVM, Product>(product);
            var result = _repo.AddProduct(data);
            return result.Id;
        }

        public async Task UpdateProduct(int productId, ProductVM updatedProduct)
        {
            var existingProduct = await _repo.GetProductById(productId);

            if (existingProduct != null)
            {
                // Update properties of existingProduct with values from updatedProduct
                existingProduct.Name = updatedProduct.Name;
                existingProduct.Price = updatedProduct.Price;
                existingProduct.Description = updatedProduct.Description;

                // Save changes
                await _repo.UpdateProduct(existingProduct);
            }
        }

        public async Task<ProductVM> GetProductById(int productId)
        {
           // var product = await _repo.GetProductById(productId);
           var product = await _repo.GetProducts().Include(x=> x.Orders).Where(x => x.Id == productId).FirstOrDefaultAsync();

            if (product == null)
            {
                return null;
            }

            var productVM = _mapper.Map<ProductVM>(product);
            return productVM;
        }

        public async Task DeleteProduct(int productId)
        {
            await _repo.DeleteProduct(productId);
        }

        // Students Data form here below...

        public async Task<List<StudentVM>> GetStudents()
        {
            // Await the Task<IQueryable<Product>> to get the actual IQueryable<Product>
            var data = await _repo.GetStudents();

            // Use ToListAsync on the IQueryable<Product> result
            var students = await data.ToListAsync();

            // Use _mapper.Map to map the data to ProductVM
            var studentVMs = _mapper.Map<List<StudentVM>>(students);

            return studentVMs;
        }

        public async Task<int> AddStudent(StudentVM student)
        {
            var data = _mapper.Map<StudentVM, Student>(student);
            var result = _repo.AddStudent(data);
            return result.Id;
        }

        public async Task UpdateStudent(int studentId, StudentVM updatedStudent)
        {
            var existingStudent = await _repo.GetStudentById(studentId);

            if (existingStudent != null)
            {
                // Update properties of existingProduct with values from updatedProduct
                existingStudent.Name = updatedStudent.Name;
                existingStudent.Course = updatedStudent.Course;

                // Save changes
                await _repo.UpdateStudent(existingStudent);
            }
        }

        public async Task<StudentVM> GetStudentById(int studentId)
        {
            var student = await _repo.GetStudentById(studentId);

            if (student == null)
            {
                return null;
            }

            var studentVM = _mapper.Map<StudentVM>(student);
            return studentVM;
        }

        public async Task DeleteStudent(int studentId)
        {
            await _repo.DeleteStudent(studentId);
        }

        public async Task<ProductVM> GetById(int id)
        {
            var data = await _repo.GetProducts().Include(x => x.Orders).Where(x => x.Id == id).FirstOrDefaultAsync();


            var products = _mapper.Map<Product, ProductVM>(data);


            return products;
        }

        public async Task<List<OrderVM>> GetOrders()
        {
            // Await the Task<IQueryable<Product>> to get the actual IQueryable<Product>
            var data = _repo.GetOrders();

            // Use ToListAsync on the IQueryable<Product> result
            var orders = await data.ToListAsync();

            // Use _mapper.Map to map the data to ProductVM
            var orderVMs = _mapper.Map<List<OrderVM>>(orders);

            return orderVMs;
        }

        public async Task<List<OrderVM>> GetOrdersByProductId(int productId)
        {
            var orders = await _repo.GetOrdersByProductId(productId);
            var orderVMs = _mapper.Map<List<OrderVM>>(orders);
            return orderVMs;
        }
    }
}