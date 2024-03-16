using Flunt.Notifications;
using SecureIdentity.Password;
using ShopApi.Domain.Commands.Contracts;
using ShopApi.Domain.Commands.LoginCommand;
using ShopApi.Domain.Handlers.Contracts;
using ShopApi.Domain.Repositories;
using ShopApi.Domain.Services;

namespace ShopApi.Domain.Handlers
{
    public class LoginHandler : Notification,
    IHandler<LoginCommand>
    {
        private readonly IUsuario _repository;
        private readonly TokenService _tokenService;
        public LoginHandler(IUsuario repository, TokenService tokenService)
        {
            _repository = repository;
            _tokenService = tokenService;
        }
        public ICommandResult Handle(LoginCommand command)
        {
            command.Validate();
            if (!command.IsValid)
                return new GenericCommandResult(false, "Invalid request", command.Notifications);

            var user = _repository.GetbyLogin(command.Login);
            if (user == null)
                return new GenericCommandResult(false, "05XE101 - Invalid credentials.", user);


            if (PasswordHasher.Verify(command.Senha, user.Senha))
                return new GenericCommandResult(false, "05XE101 - Invalid credentials.", user);

            var token = _tokenService.GenerateToken(user);

            return new GenericCommandResult(true, "Login efetuado com sucesso", token);
        }


    }
}