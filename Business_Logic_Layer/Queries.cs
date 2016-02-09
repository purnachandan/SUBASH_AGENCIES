using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business_Logic_Layer.Models;
using System.Data;
using System.Globalization;

namespace Business_Logic_Layer
{
    public class Queries
    {
        
        public List<CUSTOMERDETAILS> GetOutlets(string sOutletName)
        {
            List<CUSTOMERDETAILS> csd = new List<CUSTOMERDETAILS>();
            string cmdText = "SELECT cust.CUSTOMERID, cust.CUSTOMER_NAME, cust.OUTLET_NAME, " +
                             "cate.CATEGORYNAME, beat.BEATNAME, city.CITYNAME, stat.STATUSCODE " +
                             "FROM CUSTOMER_MASTER cust " +
                             "INNER JOIN CUSTOMER_CATEGORY cate on cust.CATEGORYID = cate.CATEGORYID " +                             
                             "INNER JOIN CUSTOMER_BEAT beat on cust.BEATID = beat.BEATID " +
                             "INNER JOIN CUSTOMER_CITY city on cust.CITYID = city.CITYID " +                             
                             "INNER JOIN STATUS stat on cust.STATUSID = stat.STATUSID " +
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
                                CUSTOMERID = sdr.GetInt32(0),
                                CUSTOMER_NAME = sdr.GetValue(1).ToString(),
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
        public CUSTOMER_MASTER GetCustomer(int OutletId)
        {
            CUSTOMER_MASTER cust = new CUSTOMER_MASTER();
            string cmdText = "SELECT CUSTOMERID, CUSTOMER_NAME, OUTLET_NAME, CATEGORYID, TYPEID, BEATID, ADDRESS1, " + 
                             "ADDRESS2, LANDLINE, MOBILE, EMAIL_ADDRESS, OTHER_DETAILS, CITYID, STATUSID " +
                             "FROM CUSTOMER_MASTER WHERE CUSTOMERID= " + OutletId;
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
                            cust.CUSTOMERID = sdr.GetInt32(0);
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
        public int AddOrUpdateCustomer(CUSTOMER_MASTER cust)
        {
            string sQuery;
            if(cust.CUSTOMERID == 0)
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
                         " WHERE CUSTOMERID =" + cust.CUSTOMERID; 
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
        public int UpdateCustomerStatus(int iCustomerID, int iStatus)
        {
            string sQuery;
            sQuery = "UPDATE CUSTOMER_MASTER SET STATUSID = " + ((iStatus == 1) ? 2 : 1) + ", " +
                     "UPDATED_ON = CONVERT(VARCHAR,'" + DateTime.Now.ToString("yyyy-MM-dd") + "',103) " +
                     "WHERE CUSTOMERID = " + iCustomerID;
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
        public int AddUpdateEmployee(EMPLOYEE_MASTER Employee)
        {
            string sQuery;
            if (Employee.EMPLOYEEID == 0)
            {
                sQuery = "INSERT INTO EMPLOYEE_MASTER(EMPLOYEE_NAME, START_DATE, DESIGNATIONID, SALARY, STATUSID) VALUES " +
                         "('" + Employee.EMPLOYEE_NAME + "'," +
                         "CONVERT(VARCHAR,'" + Employee.START_DATE.ToString("yyyy-MM-dd") + "',103)), " + Employee.DESIGNATIONID + ", " +
                         Employee.SALARY + ", " + Employee.STATUSID + ")";
            }
            else
            {
                sQuery = "UPDATE EMPLOYEE_MASTER SET EMPLOYEE_NAME ='" + Employee.EMPLOYEE_NAME + "', " +
                         "START_DATE = CONVERT(VARCHAR,'" + Employee.START_DATE.ToString("yyyy-MM-dd") + "',103), " +
                         "END_DATE = " + (Employee.END_DATE.HasValue ? "CONVERT(VARCHAR,'" + DateTime.Parse(Employee.END_DATE.ToString()).ToString("yyyy-MM-dd") + "',103) " : DBNull.Value.ToString()) + ", " +
                         "DESIGNATIONID = " + Employee.DESIGNATIONID + ", SALARY = " + Employee.SALARY + ", " +
                         "UPDATED_ON = CONVERT(VARCHAR,'" + DateTime.Now.ToString("yyyy-MM-dd") + "',103) " +
                         "WHERE EMPLOYEEID = " + Employee.EMPLOYEEID;
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
        public List<EMPLOYEE_MASTER> GetEmployee(string sEmployeeSearchText)
        {
            List<EMPLOYEE_MASTER> EmployeeList = new List<EMPLOYEE_MASTER>();
            string cmdText = "SELECT  EMPLOYEEID, EMPLOYEE_NAME, START_DATE, END_DATE " +
                             "FROM EMPLOYEE_MASTER " +
                             "WHERE EMPLOYEE_NAME LIKE '%" + sEmployeeSearchText + "%'";
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
                            EmployeeList.Add(new EMPLOYEE_MASTER
                            {
                                EMPLOYEEID = sdr.GetInt32(0),
                                EMPLOYEE_NAME = sdr.GetValue(1).ToString(),
                                START_DATE = DateTime.Parse(sdr.GetValue(2).ToString()),
                                END_DATE = sdr.IsDBNull(3) ? default(DateTime?) : DateTime.Parse(sdr.GetValue(3).ToString()),
                                UPDATED_ON = null
                            });
                        }
                        return EmployeeList;
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public IEnumerable<EMPLOYEEDESIGNATION> GetDesignations()
        {
            List<EMPLOYEEDESIGNATION> EmployeeDesignations = new List<EMPLOYEEDESIGNATION>();
            string cmdText = "SELECT DESIGNATIONID, DESIGNATIONNAME FROM EMPLOYEE_DESIGNATION ";
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
                            EmployeeDesignations.Add(new EMPLOYEEDESIGNATION
                            {
                                DESIGNATIONID = sdr.GetInt32(0),
                                DESIGNATIONNAME = sdr.GetValue(1).ToString(),
                                UPDATED_ON = null
                            });
                        }
                        return EmployeeDesignations;
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
