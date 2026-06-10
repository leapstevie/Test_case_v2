using System.ComponentModel.DataAnnotations;

namespace SV35.POS.Models;

public class Category
{
    [Key]
    public Guid CategoryId { get; set;}
    [Required(ErrorMessage = "Category name is required")]
    [MaxLength(50)]
    public string CategoryName { get; set; } = string.Empty;
    [MaxLength(100)]
    public string? Description { get; set; }
} 