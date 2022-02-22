using Feedback.FeedbackData;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Feedback
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            // Automaattinen migraatio / skeemaaminen azurea varten

            var service = (IServiceScopeFactory)host.Services.GetService(typeof(IServiceScopeFactory));
            
            using(var db = service.CreateScope().ServiceProvider.GetService<FeedbackContext>())
            {
                db.Database.Migrate();
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
