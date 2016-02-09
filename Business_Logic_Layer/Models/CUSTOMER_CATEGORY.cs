using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Models
{
    [Table("CUSTOMER_CATEGORY")]
    public class CUSTOMER_CATEGORY
    {
        [Key]
        public int CATEGORYID { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string CATEGORYNAME { get; set; }

        [DataType(DataType.Date)]
        public DateTime? UPDATED_ON { get; set; }
    }
}
