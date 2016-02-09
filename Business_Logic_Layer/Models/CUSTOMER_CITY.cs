using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Models
{
    [Table("CUSTOMER_CITY")]
    public class CUSTOMER_CITY
    {
        [Key]
        public int CITYID { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string CITYNAME { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string PINCODE { get; set; }

        [DataType(DataType.Date)]
        public DateTime? UPDATED_ON { get; set; }
    }
}
