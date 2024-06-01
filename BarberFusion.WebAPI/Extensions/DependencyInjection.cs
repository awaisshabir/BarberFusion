using BarberFusion.Application.Interfaces.Repositories;
using BarberFusion.Application.Interfaces.Services;
using BarberFusion.Application.Services;
using BarberFusion.Infrastructure.Data;
using BarberFusion.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using JsonStringEnumConverter = Newtonsoft.Json.Converters.StringEnumConverter;

namespace BarberFusion.WebAPI.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddTransient<IShopService, ShopService>();
            services.AddTransient<IInvoiceService, InvoiceService>();
            services.AddTransient<IServiceService, ServiceService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IRoleService, RoleService>();
            services.AddTransient<ICustomerService, CustomerService>();
            services.AddTransient<IAppointmentService, AppointmentService>();

            return services;
        }
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BarberFusionContext>(options =>
                 options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"))); ;

            services.AddScoped<IShopRepository, ShopRepository>();
            services.AddScoped<IInvoiceRepository, InvoiceRepository>();
            services.AddScoped<IServiceRepository, ServiceRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IAppointmentRepository, AppointmentRepository>();
           

            return services;
        }
        public static IServiceCollection AddNewtonSoftJson(this IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                options.SerializerSettings.Converters.Add(new JsonStringEnumConverter());
                options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
            });

            return services;
        }
    }
}
