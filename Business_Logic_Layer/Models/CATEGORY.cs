using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Models
{
    [Table("CUSTOMERCATEGORY")]
    public class CATEGORY
    {
        [Key]
        public int CATEGORYID { get; set; }
        public string CATEGORYNAME { get; set; }
    }
}
