using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace com.ridebookingapp.Models;

public class Feedback
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("Name")]
    public string UserName { get; set; } = null!;

    public string Feed { get; set; } = null!;

}