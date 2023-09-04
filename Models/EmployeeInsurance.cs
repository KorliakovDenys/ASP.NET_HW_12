using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP_NET_HW_12.Models {
    public class EmployeeInsurance {
        [Key]
        public int Id { get; set; }

        public int EmployeeId { get; set; }

        [ForeignKey("EmployeeId")]
        public virtual Employee? Employee { get; set; }

        public int InsuranceId { get; set; }

        [ForeignKey("InsuranceId")]
        public virtual Insurance? Insurance { get; set; }

        public DateTime ContractStartDate { get; set; }
    }
}