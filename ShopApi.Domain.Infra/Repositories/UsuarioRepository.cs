using ShopApi.Domain.Entities;
using ShopApi.Domain.Infra.Context;
using ShopApi.Domain.Repositories;

namespace ShopApi.Domain.Infra.Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuario
    {
        private readonly DataContext _context;

        public UsuarioRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public Usuario GetbyLogin(string login)
        {
            return _context.Usuarios.FirstOrDefault(x => x.Login == login);
        }
         
    }
}