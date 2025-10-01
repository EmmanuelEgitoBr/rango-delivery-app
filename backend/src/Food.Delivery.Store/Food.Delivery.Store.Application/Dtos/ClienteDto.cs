using Food.Delivery.Store.Application.Dtos.BaseDto;
using Food.Delivery.Store.Domain.ValueObjects;

namespace Food.Delivery.Store.Application.Dtos
{
    public class ClienteDto : BaseEntityDto
    {
        public string? Nome { get; set; }
        public Endereco? Endereco { get; set; }
        public Contato? Contato { get; set; }
    }
}
