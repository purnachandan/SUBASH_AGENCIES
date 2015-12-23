using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Models
{
    [Table("CUSTOMERSTATUS")]
    public class STATUS
    {
        [Key]
        public int STATUSID { get; set; }
        public string STATUSCODE { get; set; }
    }
}
