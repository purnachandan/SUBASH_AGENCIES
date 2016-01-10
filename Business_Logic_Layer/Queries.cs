﻿using System;
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
            string cmdText = "SELECT cust.ID, cust.CUSTOMER_NAME, cust.OUTLET_NAME, " +
                             "cate.CATEGORYNAME, beat.BEATNAME, city.CITYNAME, stat.STATUSCODE " +
                             "FROM CUSTOMER_MASTER cust " +
                             "INNER JOIN CUSTOMERCATEGORY cate on cust.CATEGORYID = cate.CATEGORYID " +                             
                             "INNER JOIN CUSTOMERBEAT beat on cust.BEATID = beat.BEATID " +
                             "INNER JOIN CUSTOMERCITY city on cust.CITYID = city.CITYID " +                             
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
                                ID = sdr.GetInt32(0),
                                NAME = sdr.GetValue(1).ToString(),
                                OUTLET_NAME = sdr.GetValue(2).ToString(),
                                CATEGORYNAME = sdr.GetValue(3).ToString(),
                                TYPENAME = null,
                                BEATNAME = sdr.GetValue(4).ToString(),
                                ADDRESS1 = null,
                                ADDRESS2 = null,
                                //LANDLINE = sdr.IsDBNull(7) ? default(string?) : sdr.GetValue(7),
                                //MOBILE = sdr.IsDBNull(8) ? default(string?) : sdr.GetValue(8),
                                LANDLINE = null,
                                MOBILE = null,
                                EMAIL_ADDRESS = null,
                                OTHER_DETAILS = null,
                                CITYNAME = sdr.GetValue(5).ToString(),
                                PINCODE = null,
                                STATUS = sdr.GetValue(6).ToString(),
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
            string cmdText = "SELECT ID, CUSTOMER_NAME, OUTLET_NAME, CATEGORYID, TYPEID, BEATID, ADDRESS1, " + 
                             "ADDRESS2, LANDLINE, MOBILE, EMAIL_ADDRESS, OTHER_DETAILS, CITYID, STATUSID " +
                             "FROM CUSTOMER_MASTER WHERE ID= " + OutletId;
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
                            cust.CUSTOMER_NAME = sdr.GetValue(1).ToString();
                            cust.OUTLET_NAME = sdr.GetValue(2).ToString();
                            cust.CATEGORYID = sdr.GetInt32(3);
                            cust.TYPEID = sdr.GetInt32(4);
                            cust.BEATID = sdr.GetInt32(5);
                            cust.ADDRESS1 = sdr.GetValue(6).ToString();
                            cust.ADDRESS2 = sdr.GetValue(7).ToString();
                            //cust.LANDLINE = sdr.IsDBNull(8) ? default(long?) : sdr.GetInt64(8);
                            //cust.MOBILE = sdr.IsDBNull(9) ? default(long?) : sdr.GetInt64(9);
                            cust.LANDLINE = sdr.GetValue(8).ToString();
                            cust.MOBILE = sdr.GetValue(9).ToString();
                            cust.EMAIL_ADDRESS = sdr.GetValue(10).ToString();
                            cust.OTHER_DETAILS = sdr.GetValue(11).ToString();
                            cust.CITYID = sdr.GetInt32(12);
                            //cust.PINCODEID = sdr.GetInt32(13);
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
                sQuery = "INSERT INTO CUSTOMER_MASTER(CUSTOMER_NAME, OUTLET_NAME, CATEGORYID, TYPEID, BEATID, ADDRESS1, ADDRESS2, " +
                         "LANDLINE, MOBILE, EMAIL_ADDRESS, OTHER_DETAILS, CITYID, STATUSID) VALUES " +
                         "('" + cust.CUSTOMER_NAME + "','" + cust.OUTLET_NAME + "'," + cust.CATEGORYID + "," + cust.TYPEID +
                         "," + cust.BEATID + ",'" + cust.ADDRESS1 + "','" + cust.ADDRESS2 + "','" + cust.LANDLINE +
                         "','" + cust.MOBILE + "','" + cust.EMAIL_ADDRESS + "','" + cust.OTHER_DETAILS +
                         "'," + cust.CITYID + "," + cust.STATUSID + ")";
            }
            else
            {
                sQuery = "UPDATE CUSTOMER_MASTER SET CUSTOMER_NAME = '" + cust.CUSTOMER_NAME + "', OUTLET_NAME = '" + cust.OUTLET_NAME +
                         "', CATEGORYID = " + cust.CATEGORYID + ", TYPEID = " + cust.TYPEID + ", BEATID = " + cust.BEATID +
                         ", ADDRESS1 = '" + cust.ADDRESS1 + "', ADDRESS2 = '" + cust.ADDRESS2 + "', LANDLINE = '" + cust.LANDLINE +
                         "', MOBILE = '" + cust.MOBILE + "', EMAIL_ADDRESS = '" + cust.EMAIL_ADDRESS + "', OTHER_DETAILS = '" + cust.OTHER_DETAILS +
                         "', CITYID = " + cust.CITYID + ", STATUSID = " + cust.STATUSID +
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
