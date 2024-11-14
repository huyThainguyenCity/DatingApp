using Microsoft.EntityFrameworkCore;
using UngDungHenHo.Data;
using UngDungHenHo.Interfaces;
using UngDungHenHo.Services;

namespace UngDungHenHo.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services,
            IConfiguration config)
        {
            services.AddControllers();
            services.AddDbContext<DataContext>(opt =>
            {
                opt.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            });
            services.AddCors();
            services.AddScoped<ITokenService, TokenService>();

            return services;
        }
}
