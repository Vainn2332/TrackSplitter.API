using TrackSplitter.BusinessLogic.Extensions;

namespace TrackSplitter.API.Extensions;

public static class DiExtensions
{
    extension(IServiceCollection services)
    {
        public IServiceCollection AddAppServices(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Postgres");
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentException("Couldn't find db connection string for Postgres");
            }

            services.AddBusinessLogicLayer(connectionString);

            return services;
        }
    }
}
