using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Food.Delivery.Store.Domain.Entities.Base;

public class BaseEntity
{
    [BsonId]
    [BsonRepresentation(BsonType.String)]
    public Guid Id { get; set; } = Guid.NewGuid();
    public bool Ativo { get; set; }
    public DateTime DataCriacao { get; set; } = DateTime.Now;
    public DateTime? DataAtualizacao { get; set; } = null;
}
