namespace RestAPI.Domain.Repository
{
    public interface IRepository<TEntity, TEntityGuid>
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(TEntityGuid guid);
        TEntity Add(TEntity entity);
        TEntity Update(TEntity entity);
        bool Delete(TEntityGuid guid);
    }
}
