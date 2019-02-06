using Microsoft.Extensions.DependencyInjection;
using MyBrainCategories.Persistence.Configurations;

namespace MyBrainCategories.Persistence.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddMongoDbContext(this IServiceCollection service, string server, string database, int? port = null)
        {
            service.AddSingleton<MongoSettings>(new MongoSettings
            {
                ServerUrl = server,
                Database = database,
                Port = port
            });
            service.AddScoped<DataContext>();

            CategoryConfiguration.Configure();
        }
    }
}
