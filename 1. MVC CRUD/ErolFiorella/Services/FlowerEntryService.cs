using ErolFiorella.Contexts;
using ErolFiorella.Models;

namespace ErolFiorella.Services;

public class FlowerEntryService
{
    protected AppDbContext _context = new();

    #region Create
    public void Create(FlowerEntry entry)
    {
        _context.Add(entry);
        _context.SaveChanges();
    }
    #endregion

    #region Read
    public FlowerEntry? GetById(int id)
    {
        return _context.FlowerEntries.Find(id);
    }

    public List<FlowerEntry> GetAll()
    {
        return _context.FlowerEntries.ToList();
    }
    #endregion

    #region Delete
    public void Delete(int id)
    {
        var entry = GetById(id);
        if (entry == null) return;
        _context.FlowerEntries.Remove(entry);
        _context.SaveChanges();
    }
    #endregion
}
