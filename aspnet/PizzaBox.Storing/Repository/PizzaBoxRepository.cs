using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using PizzaBox.Domain.Abstract;
using PizzaBox.Storing;
using PizzaBox.Storing.Interfaces;

namespace PizzaBox.Client.Repository
{
    internal class PizzaBoxRepository : IRepository
    {

        private readonly PizzaBoxContext _db;
        // public PizzaBoxRepository(DbContextOptions<PizzaBoxContext> options)
        // {
        //     _db = new PizzaBoxContext(options);
        // }
        
        public PizzaBoxRepository(PizzaBoxContext context)
        {
            _db = context;
        }
        
        public void Add<T>(T item) where T : AEntity
        {
            _db.Set<T>().Add(item);
        }
        
        public void Remove<T>(T item) where T : AEntity
        {
            _db.Set<T>().Remove(item);
        }
        
        public T Get<T>(int id) where T : AEntity
        {
            return _db.Set<T>().Find(id);
        }
        
        public IEnumerable<AEntity> Find<T>(Expression<Func<AEntity, bool>> predicate) where T : AEntity
        {
            return _db.Set<T>().Where(predicate);
        }
        
        public IEnumerable<T> GetAll<T>() where T : AEntity
        {
            return _db.Set<T>().ToList();
        }

        public void SaveChanges()
        {
            _db.SaveChanges();
        }
    }
}
