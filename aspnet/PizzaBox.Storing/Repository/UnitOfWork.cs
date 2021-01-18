using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using PizzaBox.Client.Repository;
using PizzaBox.Domain.Abstract;
using PizzaBox.Domain.Models;
using PizzaBox.Storing.Interfaces;

namespace PizzaBox.Storing.Repository
{
    public class UnitOfWork : IRepository, IStoreRepository, IUserRepository, IPizzaRepository
    {
        
        private readonly PizzaBoxContext _context;
        
        private readonly StoreRepository _storeRepo;
        
        private readonly PizzaBoxRepository _pizzaBoxRepo;

        private readonly UserRepository _userRepo;

        private readonly PizzaRepository _pizzaRepo;
        
        public UnitOfWork(DbContextOptions<PizzaBoxContext> options)
        {
            _context = new PizzaBoxContext(options);
            _storeRepo = new StoreRepository(_context);
            _pizzaBoxRepo = new PizzaBoxRepository(_context);
            _userRepo = new UserRepository(_context);
            _pizzaRepo = new PizzaRepository(_context);
        }
        
        public void Add<T>(T item) where T : AEntity
        {
            _pizzaBoxRepo.Add<T>(item);
        }
        
        public IEnumerable<AEntity> Find<T>(Expression<Func<AEntity, bool>> predicate) where T : AEntity
        {
            return _pizzaBoxRepo.Find<T>(predicate);
        }
        
        public T Get<T>(int id) where T : AEntity
        {
            return _pizzaBoxRepo.Get<T>(id);
        }
        
        public IEnumerable<T> GetAll<T>() where T : AEntity
        {
            return _pizzaBoxRepo.GetAll<T>();
        }

        public T GetAPizzaPartByName<T>(string name) where T : APizzaPart
        {
            return _pizzaRepo.GetAPizzaPartByName<T>(name);
        }

        public IEnumerable<Order> GetOrderByDateRange(Store store, DateTime startDate, int days)
        {
            return _storeRepo.GetOrderByDateRange(store, startDate, days);
        }
        
        public IEnumerable<Order> GetOrdersByStore(Store store)
        {
            return _storeRepo.GetOrdersByStore(store);
        }

        public User GetUserByName(string name)
        {
            return _userRepo.GetUserByName(name);
        }

        public IEnumerable<Order> GetUserOrders(User user)
        {
            return _storeRepo.GetUserOrders(user);
        }
        
        public IEnumerable<Order> ReadStoreOrdersByUser(Store store, User user)
        {
            return _storeRepo.ReadStoreOrdersByUser(store, user);
        }
        
        public void Remove<T>(T item) where T : AEntity
        {
            _pizzaBoxRepo.Remove<T>(item);
        }
        
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
