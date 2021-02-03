using Microsoft.AspNetCore.Mvc;
using NSE.Cliente.API.Application.Commands;
using NSE.Core.Mediator;
using NSE.WebAPI.Core.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NSE.Cliente.API.Controllers
{
    public class ClientesController : MainController
    {
        private readonly IMediatorHandler _mediatorHandler;

        public ClientesController(IMediatorHandler mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
        }

        [HttpGet("clientes")]
        public async Task<IActionResult> Index()
        {
            var result = await _mediatorHandler.EnviarComando(new RegistrarClienteCommand(Guid.NewGuid(), "Daniel", "dan@niel.com", "98522102031"));

            return CustomResponse(result);
        }
    }
}