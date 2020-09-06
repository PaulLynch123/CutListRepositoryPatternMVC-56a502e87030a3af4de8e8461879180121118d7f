using CutList.DataAccess.Data.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace CutList.DataAccess.Data.Repository
{
    //allowing me to pass models into each repository (where T : class)
    //see tutorial for details https://docs.microsoft.com/en-us/aspnet/mvc/overview/older-versions/getting-started-with-ef-5-using-mvc-4/implementing-the-repository-and-unit-of-work-patterns-in-an-asp-net-mvc-application
    public class Repository<T> : IRepository<T> where T : class
    {
        //create the context with default DBContext class
        protected readonly DbContext Context;
        //interal DBSet with the generic class inside it
        internal DbSet<T> dbSet;

        //initialise DbContext with dependency injection and initialise dbSet variable
        public Repository(DbContext context)
        {
            Context = context;
            this.dbSet = context.Set<T>();
        }

        //add by the model object
        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        //by model object id
        public T Get(int id)
        {
            //remember can't do egar loading with 'Find'
            return dbSet.Find(id);
        }

        //getAll for DataTables. 
        //using these parameters will make sure the database does the filtering etc which should be faster
        //provide lamda expression based on class type which will return boolean.
        public IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = null)
        {
            IQueryable<T> query = dbSet;
            //getAll with a filter
            if (filter != null)
            {
                query = query.Where(filter);
            }
            //--eager loading--
            if (includeProperties != null)
            {
                //remove empty entries, seperate by comma, then add each to the query one by one
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }
            //then we orderBy
            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            return query.ToList();
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> filter = null, string includeProperties = null)
        {
            IQueryable<T> query = dbSet;
            //getAll with a filter
            if (filter != null)
            {
                //if not null the put the Where clause in with the filter
                query = query.Where(filter);
            }
            //include properties (Comma seperated to allow for multiple) --eager loading--
            if (includeProperties != null)
            {
                //remove empty entries, seperate by comma, then add each to the query one by one
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }
            //return the first
            return query.FirstOrDefault();
        }

        //delete by id
        public void Remove(int id)
        {
            T entityToRemove = dbSet.Find(id);
            Remove(entityToRemove);

            //THINK ABOUT HANDLING CONCURRENCY WHERE YOU MIGHT NEED TO PASS THE WHOLE ENTITY FOR DELETING
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }
    }
}
