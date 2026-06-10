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

        public async Task<string> AddCategoryAsync(Category category)
        {
            try
            {
                await _context.Category.AddAsync(category);
                await _context.SaveChangesAsync();
                return "Added";
            }
            catch (Exception ex)
            {
               return ex.Message.ToString();
            }
        }

        public async Task<string> DeleteCategoryAsync(Guid id)
        {
            try
            {
                var category = await _context.Category.FindAsync(id);
                if (category is null)
                {
                    return "Not found";
                }
                _context.Category.Remove(category);
                await _context.SaveChangesAsync();
                return "Deleted";
            }
            catch (Exception ex)
            {
               return ex.Message.ToString();
            }
        }

        public void Dispose() => _context?.Dispose();
        

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
            => await _context.Category.ToListAsync();

        public async Task<Category?> GetCategoryByIdAsync(Guid id)
            => await _context.Category.FindAsync(id);

        public async Task<string> UpdateCategoryAsync(Category category)
        {
            try
            {
             var existingCategory = await _context.Category.FindAsync(category.CategoryId);    
            if (existingCategory is null)
                {
                    return "Not found";
                }
            _context.Category.Attach(existingCategory);
            existingCategory.CategoryName = category.CategoryName;
            existingCategory.Description = category.Description;
            await _context.SaveChangesAsync();
            return "Updated";
            } catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }
    }
}