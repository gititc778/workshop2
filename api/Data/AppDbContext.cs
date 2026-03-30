using Microsoft.EntityFrameworkCore;
using TireShop.Models;

namespace TireShop.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Tire> Tires { get; set; }
}
