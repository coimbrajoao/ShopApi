using Microsoft.AspNetCore.Mvc;
using ShopApi.Domain.Commands.ClienteCommand;
using ShopApi.Domain.Commands.Contracts;
using ShopApi.Domain.Handlers;

namespace ShopApi.Domain.Api.Controllers
{
    [ApiController]
    [Route("v1/clientes")]
    public class ClienteController : ControllerBase
    {
        [HttpPost]
        [Route("cadastrar")]
        public GenericCommandResult CreateCliente(
            [FromBody] ClienteCreateCommand command,
            [FromServices] ClienteHandler handler

        )
        {
            return (GenericCommandResult)handler.Handle(command);
        }

        [HttpPut]
        [Route("atualizar")]
        public GenericCommandResult EditCliente(
            [FromBody] ClienteEditCommand command,
            [FromServices] ClienteHandler handler)
        {
            return (GenericCommandResult)handler.Handle(command);
        }

    }
}