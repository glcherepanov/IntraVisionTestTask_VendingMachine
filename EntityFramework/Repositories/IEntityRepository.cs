using EntityFramework.Entities;
using System.Collections.Generic;
using System.Linq;

namespace EntityFramework.Repositories
{
    public interface IEntityRepository<TEntity> where TEntity : IEntity  
    {
        IQueryable<TEntity> All { get; }
        TEntity GetItem(int id);
        TEntity Save(TEntity item);
        void Delete(TEntity item);
        void Delete(IEnumerable<TEntity> item);
        void Delete(int id);
    }
}
