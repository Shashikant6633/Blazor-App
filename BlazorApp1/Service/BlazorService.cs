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


    }
}