using SV35.POS.Models;

namespace SV35.POS.Service
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllCategoriesAsync();
        Task<Category?> GetCategoryByIdAsync(Guid id);
        Task<string> AddCategoryAsync(Category category);
        Task<string> UpdateCategoryAsync(Category category);
        Task<string> DeleteCategoryAsync(Guid id);
    }
}
