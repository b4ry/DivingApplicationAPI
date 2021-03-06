﻿using PortfolioApplication.Entities.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortfolioApplication.Entities.Entities
{
    [Table("ProjectTypes")]
    public class ProjectTypeEntity : BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public ProjectTypeEnum ProjectTypeEnum { get; set; }
    }
}
