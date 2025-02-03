using Raven.Client.Documents;

namespace AGData.Services.Bootstrap.Registries;

public static class RavenDbRegistry
{
    public static void AddRavenDb(this IServiceCollection services)
    {
        // Register RavenDB Document Store
        services.AddSingleton<IDocumentStore>(sp =>
        {
            var store = new DocumentStore
            {
                Urls = new[] { "http://localhost:9000" }, // Change if needed
                Database = "DataDocumentDb"
            };
            store.Initialize();
            return store;
        });
    }
}
