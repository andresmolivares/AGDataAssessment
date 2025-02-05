using AGData.Services.Services;
using AGData.Services.Services.Interfaces;

namespace AGData.Services.Bootstrap.Registries;

public static class ServiceRegistry
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddTransient<IDataService, DataService>();
        services.AddScoped<IDocumentService, DocumentService>();
    }
}
