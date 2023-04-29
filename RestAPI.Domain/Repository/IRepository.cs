namespace RestAPI.Domain.Repository
{
    public interface IRepository<TEntity, TEntityId>
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> GetById(TEntityId id);
        Task<TEntity> Add(TEntity entity);
        Task<TEntity> Update(TEntity entity);
        Task<bool> Delete(TEntityId id);
    }
}
