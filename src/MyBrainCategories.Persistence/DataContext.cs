using MongoDB.Driver;
using MyBrainCategories.Domain.Entities;

namespace MyBrainCategories.Persistence
{
    public class DataContext
    {
        private IMongoDatabase _db;

        public DataContext(MongoSettings mongoSettings)
        {
            var client = new MongoClient(mongoSettings.ConnectionString());
            _db = client.GetDatabase(mongoSettings.Database);
        }

        public IMongoCollection<Category> Categories => _db.GetCollection<Category>("categories");
    }
}
