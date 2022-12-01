using Microsoft.EntityFrameworkCore;
using FE_CURD.Data;
using FE_CURD.Models;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        //builder.Services.AddDbContext<FE_CURDContext>(options =>
        //    options.UseSqlServer(builder.Configuration.GetConnectionString("FE_CURDContext") ?? throw new InvalidOperationException("Connection string 'FE_CURDContext' not found.")));

        //// Add services to the container.
        builder.Services.AddControllersWithViews();
        builder = WebApplication.CreateBuilder(args);
        builder.Services.AddRazorPages();

        builder.Services.AddDbContext<MvcMovieContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("FE_CURDContext")));
        //builder.Services.AddDbContext<MvcMovieContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("FE_CURDContext")));

        var app = builder.Build();
        //using (var scope = app.Services.CreateScope())
        //{
        //    var services = scope.ServiceProvider;

        //    SeedData.Initialize(services);
        //}



        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}