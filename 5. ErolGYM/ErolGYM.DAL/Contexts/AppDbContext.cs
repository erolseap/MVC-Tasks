using ErolGYM.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace ErolGYM.DAL.Contexts;

public class AppDbContext : DbContext
{
    public DbSet<GymProgram> GymPrograms { get; set; }

    public AppDbContext(DbContextOptions options) : base(options)
    {
    }
}
