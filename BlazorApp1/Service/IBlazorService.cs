using RepositoryLayer.Models;
using ViewModels;

namespace BlazorApp1.Service
{
    public interface IBlazorService
    {
        Task<List<ProductVM>>GetAll();
        Task<int> Add(ProductVM product);

        Task<ProductVM> GetProductById(int productId);
       Task UpdateProduct(ProductVM product);

        Task DeleteProduct(int productId);
    }
}
