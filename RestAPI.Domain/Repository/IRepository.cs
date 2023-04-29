using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestAPI.Domain.Repository
{
    internal interface IRepository<TEntity, TEntityGuid>
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(TEntityGuid guid);
        TEntity Add(TEntity entity);
        TEntity Update(TEntity entity);
        TEntity Delete(TEntityGuid guid);
    }
}
