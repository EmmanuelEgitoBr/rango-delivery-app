using AutoMapper;
using Food.Delivery.Store.Application.Dtos;
using Food.Delivery.Store.Application.Models.ApiResponse;
using Food.Delivery.Store.Application.Services.Interfaces;
using Food.Delivery.Store.Domain.Contracts.Base;
using Food.Delivery.Store.Domain.Entities;

namespace Food.Delivery.Store.Application.Services;

public class ClienteService : IClienteService
{
    private readonly IBaseRepository<Cliente> _clienteRepository;
    private readonly IMapper _mapper;

    public ClienteService(IBaseRepository<Cliente> clienteRepository,
        IMapper mapper)
    {
        _clienteRepository = clienteRepository;
        _mapper = mapper;
    }

    public async Task<ApiResponse<int>> CriarClienteAsync(ClienteDto clienteDto)
    {
        try
        {
            var clienteEntity = _mapper.Map<Cliente>(clienteDto);

            await _clienteRepository.InsertAsync(clienteEntity);
            
            return new ApiResponse<int>
            {
                Success = true,
                Content = 1
            };
        }
        catch(Exception ex)
        {
            return new ApiResponse<int>
            {
                Success = false,
                Error = ex.Message
            };
        }
    }
}
