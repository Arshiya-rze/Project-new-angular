using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace api.Models;

public record AppUser
(
    [property: BsonId, BsonRepresentation(BsonType.ObjectId)] string? Id,
    string Email,
    string PassWord,
    string ConfirmPassword
);

        

