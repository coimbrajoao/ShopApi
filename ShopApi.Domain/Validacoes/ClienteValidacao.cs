using System.Diagnostics.Contracts;
using Flunt.Notifications;
using Flunt.Validations;

namespace ShopApi.Domain.Validacoes
{
    public static class ClienteValidacao
    {
        public const int EmailMaxLength = 100;
        public const int NomeMaxLength = 100;
        public const int TelefoneMaxLength = 20;
        public const int CpfMaxLength = 11;
        public static Contract<Notification> Validacao(string nome, string telefone, string cpf, string email){
            return new Contract<Notification>()
                .Requires()
                .IsLowerOrEqualsThan(nome, NomeMaxLength, "Nome")
                .IsLowerOrEqualsThan(telefone, TelefoneMaxLength, "Telefone")
                .IsLowerOrEqualsThan(email, EmailMaxLength, "Email")
                .IsEmailOrEmpty(email, "Email")
                .AreEquals(cpf, CpfMaxLength, "Cpf");    
        }
    }
}