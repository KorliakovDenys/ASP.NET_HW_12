using System.ComponentModel.DataAnnotations;

namespace ASP_NET_HW_12.Models {
    public class Insurance {
        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }

        public decimal PayoutAmount { get; set; }
    }
}