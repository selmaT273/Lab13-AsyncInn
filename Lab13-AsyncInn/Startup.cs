using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab13_AsyncInn.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore;
using Lab13_AsyncInn.Data.Repositories;
using Microsoft.OpenApi.Models;
using Lab13_AsyncInn.Models;
using Microsoft.AspNetCore.Identity;

namespace Lab13_AsyncInn
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }



        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddDbContext<HotelDbContext>(options =>
            {
                string connectionString = Configuration.GetConnectionString("DefaultConnection");
                if (connectionString == null)
                {
                    throw new Exception();
                }
                options.UseSqlServer(connectionString);
            });

            services
                .AddIdentity<Applicationuser, IdentityRole>(options =>
                {
                    options.User.RequireUniqueEmail = true;
                })
                .AddEntityFrameworkStores<HotelDbContext>();

            services.AddTransient<IUserService, IdentityUserService>();
            services.AddScoped<JwtTokenService>();
            

            services.AddTransient<IHotelRepository, HotelRepository>();
            services.AddTransient<IRoomRepository, RoomRepository>();
            services.AddTransient<IAmenitiesRepository, AmenitiesRepository>();
            services.AddTransient<IHotelRoomRepository, HotelRoomRepository>();

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "Async Inn", Version = "v1" });
            });
        }
        

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger(options =>
            {
                options.RouteTemplate = "/api/{documentName}/swagger.json";
            });

            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/api/v1/swagger.json", "Async Inn!");
                options.RoutePrefix = "";
            });

            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
             
            });
        }
    }
}
