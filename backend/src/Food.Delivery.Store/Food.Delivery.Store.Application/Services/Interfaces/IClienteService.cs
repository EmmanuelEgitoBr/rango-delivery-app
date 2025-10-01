using Food.Delivery.Store.Application.Dtos;
using Food.Delivery.Store.Application.Models.ApiResponse;

namespace Food.Delivery.Store.Application.Services.Interfaces;

public interface IClienteService
{
    Task<ApiResponse<int>> CriarClienteAsync(ClienteDto clienteDto);
}
