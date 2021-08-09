using Microsoft.EntityFrameworkCore;
using System;

namespace Application.Interfaces.DBContextInterfaces
{
    public interface IDbContext : IDisposable
    {
        DbContext Instance { get; }
    }
}
