using ShopApi.Domain.Entities;
using ShopApi.Domain.Infra.Context;
using ShopApi.Domain.Repositories;

namespace ShopApi.Domain.Infra.Repositories
{
    public class UsuarioRepository : IBaseRepository<Usuario>, IUsuario
    {
        private readonly DataContext _context;

        public UsuarioRepository(DataContext context)
        {
            _context = context;
        }
        
        public void Create(Usuario entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Usuario entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Usuario>> GetAll(string name)
        {
            throw new NotImplementedException();
        }

        public Usuario GetById(Guid id, string name)
        {
            throw new NotImplementedException();
        }

        public void Update(Usuario entity)
        {
            throw new NotImplementedException();
        }

    }
}