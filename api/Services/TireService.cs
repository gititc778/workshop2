using System.Collections.Generic;
using System.Linq;
using TireShop.Data;
using TireShop.Models;

namespace TireShop.Services;

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

    public Tire Add(Tire tire)
    {
        _context.Tires.Add(tire);
        _context.SaveChanges();
        return tire;
    }
}
