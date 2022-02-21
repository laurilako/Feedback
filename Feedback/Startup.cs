using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Feedback.Models;
using Feedback.FeedbackData;
using Microsoft.Data.SqlClient;
using AutoMapper;

namespace Feedback
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {


            // Haetaan DbPassword user-secretseist‰ ja rakennetaan connectionString.
            var builder = new SqlConnectionStringBuilder(
                Configuration.GetConnectionString("FeedbackCon"));
            builder.Password = Configuration["DbPassword"];

            services.AddDbContext<FeedbackContext>(opt => opt.UseSqlServer
                (builder.ConnectionString));

            services.AddCors();
            services.AddControllers();


            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


            // Dependecy injection, kerrotaan mit‰ repository‰ k‰ytt‰‰ (esim kysyy Ifeedback, annetaan MockFeedback. tai sqlFeedback
            // services.AddScoped<IFeedback, MockFeedback>();
            services.AddScoped<IFeedback, SqlFeedback>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            // Cors policyn asettaminen
            app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true)
                .AllowCredentials());


            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
