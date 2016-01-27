using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Models
{
    public class SALESMAN
    {
        public int SALESMANID { get; set; }
        public String SALESMAN_NAME { get; set; }
        public DateTime START_DATE { get; set; }
        public DateTime? END_DATE { get; set; }
        public DateTime? UPDATED_ON { get; set; }
    }
}
