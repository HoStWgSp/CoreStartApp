using Microsoft.AspNetCore.Builder;

namespace CoreStartApp
{
    public class Startup
    {
        // Метод вызывается средой ASP.NET.
        // Используйте его для подключения сервисов приложения
        // Документация:  https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // Метод вызывается средой ASP.NET.
        // Используйте его для настройки конвейера запросов
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment() || env.IsStaging())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            //Используем метод Use, чтобы запрос передавался дальше по конвейеру
            app.Use(async (context, next) =>
            {
                // Строка для публикации в лог
                string logMessage = $"[{DateTime.Now}]: New request to http://{context.Request.Host.Value + context.Request.Path}{Environment.NewLine}";

                // Путь до лога (опять-таки, используем свойства IWebHostEnvironment)
                string logFilePath = Path.Combine(env.ContentRootPath, "Logs", "RequestLog.txt");

                // Используем асинхронную запись в файл
                await File.AppendAllTextAsync(logFilePath, logMessage);

                await next.Invoke();
            });


            // Сначала используем метод Use, чтобы не прерывать ковейер
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync($"Welcome to the {env.ApplicationName}!");
                });

                endpoints.MapGet("/config", async context =>
                {
                    await context.Response.WriteAsync($"App name: {env.ApplicationName}. App running configuration: {env.EnvironmentName}");
                });
                endpoints.MapGet("/about", async context =>
                {
                    await context.Response.WriteAsync($"{env.ApplicationName} - ASP.Net Core tutorial project");
                });
            });


            // Обработчик для ошибки "страница не найдена"
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync($"Page not found");
            });
        }
    }
}
