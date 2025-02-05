using AGDataAssessment.Server.Bootstrap.Settings;

namespace AGData.Services.Bootstrap.Registries;

public static class SettingsRegistry
{
    public static IServiceCollection AddConfigSections(this IServiceCollection services, IConfiguration configuration)
    {
        return services.ConfigureSettings<RavenDbSettings>(configuration, "RavenDb");
    }

    private static IServiceCollection ConfigureSettings<TSettings>(this IServiceCollection services, IConfiguration configuration, string sectionName)
        where TSettings : class, new()
    {
        if(services == null) throw new ArgumentNullException(nameof(services));
        if(configuration == null) throw new ArgumentNullException(nameof(configuration));

        return services.AddSingleton(configuration.GetSettings<TSettings>(sectionName));
    }
}
