using ShopApi.Domain.Enums;

namespace ShopApi.Domain.Entities
{
    public class Cliente : Entity
    {
        public Cliente()
        {
        }
        public Cliente(string nome, string email, string telefone, string cPF, DateTime dataNascimento,
        ETipoAcesso TipoAcesso) 
        {
            Nome = nome;
            Email = email;
            Telefone = telefone;
            CPF = cPF;
            DataNascimento = dataNascimento;
            ETipoAcesso = TipoAcesso;               
        }

        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }
        
        public ETipoAcesso ETipoAcesso { get; set; }
        public void EditarCliente(string nome, string email, string telefone)
        {
            Nome = nome;
            Email = email;
            Telefone = telefone;
        }

    }
}