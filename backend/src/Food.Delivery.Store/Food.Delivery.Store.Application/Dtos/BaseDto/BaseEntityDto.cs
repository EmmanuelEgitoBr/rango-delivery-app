namespace Food.Delivery.Store.Application.Dtos.BaseDto;

public class BaseEntityDto
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public bool Ativo { get; set; }
    public DateTime DataCriacao { get; set; } = DateTime.Now;
    public DateTime? DataAtualizacao { get; set; } = null;
}
