using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace bikeShopWebAPI.Models
{
    public class BikeDetail
    {
        [Key]
        public int BikeID { get; set; }

        [Required]
        [Column(TypeName ="nvarchar(100)")]
        public string BikeName { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string BikeType { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,0)")]
        public decimal BikePrice { get; set; }

        [Required]
        [Column(TypeName = "bit")]
        public bool BikeRented { get; set; }

    }
}
