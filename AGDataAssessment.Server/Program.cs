using AGData.Services;

namespace AGDataAssessment.Server
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            await Host
                .CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                .Build()
                .RunAsync();
        }
    }
}
