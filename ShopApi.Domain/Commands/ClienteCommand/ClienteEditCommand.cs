
using System.Data.Common;
using ShopApi.Domain.Commands.Contracts;
using ShopApi.Domain.Entities;
using ShopApi.Domain.Validacoes;

namespace ShopApi.Domain.Commands.ClienteCommand
{
    public class ClienteEditCommand : ICommand
    {
        public ClienteEditCommand()
        {
        }
        public ClienteEditCommand(Guid id ,string nome, string email, string telefone, string cPF, DateTime dataNascimento,
        string login, string senha)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Telefone = telefone;
            CPF = cPF;
            DataNascimento = dataNascimento;
            Login = login;
            Senha = senha;
        }

        public Guid Id { get; set; }        
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }
        public Usuario Usuario { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }

        public override void Validate()
        {
            AddNotifications(ClienteValidacao.Validacao(Nome, Telefone, CPF, Email));
        }

    }
}