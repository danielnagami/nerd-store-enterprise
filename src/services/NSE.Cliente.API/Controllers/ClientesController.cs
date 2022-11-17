using Microsoft.AspNetCore.Mvc;
using NSE.Cliente.API.Application.Commands;
using NSE.Cliente.API.Models;
using NSE.Core.Mediator;
using NSE.WebAPI.Core.Controllers;
using NSE.WebAPI.Core.Usuario;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NSE.Cliente.API.Controllers
{
    public class ClientesController : MainController
    {
        private readonly IMediatorHandler _mediator;
        private readonly IClienteRepository _clienteRepository;
        private readonly IAspNetUser _user;

        public ClientesController(IMediatorHandler mediatorHandler, IClienteRepository clienteRepository, IAspNetUser user)
        {
            _mediator = mediatorHandler;
            _clienteRepository = clienteRepository;
            _user = user;
        }

        [HttpGet("clientes")]
        public async Task<IActionResult> Index()
        {
            var result = await _mediator.EnviarComando(new RegistrarClienteCommand(Guid.NewGuid(), "Daniel", "dan@niel.com", "98522102032"));

            return CustomResponse(result);
        }

        [HttpGet("cliente/endereco")]
        public async Task<IActionResult> ObterEndereco()
        {
            var endereco = await _clienteRepository.ObterEnderecoPorId(_user.ObterUserId());

            return endereco == null ? NotFound() : CustomResponse(endereco);
        }

        [HttpPost("cliente/endereco")]
        public async Task<IActionResult> AdicionarEndereco(AdicionarEnderecoCommand endereco)
        {
            endereco.ClienteId = _user.ObterUserId();
            return CustomResponse(await _mediator.EnviarComando(endereco));
        }
    }
}