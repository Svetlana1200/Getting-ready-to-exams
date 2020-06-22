using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using EnglishTest.Models;
using System;
using MongoDB.Driver;

namespace EnglishTest
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<TaskService>();
            services.AddSingleton<MongoClient>(s => new MongoClient(GetConnectionString()));

            services.AddDistributedMemoryCache();
            services.AddSession();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        private string GetConnectionString()
        {
            var user = Environment.GetEnvironmentVariable("MONGODB_USERNAME");
            var password = Environment.GetEnvironmentVariable("MONGODB_PASSWORD");
            var cluster = Environment.GetEnvironmentVariable("MONGODB_CLUSTER");
            return $"mongodb+srv://{user}:{password}@{cluster}/englishTest?retryWrites=true&w=majority";
        }
    }
}
