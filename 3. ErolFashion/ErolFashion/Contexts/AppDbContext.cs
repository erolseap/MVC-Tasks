using ErolFashion.Models;
using Microsoft.EntityFrameworkCore;

namespace ErolFashion.Contexts;

public class AppDbContext : DbContext
{
    protected readonly string _connectionInfo = @"Server=DESKTOP-GTVND9D\SQLEXPRESS;Database=FashionDB;Trusted_Connection=True;TrustServerCertificate=True;";

    public DbSet<FeaturedProduct> FeaturedProducts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_connectionInfo);
        base.OnConfiguring(optionsBuilder);
    }
}
