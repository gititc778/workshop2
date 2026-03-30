using TireShopWeb.Data;
using TireShopWeb.Models;

namespace TireShopWeb.Services;

public class TireService
{
    private readonly AppDbContext _context;

    public TireService(AppDbContext context)
    {
        _context = context;
    }

    public List<Tire> GetAll()
    {
        return _context.Tires.ToList();
    }

    public void Add(Tire tire)
    {
        _context.Tires.Add(tire);
        _context.SaveChanges();
    }
}
