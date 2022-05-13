using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OTPService.DataHandler;
using OTPService.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OTPService
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
            services.AddControllersWithViews();
            services.AddOptions();

            services.Configure<ApplicationConfiguration>(Configuration.GetSection("ApplicationConfiguration"));


            ApplicationConfiguration _appConfig = Configuration.GetSection("ApplicationConfiguration").Get<ApplicationConfiguration>();

            OTPConfiguration defOtpConfiguration = _appConfig.DefaultConfig;
            string _connectionString = _appConfig.ConnectionString;
            services.AddScoped<IOTPDataHandler>(x => new OTPDataHandler(_connectionString));

            services.AddScoped<IOTPServiceHandler>(x =>
            {
                IOTPDataHandler dataHandler = x.GetRequiredService<IOTPDataHandler>();
                ILogger<OTPServiceHandler> logger = x.GetRequiredService<ILogger<OTPServiceHandler>>();
                IOptions<ApplicationConfiguration> option = x.GetRequiredService<IOptions<ApplicationConfiguration>>();
                return new OTPServiceHandler(option, dataHandler, logger);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
