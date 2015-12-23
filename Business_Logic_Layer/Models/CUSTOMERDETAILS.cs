using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Models
{
    public class CUSTOMERDETAILS
    {
        public int ID { get; set; }
        public string NAME { get; set; }
        
        public string OUTLET_NAME { get; set; }
        
        public string CATEGORYNAME { get; set; }      
                
        public string TYPENAME { get; set; }
        
        public string BEATNAME { get; set; }
        
        public string ADDRESS1 { get; set; }

        public string ADDRESS2 { get; set; }

        public long? LANDLINE { get; set; }

        public long? MOBILE { get; set; }
        
        public string EMAIL_ADDRESS { get; set; }
        
        public string OTHER_DETAILS { get; set; }
        
        public string CITYNAME { get; set; }
        
        public string PINCODE { get; set; }

        public string STATUS { get; set; }        
    }
}
