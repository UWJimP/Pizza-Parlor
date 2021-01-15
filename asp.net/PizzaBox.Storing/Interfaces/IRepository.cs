using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using PizzaBox.Domain.Abstract;

namespace PizzaBox.Storing.Interfaces
{
    public interface IRepository
    {
        public void Add<T>(T item) where T : AEntity;
        public void Remove<T>(T item) where T : AEntity;
        public T Get<T>(int id) where T : AEntity;
        public IEnumerable<AEntity> Find<T>(Expression<Func<AEntity, bool>> predicate) where T : AEntity;
        public IEnumerable<T> GetAll<T>() where T : AEntity;
        public void SaveChanges();
    }
}
