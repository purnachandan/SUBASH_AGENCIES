using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Models
{
    [Table("CUSTOMERCITYPINCODE")]
    public class CITYPINCODE
    {
        [Key]
        public int PINCODEID { get; set; }
        public string PINCODE { get; set; }
    }
}
