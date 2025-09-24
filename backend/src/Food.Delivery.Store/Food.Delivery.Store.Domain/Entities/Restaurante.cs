using Food.Delivery.Store.Domain.Entities.Base;
using Food.Delivery.Store.Domain.Enums;
using Food.Delivery.Store.Domain.ValueObjects;

namespace Food.Delivery.Store.Domain.Entities;

public class Restaurante : BaseEntity
{
    public string? Nome { get; set; }
    public string? Descricao { get; set; }
    public string? LogoUrl { get; set; }
    public Endereco? Endereco { get; set; }
    public Contato? Contato { get; set; }
    public Categoria? Categoria { get; set; }
    public HorarioFuncionamento HorarioFuncionamento { get; set; } = new();
    public ICollection<OpcaoPagamento> OpcoesPagamentoOnline { get; set; } = [];
    public ICollection<OpcaoPagamento> OpcoesPagamentoNoLocal { get; set; } = [];
    public ICollection<Produto> Produtos { get; set; } = [];
}
