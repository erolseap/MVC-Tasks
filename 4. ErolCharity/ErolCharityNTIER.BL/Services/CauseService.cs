using ErolCharityNTIER.DAL.Contexts;
using ErolCharityNTIER.DAL.Models;

namespace ErolCharityNTIER.BL.Services;

public class CauseService
{
    protected AppDbContext _context;

    public CauseService()
    {
        _context = new();
    }

    #region Create
    public void Create(Cause cause)
    {
        _context.Causes.Add(cause);
        _context.SaveChanges();
    }
    #endregion

    #region Read
    public Cause? GetById(int id)
    {
        return _context.Causes.Find(id);
    }

    public List<Cause> GetAll()
    {
        return _context.Causes.ToList();
    }
    #endregion

    #region Update
    public void Update(int id, Cause cause)
    {
        if (cause == null)
        {
            throw new ArgumentNullException(nameof(cause));
        }
        if (id != cause.Id)
        {
            throw new Exception("IDs mismatching");
        }
        if (GetById(id) != cause)
        {
            throw new Exception("References must match");
        }
        _context.SaveChanges();
    }
    #endregion

    #region Delete
    public void Delete(int id)
    {
        var cause = GetById(id);
        if (cause == null) return;
        _context.Causes.Remove(cause);
        _context.SaveChanges();
    }
    #endregion
}
