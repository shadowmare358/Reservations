using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TestApp.Models
{
    public class Reservation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(10)]
        public string ReservationCode { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public DateTime CheckInDate { get; set; }
        [Required]
        public DateTime CheckOutDate { get; set; }
        [Required]
        public string Currency { get; set; }
        public decimal Fee { get; set; }
        public string Source { get; set; }
        public ICollection<Guest> Guests { get; set; }

    }
}