using Microsoft.EntityFrameworkCore;
using ProniaProject.DAL;

namespace ProniaProject;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddControllersWithViews();
        builder.Services.AddDbContext<AppDbContext>(opt =>
        {
            opt.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSql"));
        });


        var app = builder.Build();
        app.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Dashboard}/{action=Index}");

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.UseStaticFiles();
        app.Run();
    }
}

