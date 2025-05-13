using ErolCarvilla.Contexts;
using ErolCarvilla.Models;
using Microsoft.EntityFrameworkCore;

namespace ErolCarvilla.Services;

public class FeaturedCarsService
{
    protected AppDbContext _context = new();

    #region Create
    public void Create(FeaturedCar entry)
    {
        _context.Add(entry);
        _context.SaveChanges();
    }
    #endregion

    #region Read
    public FeaturedCar? GetById(int id)
    {
        return _context.FeaturedCars.Find(id);
    }

    public List<FeaturedCar> GetAll()
    {
        return _context.FeaturedCars.ToList();
    }
    #endregion

    #region Update
    public void Update(int id, FeaturedCar car)
    {
        throw new NotImplementedException();
    }
    #endregion

    #region Delete
    public void Delete(int id)
    {
        var entry = GetById(id);
        if (entry == null) return;
        _context.FeaturedCars.Remove(entry);
        _context.SaveChanges();
    }
    #endregion
}
