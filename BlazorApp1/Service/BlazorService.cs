﻿using RepositoryLayer.Models;
using System.Net.Http.Json;
using ViewModels;

namespace BlazorApp1.Service
{
    public class BlazorService : IBlazorService
    {
        private readonly HttpClient _httpClient;

        public BlazorService(HttpClient httpClient)
        {
            _httpClient = new HttpClient();
        }


        public async Task<List<ProductVM>> GetAll(){
            var products = await _httpClient.GetFromJsonAsync<List<ProductVM>>("https://localhost:44393/api/products/GetProducts");
            return products;
        }

        public async Task<int> Add(ProductVM product)
        {
            var response = await _httpClient.PostAsJsonAsync("https://localhost:44393/api/products/AddProduct",product);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<int>();
        }

        public async Task<ProductVM> GetProductById(int productId)
        {
            var product = await _httpClient.GetFromJsonAsync<ProductVM>($"https://localhost:44393/api/products/GetProductById/{productId}");
            return product;
        }

        public async Task UpdateProduct(ProductVM product)
        {
            var response = await _httpClient.PutAsJsonAsync($"https://localhost:44393/api/products/UpdateProduct/{product.Id}", product);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteProduct(int productId)
        {
            // Make a DELETE request to delete the product
            await _httpClient.DeleteAsync($"https://localhost:44393/api/products/DeleteProduct/{productId}");
        }

        // Students Data....
        public async Task<List<StudentVM>> GetAllStudents()
        {
            var students = await _httpClient.GetFromJsonAsync<List<StudentVM>>("https://localhost:44393/api/students/GetStudents");
            return students;
        }

        public async Task<int> Add(StudentVM student)
        {
            var response = await _httpClient.PostAsJsonAsync("https://localhost:44393/api/students/AddStudent", student);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<int>();
        }

        public async Task<StudentVM> GetStudentById(int studentId)
        {
            var student = await _httpClient.GetFromJsonAsync<StudentVM>($"https://localhost:44393/api/students/GetStudentById/{studentId}");
            return student;
        }

        public async Task UpdateStudent(StudentVM student)
        {
            var response = await _httpClient.PutAsJsonAsync($"https://localhost:44393/api/students/UpdateStudent/{student.Id}", student);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteStudent(int studentId)
        {
            // Make a DELETE request to delete the product
            await _httpClient.DeleteAsync($"https://localhost:44393/api/students/DeleteStudent/{studentId}");
        }


        public async Task<ProductVM> GetById(int id)
        {
            return await _httpClient.GetFromJsonAsync<ProductVM>($"https://localhost:44393/api/products/{id}");
        }

        public async Task<List<OrderVM>> GetAllOrders()
        {
            var orders = await _httpClient.GetFromJsonAsync<List<OrderVM>>($"https://localhost:44393/api/orders/GetOrders");
            return orders;
        }

        public async Task<List<OrderVM>> GetOrdersByProductId(int productId)
        {
            var orders = await _httpClient.GetFromJsonAsync<List<OrderVM>>($"https://localhost:44393/api/orders/GetOrdersByProductId/{productId}");
            return orders;
        }

        public async Task<int> AddOrder(int productId, OrderVM order)
        {
            var response = await _httpClient.PostAsJsonAsync($"https://localhost:44393/api/orders/addorder?productId={productId}", order);

            return await response.Content.ReadFromJsonAsync<int>();
        }
        public async Task DeleteOrder(int orderId)
        {
            // Make a DELETE request to delete the product
            await _httpClient.DeleteAsync($"https://localhost:44393/api/orders/DeleteOrder/{orderId}");
        }
    }
}