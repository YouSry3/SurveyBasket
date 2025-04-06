using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace SurveyBasket
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services)
    {
            // Add services to the container.

            services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            // add service mapper 
            var MappingConfigs = TypeAdapterConfig.GlobalSettings;
            MappingConfigs.Scan(Assembly.GetExecutingAssembly());


            services.AddSingleton<IMapper>(new Mapper(MappingConfigs));


            services.AddSingleton<IPollService, PollService>();

            services
                .AddFluentValidationAutoValidation()
                .AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());


            return services;

    }

}
}
