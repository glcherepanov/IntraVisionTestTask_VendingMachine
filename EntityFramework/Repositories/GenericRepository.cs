using EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityFramework.Repositories
{
    public class GenericRepository<TEntity> : IEntityRepository<TEntity> where TEntity : class, IEntity
    {
        public IQueryable<TEntity> All { get; }

        private DbSet<TEntity> Table => _vendingMachineDBContext.Set<TEntity>();
        private readonly VendingMachineDBContext _vendingMachineDBContext;

        public GenericRepository( VendingMachineDBContext vendingMachineDBContext )
        {
            _vendingMachineDBContext = vendingMachineDBContext;
            All = Table;
        }

        public TEntity GetItem(int id) => Table.Find(id);

        public TEntity Save(TEntity item)
        {
            TEntity savedEntity = item.Id == 0
                ? Table.Add(item).Entity
                : Table.Update(item).Entity;

            _vendingMachineDBContext.SaveChanges();

            return savedEntity;
        }

        public void Delete(TEntity item)
        {
            var entity = Table.Find(item);
            if (entity != null)
            {
                Table.Remove(entity);
                _vendingMachineDBContext.SaveChanges();
            }
        }

        public void Delete(IEnumerable<TEntity> items)
        {
            foreach (TEntity item in items)
            {
                var entity = Table.Find(item);
                if (entity != null)
                {
                    Table.Remove(entity);
                }
            }
            _vendingMachineDBContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = Table.Find(id);
            if (entity != null)
            {
                Table.Remove(entity);
                _vendingMachineDBContext.SaveChanges();
            }
        }
    }
}
