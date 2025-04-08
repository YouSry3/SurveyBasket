using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SurveyBasket.Entities;
using System.Reflection;

namespace SurveyBasket
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services,IConfiguration configuration)
    {
            // Add services to the container.

            services.AddControllers();
            services.addConnectDB(configuration);



            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            // add service mapper 
            var MappingConfigs = TypeAdapterConfig.GlobalSettings;
            MappingConfigs.Scan(Assembly.GetExecutingAssembly());


            services.AddSingleton<IMapper>(new Mapper(MappingConfigs));
            //services.AddSingleton<IPollService, PollService>();

            services
                .AddFluentValidationAutoValidation()
                .AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());




            return services;

    }
        public static IServiceCollection addConnectDB(this IServiceCollection services,IConfiguration configuration)
        {
                    var connectionString = configuration.GetConnectionString("DefaultContection") ??
                    throw new InvalidOperationException("Contection string 'DefaultContection' undefind .");

                    services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(connectionString));
                    return services;

        }

}
}
