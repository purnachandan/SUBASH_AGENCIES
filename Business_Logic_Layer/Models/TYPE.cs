using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Models
{
    [Table("CUSTOMERTYPE")]
    public class TYPE
    {
        [Key]
        public int TYPEID { get; set; }
        public string TYPENAME { get; set; }
    }
}
