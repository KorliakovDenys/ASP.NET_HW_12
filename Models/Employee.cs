using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP_NET_HW_12.Models {
    public class Employee {
        [Key]
        public int Id { get; set; }

        public string? FullName { get; set; }

        public int CompanyId { get; set; }

        [ForeignKey("CompanyId")]
        public virtual Company? Company { get; set; }

        public string? Position { get; set; }

        public decimal Salary { get; set; }

        public virtual ICollection<EmployeeInsurance>? Insurances { get; set; }
    }
}