using Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Repository<TEntity> where TEntity : class
    {
        internal SchoolContext context;
        internal DbSet<TEntity> dbSet;

        public Repository(SchoolContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }

        public virtual IEnumerable<TEntity> Get()
        {
            IQueryable<TEntity> query = dbSet;
            return query.ToList();
        }

        public IQueryable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] includeExpressions)
        {
            IQueryable<TEntity> set = dbSet.AsQueryable();

            foreach (var includeExpression in includeExpressions)
            {
                set = set.Include(includeExpression);
            }
            return set;
        }

        public virtual TEntity GetByID(object id)
        {
            return dbSet.Find(id);
        }

        public IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> criteria)
        {
            return GetAll().Where(criteria);
        }

        public virtual void Insert(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public virtual void Delete(object id)
        {
            TEntity entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }

        public virtual void Delete(Expression<Func<TEntity, bool>> predicate)
        {
            IQueryable<TEntity> query = dbSet.Where(predicate).AsQueryable();
            foreach (TEntity obj in query)
            {
                dbSet.Remove(obj);
            }
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
        }

        public DbPropertyValues GetDatabaseValues(TEntity entity)
        {
            return context.Entry<TEntity>(entity).GetDatabaseValues();
        }
    }
}
