using ShopApi.Domain.Entities;
using ShopApi.Domain.Repositories;

namespace ShopApi.Domain.Test.FakeRepository;

public class FakeClienteRepository : IClienteRepository
{
    public void Create(Cliente entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(Cliente entity)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Cliente>> GetAll(string name)
    {
        throw new NotImplementedException();
    }

    public Cliente GetById(Guid id, string name)
    {
        return new Cliente("Teste", "TEste@gmail.com", "123456789", "123456789", DateTime.Now,new Usuario("teste","teste"), Enums.ETipoAcesso.Cliente);
    }

    public void Update(Cliente entity)
    {
        throw new NotImplementedException();
    }
}