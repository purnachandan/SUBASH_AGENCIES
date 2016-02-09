using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Business_Logic_Layer.Models;

namespace Business_Logic_Layer
{
    public class Business_Logic: DbContext
    {
        public DbSet<CUSTOMER_BEAT> Beat { get; set; }
        public DbSet<CUSTOMER_CATEGORY> Category { get; set; }
        public DbSet<CUSTOMER_CITY> City { get; set; }
        //public DbSet<CITYPINCODE> CityPinCode { get; set; }
        public DbSet<CUSTOMER_MASTER> Customer { get; set; }
        public DbSet<STATUS> Status { get; set; }
        public DbSet<CUSTOMER_TYPE> Type { get; set; }

        public Business_Logic():base("BusinessLogic")
        {
        }
    }
}
