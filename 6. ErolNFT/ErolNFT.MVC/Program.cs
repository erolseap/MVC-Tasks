using ErolNFT.DAL.Contexts;
using ErolNFT.BL.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(ctx => ctx.UseSqlServer(builder.Configuration.GetConnectionString("default")));
builder.Services.AddScoped<CollectionService>();

var app = builder.Build();
app.UseStaticFiles();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{Controller=Home}/{Action=Index}/{id?}"
);

app.MapControllerRoute(
    name: "default",
    pattern: "{Controller=Home}/{Action=Index}/{id?}"
);

app.Run();
