
using System.Data.Common;
using Flunt.Validations;
using ShopApi.Domain.Commands.Contracts;
using ShopApi.Domain.Entities;


namespace ShopApi.Domain.Commands.ClienteCommand
{
    public class ClienteEditCommand : ICommand
    {
        public ClienteEditCommand()
        {
        }
        public ClienteEditCommand(Guid id ,string nome, string email, string telefone, 
        string login, string senha)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Telefone = telefone;
            Login = login;
            Senha = senha;
        }

        public Guid Id { get; set; }        
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public Usuario Usuario { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }

        public override void Validate()
        {
            AddNotifications(new Contract<Cliente>()
            .IsEmail(Email, "Email", "Por favor, insira um email válido")
            .IsNotNullOrEmpty(Nome, "Nome", "Por favor, insira um nome válido")
            .IsNotNullOrEmpty(Telefone, "Telefone", "Por favor, insira um telefone válido")            
            );
        }

    }
}