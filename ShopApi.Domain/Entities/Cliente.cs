using ShopApi.Domain.Enums;

namespace ShopApi.Domain.Entities
{
    public class Cliente : Entity
    {
     
        public Cliente()
        {
        }
        public Cliente(string nome, string email, string telefone, string cPF, DateTime dataNascimento, Usuario usuario) 
        {
            Nome = nome;
            Email = email;
            Telefone = telefone;
            CPF = cPF;
            DataNascimento = dataNascimento;
            Usuario = usuario;
            ETipoAcesso tipoAcesso = ETipoAcesso.Cliente;
               
        }

        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }
        public Usuario Usuario { get; set; }

        public ETipoAcesso TipoAcesso { get; set; } = ETipoAcesso.Cliente;
        public void EditarCliente(string nome, string email, string telefone, string cPF, DateTime dataNascimento)
        {
            Nome = nome;
            Email = email;
            Telefone = telefone;
            CPF = cPF;
            DataNascimento = dataNascimento;
        }

    }
}