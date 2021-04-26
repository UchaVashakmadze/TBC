﻿using System;
using System.Threading;
using System.Threading.Tasks;

namespace Common.Domain.SeedWork
{
    public interface IGenericUnitOfWork : IDisposable 
    {
        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
