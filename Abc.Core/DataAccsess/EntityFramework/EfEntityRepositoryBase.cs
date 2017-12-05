using Abc.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Abc.Core.DataAccsess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext,new()
    {
        public virtual void Add(TEntity entity)
        {
            using (var db = new TContext())
            {
                var added = db.Entry(entity);
                added.State = EntityState.Added;
                db.SaveChanges();
            }
        }

        public virtual void Delete(TEntity entity)
        {
            using (var db = new TContext())
            {
                var added = db.Entry(entity);
                added.State = EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public virtual TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (var db=new TContext())
            {
                return db.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public virtual List<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var db = new TContext())
            {
                return filter == null
                    ? db.Set<TEntity>().ToList()
                    : db.Set<TEntity>().Where(filter).ToList();
            }
        }

        public virtual void Update(TEntity entity)
        {
            using (var db = new TContext())
            {
                var added = db.Entry(entity);
                added.State = EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}
