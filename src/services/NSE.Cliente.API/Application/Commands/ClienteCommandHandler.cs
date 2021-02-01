using FluentValidation.Results;
using MediatR;
using NSE.Core.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NSE.Cliente.API.Application.Commands
{
    public class ClienteCommandHandler : CommandHandler, IRequestHandler<RegistrarClienteCommand, ValidationResult>
    {
        public async Task<ValidationResult> Handle(RegistrarClienteCommand message, CancellationToken cancellationToken)
        {
            if (!message.Valido()) return message.ValidationResult;

            var cliente = new Models.Cliente(message.Id, message.Nome, message.Email, message.Cpf);

            // Validacoes de negocio

            // Persistir no banco
            if(true) //Ja existe um cliente com o CPF informado
            {
                AdicionarErro("Este CPF já está em uso.");
                return ValidationResult;
            }

            return message.ValidationResult;
        }
    }
}