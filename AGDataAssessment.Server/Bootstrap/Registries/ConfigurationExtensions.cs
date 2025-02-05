namespace AGData.Services.Bootstrap.Registries;

public static class ConfigurationExtensions
{
    public static TSettings GetSettings<TSettings>(this IConfiguration configuration, string sectionName)
        where TSettings : class, new()
    {
        var configSection = configuration.GetSection(sectionName);
        if(configSection == null) throw new ArgumentNullException(nameof(configSection));

        var config = new TSettings();
        configSection.Bind(config);
        return config;
    }
}
