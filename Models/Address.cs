using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP_NET_HW_12.Models {
    public class Address {
        [Key]
        public int Id { get; set; }

        public string? StreetName { get; set; }

        public string? BuildingNumber { get; set; }

        public int CityId { get; set; }

        [ForeignKey("CityId")]
        public virtual City? City { get; set; }
    }
}