using AGDataAssessment.Server.Persistence;
using AGDataAssessment.Server.Persistence.Interfaces;

namespace AGData.Services.Bootstrap.Registries;

public static class PersistenceRegistry
{
    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddSingleton<IDataRepository, DataRepository>();
        //Uncomment when RavenDb set up resolved
        //services.AddSingleton<IDocumentRepository, RavenDbRepository>();
        services.AddSingleton<IDocumentRepository, SimpleDbRepository>();
    }
}
