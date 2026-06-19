using SV35.POS.Models;

namespace SV35.POS.Service
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product?> GetProductByIdAsync(Guid id);
        Task<string> AddProductAsync(Product product);
        Task<string> UpdateProductAsync(Product product);
        Task<string> DeleteProductAsync(Guid id);
    }
}
