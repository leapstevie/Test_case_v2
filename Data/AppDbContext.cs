using Microsoft.EntityFrameworkCore;
using SV35.POS.Models;
namespace SV35.POS.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }

    public DbSet<Category> Category { get; set; }
}