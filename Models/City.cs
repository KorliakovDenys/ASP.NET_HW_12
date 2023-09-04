using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP_NET_HW_12.Models {
    public class City {
        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }

        public int CountryId { get; set; }

        [ForeignKey("CountryId")]
        public virtual Country? Country { get; set; }
    }
}