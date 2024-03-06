using ShopApi.Domain.Enums;

namespace ShopApi.Domain.Entities
{
    public class Usuario : Entity
    {
        private readonly List<ETipoAcesso> _acessos;

        private Usuario( string login, string senha, bool verificado)
        {
           
            Login = login;
            Senha = senha;
            Verificado = verificado;
        }

        public Usuario(string login, string senha)
        {
            Login = login;
            Senha = senha;
            Verificado = false;
        }
        
        public string Login { get; private set; }
        public string Senha { get; private set; }
        public bool Verificado { get; private set; }
        public ETipoAcesso Acessos { get; set; }
        public void VerificarUsuario(string senha)
        {
            Senha = senha;
            Verificado = true;
        }
    }
}