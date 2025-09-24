using Food.Delivery.Store.Domain.Entities.Base;
using Food.Delivery.Store.Domain.Enums;

namespace Food.Delivery.Store.Domain.Entities;

public class Pedido : BaseEntity
{
    public Guid ClienteId { get; set; }
    public Guid RestauranteId { get; set; }
    public decimal TaxaEntrega { get; set; }
    public decimal ValorTotal { get; set; }
    public StatusPedido StatusPedido { get; set; }
    public StatusEntrega StatusEntrega { get; set; }
    public List<ItemPedido> Itens { get; set; } = new List<ItemPedido>();
}
