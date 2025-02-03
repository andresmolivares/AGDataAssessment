using AGDataAssessment.Server.Bootstrap.Settings;
using Raven.Client.Documents;
using System.Security.Cryptography.X509Certificates;

namespace AGData.Services.Bootstrap.Registries;

public static class RavenDbRegistry
{
    public static void AddRavenDb(this IServiceCollection services, IConfiguration configuration)
    {
        var settings = configuration.GetSettings<RavenDbSettings>("RavenDb");
        if(settings is null)
            throw new ArgumentNullException(nameof(settings), "Requires settings for RavenDb connection.");

        // Register RavenDB Document Store
        services.AddSingleton<IDocumentStore>(sp =>
        {
            var store = new DocumentStore
            {
                Certificate = new X509Certificate2(settings.ClientCertificatePath),
                Urls = new[] { settings.StoreUrl },
                Database = settings.DatabaseName
            };
            store.Initialize();
            return store;
        });
    }
}
