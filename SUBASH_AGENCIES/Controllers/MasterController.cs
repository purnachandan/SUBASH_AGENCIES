﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business_Logic_Layer;
using Business_Logic_Layer.Models;

namespace SUBASH_AGENCIES.Controllers
{    
    public class MasterController : Controller
    {
        Business_Logic objBL = new Business_Logic();
        Queries objQry = new Queries();
        // GET: Master
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Customer()
        {
            //List<BEAT> beat = new List<BEAT>();
            //List<CATEGORY> category = new List<CATEGORY>();
            //List<CITY> city = new List<CITY>();
            //List<CITYPINCODE> pincode = new List<CITYPINCODE>();
            //List<STATUS> status = new List<STATUS>();
            //List<TYPE> type = new List<TYPE>();

            //beat = ;
            //ViewBag.BEATID = new SelectList(objBL.Beat.ToList(), "BEATID", "BEATNAME");
            //ViewBag.CATEGORYID = new SelectList(objBL.Category.ToList(), "CATEGORYID", "CATEGORYNAME");
            //ViewBag.CITYID = new SelectList(objBL.City.ToList(), "CITYID", "CITYNAME");
            //ViewBag.PINCODEID = new SelectList(objBL.CityPinCode.ToList(), "PINCODEID", "PINCODE");
            //ViewBag.STATUSID = new SelectList(objBL.Status.ToList(), "STATUSID", "STATUSCODE");
            //ViewBag.TYPEID = new SelectList(objBL.Type.ToList(), "TYPEID", "TYPENAME");

            return View();
        }
        [HttpPost]
        [Route("/Master/Customer")]
        public ActionResult Customer_Post()
        {
            return View();
        }
        [HttpGet]
        public JsonResult GetCustomer(String sOutlet)
        {
            return Json(objQry.GetOutlets(sOutlet), JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult GetCustomerByID(int id)
        {
            //return Json(objQry.GetCustomer(id), JsonRequestBehavior.AllowGet);            
            return Json(objBL.Customer.Single(m => m.CUSTOMERID.Equals(id)), JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult GetCategory()
        {
            return Json(objBL.Category.ToList(), JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult GetTypes()
        {
            return Json(objBL.Type.ToList(), JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult GetBeat()
        {
            return Json(objBL.Beat.ToList(), JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult GetCity()
        {
            return Json(objBL.City.ToList(), JsonRequestBehavior.AllowGet);
        }
        //public JsonResult GetPinCode()
        //{
        //    return Json(objBL.CityPinCode.ToList(), JsonRequestBehavior.AllowGet);
        //}
        [HttpGet]
        public JsonResult GetStatus()
        {
            return Json(objBL.Status.ToList(), JsonRequestBehavior.AllowGet);
        }
        public int AddUpdateCustomer(CUSTOMER_MASTER customer)
        {
            return objQry.AddOrUpdateCustomer(customer);
        }
        public int ChangeCustomerStatus(int id, int status)
        {
            return objQry.UpdateCustomerStatus(id, status);
        }
        [HttpGet]
        public ActionResult Employee()
        {
            return View();
        }
        public int AddUpdateEmployee(EMPLOYEE_MASTER Employee)
        {
            return objQry.AddUpdateEmployee(Employee);
        }
        [HttpGet]
        public JsonResult PullEmployee(string EmployeeSearchText)
        {
            return Json(objQry.GetEmployee(EmployeeSearchText),JsonRequestBehavior.AllowGet) ;
        }
        [HttpGet]
        public JsonResult GetEmployeeDesignations()
        {
            return Json(objQry.GetDesignations(), JsonRequestBehavior.AllowGet);                 
        }        
    }
}