using ShopApi.Domain.Entities;

namespace ShopApi.Domain.Repositories
{
    public interface IUsuario : IBaseRepository<Usuario>
    {
        public Usuario GetbyLogin(string Login);
    }
}