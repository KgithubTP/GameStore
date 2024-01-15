using GameStore.Shared.Domain;
using GameStore.Server.IRepository;
using GameStore.Shared.Domain;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.Server.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        Task Save(HttpContext httpContext);
        IGenericRepository<Title> Titles { get; }
        IGenericRepository<Genre> Genres { get; }
        IGenericRepository<Game> Games { get; }
        IGenericRepository<Developer> Developers { get; }
        IGenericRepository<Platform> Platforms { get; }
        IGenericRepository<Order> Orders { get; }
        IGenericRepository<Customer> Customers { get; }
    }
}