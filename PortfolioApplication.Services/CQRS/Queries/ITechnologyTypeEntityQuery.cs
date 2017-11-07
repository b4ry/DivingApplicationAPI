﻿using PortfolioApplication.Entities.Entities;
using System.Threading.Tasks;

namespace PortfolioApplication.Services.CQRS.Queries
{
    public interface ITechnologyTypeEntityQuery
    {
        Task<TechnologyTypeEntity> Get(int id);
    }
}