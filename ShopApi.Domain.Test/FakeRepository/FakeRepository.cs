using ShopApi.Domain.Entities;
using ShopApi.Domain.Repositories;

namespace ShopApi.Domain.Test.FakeRepository;

public class FakeClienteRepository : IClienteRepository
{
    private readonly List<Cliente> _clientes;

    public FakeClienteRepository()
    {
        // Inicializar uma lista vazia de clientes
        _clientes = new List<Cliente>();
    }
    public Task Adicionar(Cliente entity)
    {
        // Adicionar o cliente à lista
        _clientes.Add(entity);
        return Task.CompletedTask;
    }

    public Task AdicionarLista(IEnumerable<Cliente> entities)
    {
        throw new NotImplementedException();
    }

    public void Atualizar(Cliente entity)
    {
        throw new NotImplementedException();
    }

    public void AtualizarLista(IEnumerable<Cliente> entities)
    {
        throw new NotImplementedException();
    }

    public Task Commit()
    {
        throw new NotImplementedException();
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }

    public Task<Cliente> ObterPorId(Guid id)
    {
        // Procurar o cliente na lista pelo ID
        var cliente = _clientes.Find(c => c.Id == id );
        return Task.FromResult(cliente);
    }

    public Task<List<Cliente>> ObterTodos()
    {
        throw new NotImplementedException();
    }

    public void Remover(Cliente entity)
    {
        throw new NotImplementedException();
    }

    public void RemoverLista(IEnumerable<Cliente> entities)
    {
        throw new NotImplementedException();
    }
}