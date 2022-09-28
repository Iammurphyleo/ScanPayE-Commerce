using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Scanpay.AuthenticationAndAuthorization;
using Scanpay.Contex;
using Scanpay.Controllers;
using Scanpay.EmailServices;
using Scanpay.Implementation.Repository;
using Scanpay.Implementation.Service;
using Scanpay.Interface;
using Scanpay.Interface.Repository;
using Scanpay.Interface.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scanpay
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

            services.AddDbContext<ScanPayContext>(options => 
            options.UseMySQL(Configuration.GetConnectionString("ConnectionString")));

            services.AddScoped<IBrandService, BrandService>();
            services.AddCors(c => c.AddPolicy("MyPolicy" , builder => builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()));

            services.AddScoped<IBrandRepository, BrandRepository>();

            services.AddScoped<ICategoryService, CategoryService>();

            services.AddScoped<ICategoryRepository, CategoryRepository>();

            services.AddScoped<ICustomerService, CustomerService>();

            services.AddScoped<ICustomerRepository, CustomerRepository>();

            services.AddScoped<IItemService, ItemService>();

            services.AddScoped<IItemRepository, ItemRepository>();

            services.AddScoped<IOrderService, OrderService>();

            services.AddScoped<IOrderRepository, OrderRepository>();

            services.AddScoped<IPaymentService, PaymentService>();

            services.AddScoped<IPaymentRepository, PaymentRepository>();

            services.AddScoped<IStockService, StockService>();

            services.AddScoped<IStockRepository, StockRepository>();

            services.AddScoped<IRoleService,RoleService>();

            services.AddScoped<IRoleRepository, RoleRepository>();

            services.AddScoped<IStaffService, StaffService>();

            services.AddScoped<IStaffRepository, StaffRepository>();

            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICartRepository, CartRepository>();
            services.AddScoped<ICartService, CartService>();

            services.AddScoped<IMailServices, MailService>();


            services.AddControllersWithViews();

            var key = "This is our key that we are using to authorixe our user";

            services.AddSingleton<IJwtAuthenticationManager>(new JwtAuthenticationManager(key));

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Scanpay", Version = "v1" });
            });
        }

        

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Scanpay v1"));
            }

            app.UseHttpsRedirection();
            app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
