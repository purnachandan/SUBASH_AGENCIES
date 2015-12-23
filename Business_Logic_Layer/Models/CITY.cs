using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Models
{
    [Table("CUSTOMERCITY")]
    public class CITY
    {
        [Key]
        public int CITYID { get; set; }
        public string CITYNAME { get; set; }
    }
}
