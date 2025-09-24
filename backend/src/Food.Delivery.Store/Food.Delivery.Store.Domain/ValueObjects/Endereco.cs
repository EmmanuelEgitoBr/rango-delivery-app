using Food.Delivery.Store.Domain.Enums;

namespace Food.Delivery.Store.Domain.ValueObjects;

public class Endereco
{
    public TipoLogradouro? TipoLogradouro { get; set; }
    public string? Logradouro { get; set; }
    public string? Numero { get; set; }
    public string? Complemento { get; set; }
    public string? Bairro { get; set; }
    public string? CEP { get; set; }
    public string? Municipio { get; set; }
    public string? Uf { get; set; }
}
