﻿using DivingApplicationAPI.Entity;
using System.ComponentModel.DataAnnotations;

namespace DivingApplicationAPI.DataTransferObjects
{
    public class AccountSummaryDto
    {
        [Required]
        public string AccountNumber { get; set; }
        [Required]
        public AccountTypeEnum Type { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public double Balance { get; set; }
    }
}
