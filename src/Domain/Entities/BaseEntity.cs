using System;
using System.ComponentModel.DataAnnotations;
using Core.Common;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Core.Entities
{
    public abstract class BaseEntity:IEntity<string>
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; }
    }
}
