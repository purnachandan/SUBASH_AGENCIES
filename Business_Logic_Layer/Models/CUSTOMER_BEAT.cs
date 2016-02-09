using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Models
{
    [Table("CUSTOMER_BEAT")]
    public class CUSTOMER_BEAT
    {
        [Key]
        public int BEATID { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string BEATNAME { get; set; }

        [Required]        
        public int OUTLET_COUNT { get; set; }

        public int? EMPLOYEEID { get; set; }

        [DataType(DataType.Date)]
        public DateTime? UPDATED_ON { get; set; }

        //public virtual List<CUSTOMER> customer { get; set; }
    }
}
