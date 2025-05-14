namespace ErolCharityNTIER.MVC;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddControllersWithViews();

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

    }
}
