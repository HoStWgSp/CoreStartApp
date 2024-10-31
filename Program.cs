namespace MVCStartApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            
            CreateHostBuilder(args).Build().Run();
        }
        /// <summary>
        /// Статический метод, создающий и настраивающий IHostBuilder -
        /// объект, который в свою очередь создает хост для развертывания Core-приложения
        /// </summary>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
           Host.CreateDefaultBuilder(args)
               .ConfigureWebHostDefaults(webBuilder =>
               {
                   webBuilder.UseStartup<Startup>();
                   // Переопределяем путь до статических файлов по умолчанию
                   webBuilder.UseWebRoot("Views");
               });
    }
}
