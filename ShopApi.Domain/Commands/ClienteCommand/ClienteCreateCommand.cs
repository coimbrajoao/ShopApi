using Flunt.Validations;
using ShopApi.Domain.Commands.Contracts;
using ShopApi.Domain.Entities;
using ShopApi.Domain.Enums;

namespace ShopApi.Domain.Commands.ClienteCommand
{
    public class ClienteCreateCommand : ICommand
    {
        public ClienteCreateCommand() { }

        public ClienteCreateCommand(string nome, string email, string telefone,
         string cPF, DateTime dataNascimento, string login, string senha, ETipoAcesso tipoAcesso)
        {
            Nome = nome;
            Email = email;
            Telefone = telefone;
            CPF = cPF;
            DataNascimento = dataNascimento;
            Login = login;
            Senha = senha;
            eTipoAcesso = tipoAcesso;
        }

        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }

        public string Login { get; set; }
        public string Senha { get; set; }
        public Usuario Usuario { get; set; }
        public ETipoAcesso eTipoAcesso { get; set; } = ETipoAcesso.Cliente;
        public override void Validate()
        {
            AddNotifications(new Contract<Cliente>()
                        .Requires()
                        .IsEmail(Email, "Email", "Por favor, insira um email válido")
                        .IsNotNullOrEmpty(Nome, "Nome", "Por favor, insira um nome válido")
                        .IsLowerThan(DataNascimento, DateTime.Now, "DataNascimento", "A data de nascimento deve ser menor que a data atual")
                        .IsTrue(CPF.Length == 11, "CPF", "Por favor, insira um CPF válido")
                        
         );
        }
    }
}