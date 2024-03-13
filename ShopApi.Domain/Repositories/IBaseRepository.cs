using System.Linq.Expressions;
using ShopApi.Domain.Entities;

namespace ShopApi.Domain.Repositories
{
    public interface IBaseRepository<T> where T : Entity
    {
        void Create(T entity);
        void Update(T entity);
        T GetById(Guid id,string name);
        Task<IEnumerable<T>> GetAll(string name);
        void Delete(T entity);
        bool Exists(Expression<Func<T, bool>> predicate);

                
    }
}