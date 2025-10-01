using Food.Delivery.Store.Application.Dtos;
using Food.Delivery.Store.Application.Models.ApiResponse;
using Food.Delivery.Store.Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Food.Delivery.Store.Api.Controllers.v1
{
    [Route("api/clientes")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClientesController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpPost]
        public async Task<ApiResponse<int>> CriarNovoClienteAsync(ClienteDto clienteDto)
        {
            return await _clienteService.CriarClienteAsync(clienteDto);
        }
    }
}
