using System.Linq.Expressions;
using ShopApi.Domain.Entities;
using ShopApi.Domain.Repositories;

namespace ShopApi.Domain.Test.FakeRepository;

public class FakeClienteRepository : IBaseRepository<Cliente>
{
    public void Create(Cliente entity)
    {
        
    }

    public void Delete(Cliente entity)
    {
        throw new NotImplementedException();
    }

    public bool Exists(Expression<Func<Cliente, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Cliente>> GetAll(string name)
    {
        throw new NotImplementedException();
    }

    public Cliente GetById(Guid id, string name)
    {
        return new Cliente("Teste", "TEste@gmail.com", "123456789", "123456789", DateTime.Now, Enums.ETipoAcesso.Cliente);
    }

    public void Update(Cliente entity)
    {
        throw new NotImplementedException();
    }
}