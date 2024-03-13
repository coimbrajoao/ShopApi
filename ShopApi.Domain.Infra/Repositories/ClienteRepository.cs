using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ShopApi.Domain.Entities;
using ShopApi.Domain.Infra.Context;
using ShopApi.Domain.Repositories;

namespace ShopApi.Domain.Infra.Repositories
{
    public class ClienteRepository : BaseRepository<Cliente>, IClienteRepository
    {
        private readonly DataContext _context;

        public ClienteRepository(DataContext context) : base(context)
        {
            _context = context;
        }
        
        public override async Task<IEnumerable<Cliente>> GetAll(string name)
        {
            return _context.Clientes.Where(x => x.Nome.Contains(name)).ToList();
        }

        public override Cliente GetById(Guid id, string name)
        {
            return _context.Clientes.FirstOrDefault(x => x.Id == id);
        }

        public override bool Exists(Expression<Func<Cliente, bool>> predicate)
        {
            return _context.Clientes.Any(predicate);
        }
        
    }
}