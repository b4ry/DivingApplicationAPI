﻿using PortfolioApplication.Api.DataTransferObjects.Projects;
using System.Collections.Generic;

namespace PortfolioApplication.Api.DataTransferObjects.Experiences
{
    /// <summary>
    /// Data transfer object for Experience entity
    /// </summary>
    public class ExperienceDto : BaseDto
    {
        /// <summary>
        /// Name of the company
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// Position name
        /// </summary>
        public string Position { get; set; }

        /// <summary>
        /// Associated entites
        /// </summary>
        public IList<ProjectDto> Projects { get; set; }
    }
}
