using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP_NET_HW_12.Models {
    public class Company {
        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }

        public int CorporationId { get; set; }

        [ForeignKey("CorporationId")]
        public virtual Corporation? Corporation { get; set; }
    }
}