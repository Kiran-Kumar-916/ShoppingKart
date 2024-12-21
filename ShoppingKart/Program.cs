using FirstMVCapp.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

namespace FirstMVCapp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container
            builder.Services.AddControllersWithViews();

            // Configure Entity Framework with SQL Server
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Add session services
            builder.Services.AddDistributedMemoryCache(); // Required for session state
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30); // Set session timeout
                options.Cookie.HttpOnly = true; // Security settings
                options.Cookie.IsEssential = true; // Essential for GDPR compliance
            });

            // Add authentication services
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/Account/Login"; // Redirect to this path for unauthenticated access
                    options.AccessDeniedPath = "/Account/AccessDenied"; // Redirect here if access is denied
                });

            var app = builder.Build();

            // Configure the HTTP request pipeline
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts(); // Enable HTTP Strict Transport Security (HSTS)
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseSession(); // Add session middleware

            app.UseAuthentication(); // Ensure authentication middleware is added
            app.UseAuthorization();  // Ensure authorization middleware is added

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}



//using FirstMVCapp.Models;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Design;
//using Microsoft.EntityFrameworkCore.SqlServer;

//namespace FirstMVCapp
//{
//    public class Program
//    {
//        public static void Main(string[] args)
//        {
//            var builder = WebApplication.CreateBuilder(args);

//            // Add services to the container.
//            builder.Services.AddControllersWithViews();
//            //builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase("InMemoryDatabase"));

//            // Add session services
//            builder.Services.AddDistributedMemoryCache(); // Required for session state
//            builder.Services.AddSession(options =>
//            {
//                options.IdleTimeout = TimeSpan.FromMinutes(30); // Set session timeout
//                options.Cookie.HttpOnly = true; // Security settings
//                options.Cookie.IsEssential = true; // Essential for GDPR compliance
//            });



//            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//            var app = builder.Build();

//            // Configure the HTTP request pipeline.
//            if (!app.Environment.IsDevelopment())
//            {
//                app.UseExceptionHandler("/Home/Error");
//                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//                app.UseHsts();
//            }

//            app.UseHttpsRedirection();
//            app.UseStaticFiles();

//            app.UseRouting();

//            app.UseSession(); // Add session middleware

//            app.UseAuthentication();
//            app.UseAuthorization();

//            app.MapControllerRoute(
//                name: "default",
//                pattern: "{controller=Home}/{action=Index}/{id?}");

//            app.Run();
//        }
//    }
//}