using Microsoft.Extensions.DependencyInjection;

using TrackSplitter.DataAccess.Extensions;

namespace TrackSplitter.BusinessLogic.Extensions;

public static class DiExtensions
{
    extension(IServiceCollection services)
    {
        public IServiceCollection AddBusinessLogicLayer(string connectionString)
        {
            services.AddPostgresDb(connectionString);

            return services;
        }
    }
}
