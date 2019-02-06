using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;
using MyBrainCategories.Domain.Entities;

namespace MyBrainCategories.Persistence.Configurations
{
    internal static class CategoryConfiguration
    {
        public static void Configure()
        {
            BsonClassMap.RegisterClassMap<Category>(m =>
            {
                m.AutoMap();
                m.MapIdProperty(c => c.Id)
                .SetIdGenerator(GuidGenerator.Instance)
                //.SetSerializer(new GuidSerializer(BsonType.ObjectId))
                .SetElementName("_id");

                m.MapProperty(x => x.Name).SetElementName("name").SetIsRequired(true);
                m.SetIgnoreExtraElements(true);
            });
        }
    }
}
