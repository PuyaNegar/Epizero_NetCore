using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace WebServicePresentationLayer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                   //  .UseUrls("http://localhost:5003", "http://172.21.9.133:5009"); ;
                });
    }
}
