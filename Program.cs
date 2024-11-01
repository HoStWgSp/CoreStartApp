namespace MVCStartUpp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }
        /// <summary>
        /// ����������� �����, ��������� � ������������� IHostBuilder -
        /// ������, ������� � ���� ������� ������� ���� ��� ������������� Core-����������
        /// </summary>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
           Host.CreateDefaultBuilder(args)
               .ConfigureWebHostDefaults(webBuilder =>
               {
                   webBuilder.UseStartup<Startup>();
               });
    }
}
