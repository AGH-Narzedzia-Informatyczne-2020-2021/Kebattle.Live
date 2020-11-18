using Kebattle.Interfaces.Generics;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Kebattle.Repositories
{
    public abstract class Repository<T> where T : class
    {
        private readonly IDbSet<T> dbset;
        private DbContext dataContext;

        protected Repository(IDatabaseFactory databaseFactory)
        {
            this.DatabaseFactory = databaseFactory;
            this.dbset = this.DataContext.Set<T>();
        }

        protected IDatabaseFactory DatabaseFactory
        {
            get;
            private set;
        }

        protected DbContext DataContext
        {
            get { return this.dataContext ?? (this.dataContext = DatabaseFactory.GetContext()); }
        }

        protected IDbSet<T> DBSet
        {
            get { return this.dbset; }
        }

        public virtual void Add(T entity)
        {
            this.dbset.Add(entity);
        }

        public virtual void Update(T entity)
        {
            this.dbset.Attach(entity);
            this.dataContext.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(T entity)
        {
            this.dbset.Remove(entity);
        }

        public virtual void Delete(Expression<Func<T, bool>> where)
        {
            IEnumerable<T> objects = this.dbset.Where<T>(where).AsEnumerable();
            foreach (T obj in objects)
            {
                this.dbset.Remove(obj);
            }
        }

        public virtual T GetById(long id)
        {
            return this.dbset.Find(id);
        }

        public virtual bool Any(Expression<Func<T, bool>> where)
        {
            return this.dbset.Any(where);
        }

        public virtual T GetById(string id)
        {
            return this.dbset.Find(id);
        }

        public virtual IQueryable<T> GetAll()
        {
            return this.dbset;
        }

        public virtual IQueryable<T> GetMany(Expression<Func<T, bool>> where)
        {
            return this.dbset.Where(where);
        }

        public T Get(Expression<Func<T, bool>> where)
        {
            return this.dbset.Where(where).FirstOrDefault<T>();
        }

        public void SaveChanges()
        {
            try
            {
                this.dataContext.SaveChanges();

            }
            catch (DbUpdateConcurrencyException e)
            {
                var entry = e.Entries.Single();
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
                throw dbEx;
            }
        }
    }
}
