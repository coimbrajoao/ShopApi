using Flunt.Validations;
using ShopApi.Domain.Commands.Contracts;
using ShopApi.Domain.Entities;
using ShopApi.Domain.Enums;

namespace ShopApi.Domain.Commands.LoginCommand
{
    public class LoginCommand : ICommand
    {

        public LoginCommand() { }

        public LoginCommand(string login, string senha)
        {
            login = Login;
            senha = Senha;
        }
        public string Login { get; set; }
        public string Senha { get; set; }

        public override void Validate()
        {
            AddNotifications(new Contract<Usuario>()
                            .Requires()
                            .IsNotNullOrEmpty(Login, "Login", "Por favor, insira um login")
                            .IsNotNullOrEmpty(Senha, "Senha", "Por favor, insira uma senha")
            );
        }

    }
}