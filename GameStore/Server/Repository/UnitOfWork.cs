using GameStore.Server.Data;
using GameStore.Server.IRepository;
using GameStore.Server.Models;
using GameStore.Shared.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GameStore.Server.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private IGenericRepository<Title> _Titles;
        private IGenericRepository<Genre> _Genres;
        private IGenericRepository<Developer> _Developers;
        private IGenericRepository<Platform> _Platform;
        private IGenericRepository<Order> _Orders;
        private IGenericRepository<Customer> _customers;
        private IGenericRepository<Game> _Games;
        private IGenericRepository<Review> _Reviews;

        private UserManager<ApplicationUser> _userManager;

        public UnitOfWork(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IGenericRepository<Title> Titles
            => _Titles ??= new GenericRepository<Title>(_context);
        public IGenericRepository<Genre> Genres
            => _Genres ??= new GenericRepository<Genre>(_context);
        public IGenericRepository<Developer> Developers
            => _Developers ??= new GenericRepository<Developer>(_context);
        public IGenericRepository<Platform> Platforms
            => _Platform ??= new GenericRepository<Platform>(_context);
        public IGenericRepository<Game> Games
            => _Games ??= new GenericRepository<Game>(_context);
        public IGenericRepository<Order> Orders
            => _Orders ??= new GenericRepository<Order>(_context);
        public IGenericRepository<Customer> Customers
            => _customers ??= new GenericRepository<Customer>(_context);
        public IGenericRepository<Review> Reviews
            => _Reviews ??= new GenericRepository<Review>(_context);

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save(HttpContext httpContext)
        {
            //To be implemented
            string user = "System";

            var entries = _context.ChangeTracker.Entries()
                .Where(q => q.State == EntityState.Modified ||
                    q.State == EntityState.Added);

            foreach (var entry in entries)
            {
                ((BaseDomainModel)entry.Entity).DateUpdated = DateTime.Now;
                ((BaseDomainModel)entry.Entity).UpdatedBy = user;
                if (entry.State == EntityState.Added)
                {
                    ((BaseDomainModel)entry.Entity).DateCreated = DateTime.Now;
                    ((BaseDomainModel)entry.Entity).CreatedBy = user;
                }
            }

            await _context.SaveChangesAsync();
        }
    }
}