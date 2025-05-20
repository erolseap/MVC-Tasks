using ErolScholar.DAL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ErolScholar.DAL.Contexts;

public class AppDbContext : IdentityDbContext<UserModel>
{
    public DbSet<UpcomingEvent> UpcomingEvents { get; set; }

    public AppDbContext(DbContextOptions opts) : base(opts)
    {
    }
}
