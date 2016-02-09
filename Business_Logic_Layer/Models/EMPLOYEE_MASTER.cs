using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Models
{
    public class EMPLOYEE_MASTER
    {
        [Key]
        public int EMPLOYEEID { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public String EMPLOYEE_NAME { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime START_DATE { get; set; }

        [DataType(DataType.Date)]
        public DateTime? END_DATE { get; set; }

        [Required]
        public int DESIGNATIONID { get; set; }

        [Required]
        [Range(1000,99999,ErrorMessage ="Salary should be minimum 1000 and maximum 99999")]
        [DataType(DataType.Currency)]
        public int SALARY { get; set; }

        [Required]
        [DefaultValue(1)]
        public short STATUSID { get; set; }

        [DataType(DataType.Date)]
        public DateTime? UPDATED_ON { get; set; }
    }
}
