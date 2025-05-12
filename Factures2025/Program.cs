
using Entities;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Factures2025
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            //ajouter un service pour se connecter à la base de données
            //= SqliteContext ctx = new SqliteContext();
            builder.Services.AddDbContextFactory<SqliteContext>();

            //lignes pour l'authentification
            builder.Services.AddSession();
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
            {
                options.LoginPath = "/Login/Login";
                options.AccessDeniedPath = "/Maison/AccessDenied";
                options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
            });
            builder.Services.AddHttpContextAccessor();



            var app = builder.Build();

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

            //!!!!!!!!!!!!!!!!!!!!!!!!!!!!HYPER IMPORTANT QUE CETTE LIGNE SOIT AVANT 
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSession();


            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Article}/{action=Index}/{id?}");

            app.Run();
            
        }
    }
}
