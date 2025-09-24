namespace Food.Delivery.Store.Domain.Entities;

public class ItemPedido
{
    public Guid ProdutoId { get; set; }
    public int Quantidade { get; set; }
    public decimal PrecoUnitario { get; set; }
}
