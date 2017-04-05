using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Model
{
    public class Category
    {
        public ObjectId Id { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }
    }
}
