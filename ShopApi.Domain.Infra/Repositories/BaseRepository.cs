using Microsoft.EntityFrameworkCore;
using ShopApi.Domain.Entities;
using ShopApi.Domain.Infra.Context;
using ShopApi.Domain.Repositories;

namespace ShopApi.Domain.Infra.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : Entity
    {
        private readonly DataContext _context;
        
        public BaseRepository(DataContext context)
        {
            _context = context;
        }
        public void Create(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }


        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public virtual Task<IEnumerable<T>> GetAll(string name)
        {
           throw new NotImplementedException();
        }

        public virtual Task<T> GetById(Guid id, string name)
        {
            throw new NotImplementedException();
        }

    }
}