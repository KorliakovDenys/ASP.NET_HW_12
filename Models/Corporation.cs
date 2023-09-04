using System.ComponentModel.DataAnnotations;

namespace ASP_NET_HW_12.Models {
    public class Corporation {
        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }

        public virtual ICollection<Company>? Companies { get; set; }
    }
}