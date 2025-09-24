using Food.Delivery.Store.Domain.Entities.Base;

namespace Food.Delivery.Store.Domain.Entities;

public class Produto : BaseEntity
{
    public string? Nome { get; set; }
    public string? Descricao { get; set; }
    public string? ImagemUrl { get; set; }
    public decimal? Preco { get; set; }
    public Guid RestauranteId { get; set; }
}
