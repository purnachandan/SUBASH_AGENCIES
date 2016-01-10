using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Models
{
    [Table("CUSTOMER_MASTER")]
    public class CUSTOMER
    {
        [Key]
        public int ID { get; set; }

        [Display(Name ="Customer Name")]
        public string CUSTOMER_NAME { get; set; }

        [Required]
        [Display(Name = "Outlet Name")]
        public string OUTLET_NAME { get; set; }

        [Display(Name = "Category")]
        public int CATEGORYID { get; set; }
        //public virtual List<CATEGORY> Category { get; set; }

        [Display(Name = "Type")]
        public int TYPEID { get; set; }
        //public virtual List<TYPE> Type { get; set; }

        [Display(Name = "Beat")]
        public int BEATID { get; set; }
        //public virtual List<BEAT> Beat { get; set; }

        [Display(Name = "Address1")]
        public string ADDRESS1 { get; set; }

        [Display(Name = "Address2")]
        public string ADDRESS2 { get; set; }
        
        [Display(Name = "LandLine")]
        public string LANDLINE { get; set; }
        
        [Display(Name = "Mobile")]
        [DataType(DataType.PhoneNumber)]
        public string MOBILE { get; set; }

        [Display(Name = "EmailAddress")]
        [DataType(DataType.EmailAddress,ErrorMessage ="Please provide valid Email Address")]
        public string EMAIL_ADDRESS { get; set; }

        [Display(Name = "Other Details")]
        public string OTHER_DETAILS { get; set; }

        [Display(Name = "City")]
        public int CITYID { get; set; }
        //public virtual List<CITY> City { get; set; }
             
        //[Display(Name = "Pincode")]
        //public int PINCODEID { get; set; }
        //public virtual List<CITYPINCODE> PinCode { get; set; }

        [Display(Name = "Status")]
        public int STATUSID { get; set; }
        //public virtual List<STATUS> Status { get; set;}
    }
}
