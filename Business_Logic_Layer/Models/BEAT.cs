using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Models
{
    [Table("CUSTOMERBEAT")]
    public class BEAT
    {
        [Key]
        public int BEATID { get; set; }
        public string BEATNAME { get; set; }

        //public virtual List<CUSTOMER> customer { get; set; }
    }
}
