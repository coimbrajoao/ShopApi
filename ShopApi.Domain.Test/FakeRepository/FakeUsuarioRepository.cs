using System.Linq.Expressions;
using ShopApi.Domain.Entities;
using ShopApi.Domain.Repositories;

namespace ShopApi.Domain.Test.FakeRepository
{
    public class FakeUsuarioRepository : IBaseRepository<Usuario>
    {
        public void Create(Usuario entity)
        {
            
        }

        public void Delete(Usuario entity)
        {
            throw new NotImplementedException();
        }

        public bool Exists(Expression<Func<Usuario, bool>> predicate)
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
            
        }

    }
}