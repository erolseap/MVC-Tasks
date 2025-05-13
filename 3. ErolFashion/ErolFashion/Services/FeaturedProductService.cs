using ErolFashion.Contexts;
using ErolFashion.Models;
using Microsoft.EntityFrameworkCore;

namespace ErolFashion.Services;

public class FeaturedProductService
{
    protected AppDbContext _context;

    public FeaturedProductService()
    {
        _context = new();
    }

    #region Create
    public void Create(FeaturedProduct entry)
    {
        _context.Add(entry);
        _context.SaveChanges();
    }
    #endregion

    #region Read
    public FeaturedProduct? GetById(int id)
    {
        return _context.FeaturedProducts.Find(id);
    }

    public List<FeaturedProduct> GetAll()
    {
        return _context.FeaturedProducts.ToList();
    }
    #endregion

    #region Update
    public void Update(int id, FeaturedProduct entry)
    {
        if (id != entry.Id)
        {
            throw new Exception("IDs mismatch");
        }
        if (GetById(id) != entry)
        {
            throw new Exception("References should match");
        }
        _context.SaveChanges();
    }
    #endregion

    #region Delete
    public void Delete(int id)
    {
        var entry = GetById(id);
        if (entry == null) return;
        _context.FeaturedProducts.Remove(entry);
        _context.SaveChanges();
    }
    #endregion
}
