using Microsoft.AspNetCore.Mvc;
using ShopApi.Domain.Commands.Contracts;
using ShopApi.Domain.Commands.LoginCommand;
using ShopApi.Domain.Handlers;

namespace ShopApi.Domain.Api.Controllers
{
    [ApiController]
    [Route("v1/Accounts")]
    public class LoginController
    {
        [HttpPost]
        [Route("v1/login")]
        public GenericCommandResult Login(
            [FromBody] LoginCommand command,
            [FromServices] LoginHandler handler
        )
        {
            return (GenericCommandResult)handler.Handle(command);
        }
    }
}