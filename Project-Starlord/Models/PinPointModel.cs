using System;
using System.ComponentModel.DataAnnotations;

namespace Project_Starlord.Models
{
    public class PinPointModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int TripId { get; set; }
        public TripModel Trip { get; set; }
        [Required]
        public decimal Longitude { get; set; }
        [Required]
        public decimal Latitude { get; set; }
        public DateTime Timestamp { get; set; }
        [Required]
        public int Sequence { get; set; }
    }
}