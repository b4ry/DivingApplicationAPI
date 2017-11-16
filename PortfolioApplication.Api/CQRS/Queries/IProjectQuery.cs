﻿using Microsoft.EntityFrameworkCore;
using PortfolioApplication.Api.DataTransferObjects.Project;
using PortfolioApplication.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PortfolioApplication.Api.CQRS.Queries
{
    public interface IProjectQuery
    {
        Task<ProjectDto> Get(int id, Func<DbSet<ProjectEntity>, Task<ProjectEntity>> retrievalFunc);
        Task<IList<ProjectDto>> Get(Func<DbSet<ProjectEntity>, Task<List<ProjectEntity>>> retrievalFunc);
    }
}
