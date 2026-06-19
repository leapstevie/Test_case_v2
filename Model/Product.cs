using System.ComponentModel.DataAnnotations;

namespace SV35.POS.Models;

public class Product
{
    [Key]
    public Guid ProductId { get; set;}
    [Required(ErrorMessage = "Product name is required")]
    [MaxLength(50)]
    public string ProductName { get; set; } = string.Empty;
    [MaxLength(100)]
    public string? Description { get; set; }
} 