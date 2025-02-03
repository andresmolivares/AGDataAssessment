using AGData.Services.Bootstrap.Registries;

namespace AGData.Services;

public class Startup
{
    public readonly IConfiguration _configuration;
    
    public Startup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddAutoMapper(typeof(Startup));
        services.AddOptions();
        services.AddRavenDb(_configuration);
        services.AddRepositories();
        services.AddServices();

        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseDefaultFiles();
        app.UseStaticFiles();

        //Configure the HTTP request pipeline.
        if(env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        //app.UseHttpsRedirection();

        app.UseCors(builder => builder
           .AllowAnyHeader()
           .AllowAnyMethod()
           .AllowAnyOrigin()
        );

        app.UseAuthorization();

        app.UseRouting();
        app.UseAuthorization();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
            endpoints.MapFallbackToFile("index.html");
        });
    }
}
