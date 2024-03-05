using ShopApi.Domain.Entities;

namespace ShopApi.Domain.Repositories
{
    public interface IBaseRepository<TEntity> : IDisposable where TEntity : class
    {
        Task Adicionar(TEntity entity);
        Task AdicionarLista(IEnumerable<TEntity> entities);
        Task<TEntity> ObterPorId(Guid id );
        Task<List<TEntity>> ObterTodos();
        void Atualizar(TEntity entity);
        void AtualizarLista(IEnumerable<TEntity> entities);
        void Remover(TEntity entity);
        void RemoverLista(IEnumerable<TEntity> entities);
        Task Commit();
    }
}