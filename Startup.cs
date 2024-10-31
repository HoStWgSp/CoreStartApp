
using Microsoft.EntityFrameworkCore;
using MVCStartApp.DB;
using MVCStartApp.Middlewares;
using MVCStartApp.Repos;

namespace MVCStartApp
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            string connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<BlogContext>(options => options.UseSqlServer(connection));
            services.AddControllersWithViews();// регистрация сервиса репозитория для взаимодействия с базой данных
            services.AddScoped<IBlogRepository, BlogRepository>();
        }
        // Метод вызывается средой ASP.NET.
        // Используйте его для настройки конвейера запросов
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Подключаем логирвоание с использованием ПО промежуточного слоя

            if (env.IsDevelopment() || env.IsStaging())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            app.UseMiddleware<LoggingMiddleware>();
        }
    }
}
