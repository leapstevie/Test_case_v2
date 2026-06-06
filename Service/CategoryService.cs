using Microsoft.EntityFrameworkCore;
using SV35.POS.Models;
using SV35.POS.Data;

namespace SV35.POS.Service
{
    public class CategoryService : ICategoryService, IDisposable
    {
        private readonly AppDbContext _context;
        public CategoryService (AppDbContext context)
        {
            _context = context;
        }
        public Task<string> AddCategoryAsync(Category category)
        {
            throw new NotImplementedException();
        }

        public Task<string> DeleteCategoryAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Dispose() => _context?.Dispose();
        
        

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
            => await _context.Category.ToListAsync();

        public async Task<Category?> GetCategoryByIdAsync(Guid id)
        => await _context.Category.FindAsync(id);

        public Task<string> UpdateCategoryAsync(Category category)
        {
            throw new NotImplementedException();
        }
    }
}