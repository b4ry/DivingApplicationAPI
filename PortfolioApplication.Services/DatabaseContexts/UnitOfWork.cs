﻿using System.Threading.Tasks;

namespace PortfolioApplication.Services.DatabaseContexts
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PortfolioApplicationDbContext _databaseContext;

        public UnitOfWork(PortfolioApplicationDbContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public void Save()
        {
            _databaseContext.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await _databaseContext.SaveChangesAsync();
        }
    }
}