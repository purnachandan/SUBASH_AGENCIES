using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Models
{
    public class EMPLOYEEDESIGNATION
    {
        [Key]
        public int DESIGNATIONID { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string DESIGNATIONNAME { get; set; }

        [DataType(DataType.Date)]
        public DateTime? UPDATED_ON { get; set; }
    }
}
