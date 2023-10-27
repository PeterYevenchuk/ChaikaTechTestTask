using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace ChaikaTechTestTask.Core
{
    public class CoreServiceConfiguration
    {
        public static IServiceCollection ConfigureServices(IServiceCollection services)
        {
            return services
                .AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CoreServiceConfiguration).Assembly))
                .AddAutoMapper(typeof(CoreMappingsProfile).Assembly)
                .AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>))
                .AddValidatorsFromAssembly(typeof(CoreServiceConfiguration).Assembly);
        }
    }
}
