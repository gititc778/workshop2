using Microsoft.EntityFrameworkCore;
using TireShopWeb.Models;

namespace TireShopWeb.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Tire> Tires { get; set; }
}
