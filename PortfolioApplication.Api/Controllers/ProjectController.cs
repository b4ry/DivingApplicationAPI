﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortfolioApplication.Api.CQRS.Queries;
using PortfolioApplication.Api.DataTransferObjects.Project;
using PortfolioApplication.Entities.Entities;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Threading.Tasks;

namespace PortfolioApplication.Api.Controllers
{
    /// <summary>
    /// Controller processing requests for Project entities. Produces JSON output.
    /// </summary>
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class ProjectController : Controller
    {
        private readonly IProjectQuery _projectQuery;

        /// <summary>
        /// ProjectController constructor
        /// </summary>
        /// <param name="projectQuery"> Query consumed to retrieve Project entities </param>
        public ProjectController(
            IProjectQuery projectQuery)
        {
            _projectQuery = projectQuery;
        }

        /// <summary>
        /// GET endpoint retrieving Project entity by its id
        /// </summary>
        /// <param name="id"> Identification number of Project entity. <br>Constraints:</br>- must be bigger than 0</param>
        /// <returns> Project entity in JSON format </returns>
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(ProjectDto))]
        [SwaggerResponse((int)HttpStatusCode.NotFound, Type = typeof(NotFoundObjectResult))]
        [HttpGet("{id:int:min(1)}")]
        public async Task<IActionResult> GetProjectById([Required]int id)
        {
            Func<DbSet<ProjectEntity>, Task<ProjectEntity>> retrivalFunc =
                dbSet => dbSet
                .Include(proj => proj.ProjectType)
                .Include(proj => proj.Technologies)
                .ThenInclude(techs => techs.Technology)
                .ThenInclude(tech => tech.TechnologyType)
                .SingleAsync(proj => proj.Id == id);

            var experienceDto = await _projectQuery.Get(id, retrivalFunc);

            return new JsonResult(experienceDto);
        }

        /// <summary>
        /// GET endpoint retrieving all Project entities
        /// </summary>
        /// <returns> Project entity collection in JSON format </returns>
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(IList<ProjectDto>))]
        [SwaggerResponse((int)HttpStatusCode.NoContent)]
        [HttpGet]
        public async Task<IActionResult> GetProjects()
        {
            Func<DbSet<ProjectEntity>, Task<List<ProjectEntity>>> retrivalFunc =
                dbSet => dbSet
                .Include(proj => proj.ProjectType)
                .Include(proj => proj.Technologies)
                .ThenInclude(techs => techs.Technology)
                .ThenInclude(tech => tech.TechnologyType)
                .ToListAsync();

            var experienceDtos = await _projectQuery.Get(retrivalFunc);

            return new JsonResult(experienceDtos);
        }
    }
}
