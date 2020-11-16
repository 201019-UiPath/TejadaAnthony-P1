using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using StoreAppDB;
using StoreAppDB.Interfaces;
using StoreAppLib;

namespace StoreAppAPI
{
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>{
                options.AddPolicy(
                    name: MyAllowSpecificOrigins,
                        builder => {
                            builder.WithOrigins("*")
                            .AllowAnyMethod()
                            .AllowAnyHeader();
                        }
                    );
            });

            services.AddControllers();
            services.AddDbContext<StoreAppContext>(options => options.UseNpgsql(Configuration.GetConnectionString("StoreAppDB")));

            services.AddScoped<IBaseballBatActions, BaseballBatActions>();
            services.AddScoped<IBaseballBatRepoActions, DBRepo>();

            services.AddScoped<IManagerActions, ManagerActions>();
            services.AddScoped<IManagerRepoActions, DBRepo>();

            services.AddScoped<ILocationActions, LocationActions>();
            services.AddScoped<ILocationRepoActions, DBRepo>();

            services.AddScoped<ICustomerActions, CustomerActions>();
            services.AddScoped<ICustomerRepoActions, DBRepo>();

            services.AddScoped<IBaseballBatActions, BaseballBatActions>();
            services.AddScoped<IBaseballBatRepoActions, DBRepo>();

            services.AddScoped<IInventoryActions, InventoryActions>();
            services.AddScoped<IInventoryRepoActions, DBRepo>();

            services.AddScoped<ICartItemActions, CartItemActions>();
            services.AddScoped<ICartItemRepoActions, DBRepo>();

            services.AddScoped<ICartActions, CartActions>();
            services.AddScoped<ICartRepoActions, DBRepo>();

            services.AddScoped<IOrderActions, OrderActions>();
            services.AddScoped<IOrderRepoActions, DBRepo>();

            services.AddScoped<IOrderItemActions, OrderItemActions>();
            services.AddScoped<IOrderItemRepoActions, DBRepo>();

            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;

            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(MyAllowSpecificOrigins);
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

    

        }
    }
}
