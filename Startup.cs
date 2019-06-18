using System;
using System.Text;
using dotenv.net.DependencyInjection.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Portfolio.Dao;
using Portfolio.Models;

namespace Portfolio
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
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddRazorOptions(options => { options.PageViewLocationFormats.Add("/Pages/Partials/{0}.cshtml"); });
            services.AddEntityFrameworkNpgsql()
                .AddDbContext<PortfolioEntities>()
                .BuildServiceProvider();
            services.AddScoped<Db>();
            services.AddEnv(builder =>
            {
                builder
                    .AddEnvFile("./.env")
                    .AddThrowOnError(false)
                    .AddEncoding(Encoding.ASCII);
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseMvc();
            using (var context = new PortfolioEntities())
            {
                // context.Database.EnsureDeleted();
                // context.Database.EnsureCreated();
                // context.Seed(context);
            }
        }
    }
}