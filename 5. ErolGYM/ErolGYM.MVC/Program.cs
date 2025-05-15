using Microsoft.EntityFrameworkCore;
using ErolGYM.DAL.Contexts;
using ErolGYM.BL.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(ctx => ctx.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
builder.Services.AddScoped<GymProgramService>();

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
