namespace MVCStartUpp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }
        /// <summary>
        /// —татический метод, создающий и настраивающий IHostBuilder -
        /// объект, который в свою очередь создает хост дл€ развертывани€ Core-приложени€
        /// </summary>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
           Host.CreateDefaultBuilder(args)
               .ConfigureWebHostDefaults(webBuilder =>
               {
                   webBuilder.UseStartup<Startup>();
               });
    }
}
