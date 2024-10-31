using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace CoreStartApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // ������� �������������� ��������� 
            //PrintMessage((() => Info("��������� ����������")));

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
                   // �������������� ���� �� ����������� ������ �� ���������
                   webBuilder.UseWebRoot("Views");
               });
    }
}
