using AGDataAssessment.Server.Persistence;
using AGDataAssessment.Server.Persistence.Interfaces;

namespace AGData.Services.Bootstrap.Registries;

public static class PersistenceRegistry
{
    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddTransient<IDataRepository, DataRepository>();
    }
}
