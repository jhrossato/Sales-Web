
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using SalesWebMvc.Services;
using SalesWebMvc.Data;
using Microsoft.EntityFrameworkCore;

namespace SalesWebMvc
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var SqlConnection = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<SalesWebMvcContext>(options =>
                options.UseSqlServer(SqlConnection));

            
            
            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddTransient<SeedingService>();
            builder.Services.AddScoped<SellerService>();
            builder.Services.AddScoped<DepartmentService>();

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
            
            SeedData(); //Chama a funcao para preencher o banco de dados

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();

            void SeedData() //preenche o banco de dados com SeedingService
            {
                using (var scope = app.Services.CreateScope())
                {
                    var service = scope.ServiceProvider.GetRequiredService<SeedingService>();
                    service.Seed();
                }
            }
        }
    }
}