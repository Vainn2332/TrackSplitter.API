using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using TrackSplitter.BusinessLogic.Options;
using TrackSplitter.DataAccess.Extensions;

namespace TrackSplitter.BusinessLogic.Extensions;

public static class DiExtensions
{
    extension(IServiceCollection services)
    {
        public IServiceCollection AddBusinessLogicLayer(string connectionString)
        {
            services.AddPostgresDb(connectionString);
            services.ConfigureOptions();
            services.AddRabbitMq();

            return services;
        }

        public IServiceCollection ConfigureOptions()
        {
            services
                .AddOptions<RabbitMqOptions>()
                .BindConfiguration(RabbitMqOptions.SectionName)
                .ValidateDataAnnotations()
                .ValidateOnStart();

            return services;
        }
        public IServiceCollection AddRabbitMq()
        {
            services.AddMassTransit(registrationConfig =>
            {
                registrationConfig.UsingRabbitMq((context, cfg) =>
                {
                    var options = context.GetRequiredService<IOptions<RabbitMqOptions>>().Value;

                    cfg.Host(options.ServerHost, hostConfigurator =>
                    {
                        hostConfigurator.Username(options.UserName);
                        hostConfigurator.Password(options.Password);
                    });
                });
            });

            return services;
        }
    }
}
