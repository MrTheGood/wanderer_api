using System;
using System.ComponentModel.DataAnnotations;

namespace Project_Starlord.Models
{
    public class TripModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string TripName { get; set; }
        public DateTime TimestampFrom { get; set; }
        public DateTime TimestampTo { get; set; }
        [Required]
        public int UserId { get; set; }
        public UserModel User { get; set; }
    }
}