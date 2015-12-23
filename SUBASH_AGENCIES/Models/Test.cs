using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SUBASH_AGENCIES.Models
{
    public class Test
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
    }
}