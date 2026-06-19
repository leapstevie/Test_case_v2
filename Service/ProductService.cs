using Microsoft.EntityFrameworkCore;
using SV35.POS.Models;
using SV35.POS.Data;

namespace SV35.POS.Service
{
    public class ProductService : IProductService, IDisposable
    {
        private readonly AppDbContext _context;
        public ProductService (AppDbContext context)
        {
            _context = context;
        }

        public async Task<string> AddProductAsync(Product product)
        {
            try
            {
                await _context.Product.AddAsync(product);
                await _context.SaveChangesAsync();
                return "Added";
            }
            catch (Exception ex)
            {
               return ex.Message.ToString();
            }
        }

        public async Task<string> DeleteProductAsync(Guid id)
        {
            try
            {
                var product = await _context.Product.FindAsync(id);
                if (product is null)
                {
                    return "Not found";
                }
                _context.Product.Remove(product);
                await _context.SaveChangesAsync();
                return "Deleted";
            }
            catch (Exception ex)
            {
               return ex.Message.ToString();
            }
        }

        public void Dispose() => _context?.Dispose();
        

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
            => await _context.Product.ToListAsync();

        public async Task<Product?> GetProductByIdAsync(Guid id)
            => await _context.Product.FindAsync(id);

        public async Task<string> UpdateProductAsync(Product product)
        {
            try
            {
             var existingProduct = await _context.Product.FindAsync(product.ProductId);    
            if (existingProduct is null)
                {
                    return "Not found";
                }
            _context.Product.Attach(existingProduct);
            existingProduct.ProductName = product.ProductName;
            existingProduct.Description = product.Description;
            await _context.SaveChangesAsync();
            return "Updated";
            } catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }
    }
}