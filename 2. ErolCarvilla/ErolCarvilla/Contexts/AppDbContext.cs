using ErolCarvilla.Models;
using Microsoft.EntityFrameworkCore;

namespace ErolCarvilla.Contexts;

public class AppDbContext : DbContext
{
    protected readonly string _connectionInfo = @"Server=DESKTOP-GTVND9D\SQLEXPRESS;Database=CarvillaDB;Trusted_Connection=True;TrustServerCertificate=True;";

    public DbSet<FeaturedCar> FeaturedCars { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_connectionInfo);
        base.OnConfiguring(optionsBuilder);
    }
}
