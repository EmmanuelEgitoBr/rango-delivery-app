using Food.Delivery.Store.Domain.Entities.Base;
using Food.Delivery.Store.Domain.ValueObjects;

namespace Food.Delivery.Store.Domain.Entities;

public class Cliente : BaseEntity
{
    public string? Nome { get; set; }
    public Endereco? Endereco { get; set; }
    public Contato? Contato { get; set; }
}
