using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business_Logic_Layer.Models;
using System.Data;

namespace Business_Logic_Layer
{
    public class Queries
    {
        
        public List<CUSTOMERDETAILS> GetOutlets(string sOutletName)
        {
            List<CUSTOMERDETAILS> csd = new List<CUSTOMERDETAILS>();
            string cmdText = "SELECT  cust.NAME, cust.OUTLET_NAME, " +
                             "cate.CATEGORYNAME, typ.TYPENAME, beat.BEATNAME, " +
                             "cust.ADDRESS1,cust.ADDRESS2, cust.LANDLINE, cust.MOBILE, " +
                             "cust.EMAIL_ADDRESS, cust.OTHER_DETAILS,city.CITYNAME, " +
                             "pin.PINCODE, stat.STATUSCODE, cust.ID " +
                             "FROM CUSTOMER_MASTER cust " +
                             "INNER JOIN CUSTOMERCATEGORY cate on cust.CATEGORYID = cate.CATEGORYID " +
                             "INNER JOIN CUSTOMERTYPE typ on cust.TYPEID = typ.TYPEID " +
                             "INNER JOIN CUSTOMERBEAT beat on cust.BEATID = beat.BEATID " +
                             "INNER JOIN CUSTOMERCITY city on cust.CITYID = city.CITYID " +
                             "INNER JOIN CUSTOMERCITYPINCODE pin on cust.PINCODEID = pin.PINCODEID " +
                             "INNER JOIN CUSTOMERSTATUS stat on cust.STATUSID = stat.STATUSID " +
                             "WHERE cust.OUTLET_NAME LIKE '%" + sOutletName + "%'";
            try
            {
                using (SqlConnection con = new SqlConnection(@"Data Source = PC\SQLEXPRESS; Initial Catalog = SUBASHAGENCIES; Integrated Security = True"))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(cmdText, con))
                    {
                        SqlDataReader sdr;
                        sdr = cmd.ExecuteReader();
                        while (sdr.Read())
                        {
                            csd.Add(new CUSTOMERDETAILS
                            {
                                ID = sdr.GetInt32(14),
                                NAME = sdr.GetValue(0).ToString(),
                                OUTLET_NAME = sdr.GetValue(1).ToString(),
                                CATEGORYNAME = sdr.GetValue(2).ToString(),
                                TYPENAME = sdr.GetValue(3).ToString(),
                                BEATNAME = sdr.GetValue(4).ToString(),
                                ADDRESS1 = sdr.GetValue(5).ToString(),
                                ADDRESS2 = sdr.GetValue(6).ToString(),
                                LANDLINE = sdr.IsDBNull(7) ? default(long?) : sdr.GetInt64(7),
                                MOBILE = sdr.IsDBNull(8) ? default(long?) : sdr.GetInt64(8),
                                EMAIL_ADDRESS = sdr.GetValue(9).ToString(),
                                OTHER_DETAILS = sdr.GetValue(10).ToString(),
                                CITYNAME = sdr.GetValue(11).ToString(),
                                PINCODE = sdr.GetValue(12).ToString(),
                                STATUS = sdr.GetValue(13).ToString(),
                            });
                        }
                        return csd; 
                    }
                }
            }
            catch(Exception ex)
            {
                return null;
            }
        }
        public CUSTOMER GetCustomer(int OutletId)
        {
            CUSTOMER cust = new CUSTOMER();
            string cmdText = "SELECT ID, NAME, OUTLET_NAME, " +
                             "CATEGORYID, TYPEID, BEATID, " +
                             "ADDRESS1, ADDRESS2, LANDLINE, MOBILE, " +
                             "EMAIL_ADDRESS, OTHER_DETAILS, CITYID, " +
                             "PINCODEID, STATUSID " +
                             "FROM CUSTOMER_MASTER " +
                             "WHERE ID= " + OutletId;
            try
            {
                using (SqlConnection con = new SqlConnection(@"Data Source = PC\SQLEXPRESS; Initial Catalog = SUBASHAGENCIES; Integrated Security = True"))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(cmdText, con))
                    {
                        SqlDataReader sdr;
                        sdr = cmd.ExecuteReader();
                        while (sdr.Read())
                        {
                            cust.ID = sdr.GetInt32(0);
                            cust.NAME = sdr.GetValue(1).ToString();
                            cust.OUTLET_NAME = sdr.GetValue(2).ToString();
                            cust.CATEGORYID = sdr.GetInt32(3);
                            cust.TYPEID = sdr.GetInt32(4);
                            cust.BEATID = sdr.GetInt32(5);
                            cust.ADDRESS1 = sdr.GetValue(6).ToString();
                            cust.ADDRESS2 = sdr.GetValue(7).ToString();
                            cust.LANDLINE = sdr.IsDBNull(8) ? default(long?) : sdr.GetInt64(8);
                            cust.MOBILE = sdr.IsDBNull(9) ? default(long?) : sdr.GetInt64(9);
                            cust.EMAIL_ADDRESS = sdr.GetValue(10).ToString();
                            cust.OTHER_DETAILS = sdr.GetValue(11).ToString();
                            cust.CITYID = sdr.GetInt32(12);
                            cust.PINCODEID = sdr.GetInt32(13);
                            cust.STATUSID = sdr.GetInt32(14);                            
                        }
                        return cust;
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public int AddOrUpdateCustomer(CUSTOMER cust)
        {
            string sQuery;
            if(cust.ID == 0)
            {
                sQuery = "INSERT INTO CUSTOMER_MASTER(NAME, OUTLET_NAME, CATEGORYID, TYPEID, BEATID, ADDRESS1, ADDRESS2, " +
                         "LANDLINE, MOBILE, EMAIL_ADDRESS, OTHER_DETAILS, CITYID, PINCODEID, STATUSID) VALUES " +
                         "('" + cust.NAME + "','" + cust.OUTLET_NAME + "'," + cust.CATEGORYID + "," + cust.TYPEID +
                         "," + cust.BEATID + ",'" + cust.ADDRESS1 + "','" + cust.ADDRESS2 + "'," + cust.LANDLINE +
                         "," + cust.MOBILE + ",'" + cust.EMAIL_ADDRESS + "','" + cust.OTHER_DETAILS +
                         "'," + cust.CITYID + "," + cust.PINCODEID + "," + cust.STATUSID + ")";
            }
            else
            {
                sQuery = "UPDATE CUSTOMER_MASTER SET NAME = '" + cust.NAME + "', OUTLET_NAME = '" + cust.OUTLET_NAME +
                         "', CATEGORYID = " + cust.CATEGORYID + ", TYPEID = " + cust.TYPEID + ", BEATID = " + cust.BEATID +
                         ", ADDRESS1 = '" + cust.ADDRESS1 + "', ADDRESS2 = '" + cust.ADDRESS2 + "', LADNLINE = " + cust.LANDLINE +
                         ", MOBILE = " + cust.MOBILE + ", EMAIL_ADDRESS = '" + cust.EMAIL_ADDRESS + "', OTHER_DETAILS = '" + cust.OTHER_DETAILS +
                         "', CITYID = " + cust.CITYID + ", PINCODEID = " + cust.PINCODEID + ", STATUSID = " + cust.STATUSID +
                         " WHERE ID =" + cust.ID; 
            }
            
            try
            {
                using (SqlConnection con = new SqlConnection(@"Data Source = PC\SQLEXPRESS; Initial Catalog = SUBASHAGENCIES; Integrated Security = True"))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(sQuery, con))
                    {
                        return cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
    }
}
