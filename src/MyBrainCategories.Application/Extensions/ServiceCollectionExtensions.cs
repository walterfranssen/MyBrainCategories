using Microsoft.Extensions.DependencyInjection;
using MyBrainCategories.Persistence.Extensions;

namespace MyBrainCategories.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplication(this IServiceCollection service, string server, string database, int? port = null)
        {
            service.AddMongoDbContext(server, database, port);
        }
    }
}
