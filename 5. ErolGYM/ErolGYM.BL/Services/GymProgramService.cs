using ErolGYM.DAL.Contexts;
using ErolGYM.DAL.Models;

namespace ErolGYM.BL.Services;

public class GymProgramService
{
    protected readonly AppDbContext _context;

    public GymProgramService(AppDbContext context)
    {
        _context = context;
    }

    #region Create
    public void Create(GymProgram model)
    {
        _context.GymPrograms.Add(model);
        _context.SaveChanges();
    }
    #endregion

    #region Read
    public GymProgram? GetById(int id) => _context.GymPrograms.Find(id);
    public List<GymProgram> GetAll() => _context.GymPrograms.ToList();
    #endregion

    #region Update
    public void Update(int id, GymProgram model)
    {
        if (model == null)
        {
            throw new ArgumentNullException(nameof(model));
        }
        if (id != model.Id)
        {
            throw new ArgumentException("The provided argument model id does not match with the id argument");
        }
        if (GetById(id) != model)
        {
            throw new ArgumentException("The provided argument model reference must match to the original entity one");
        }
        _context.SaveChanges();
    }
    #endregion

    #region Delete
    public void Delete(int id)
    {
        var model = GetById(id);
        if (model == null) return;
        _context.GymPrograms.Remove(model);
        _context.SaveChanges();
    }
    #endregion
}
