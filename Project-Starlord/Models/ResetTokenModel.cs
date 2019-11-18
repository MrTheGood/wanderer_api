using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;

namespace Project_Starlord.Models
{
    public class ResetTokenModel
    {
        [Key]
        public int Id { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Token { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime Expires { get; set; }

        public bool IsTokenUsed { get; set; }
    }
}