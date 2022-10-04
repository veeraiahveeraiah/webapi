using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webapi123.Models;


namespace webapi123.Controllers
{
    public class HomeController : Controller
    {
      
        public ActionResult Login()
        {
             return View();
        }
        [HttpPost]
        public ActionResult Login(LoginClass lc)
        {
            string mainconn = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection sqlconn = new SqlConnection(mainconn);
            string sqlquery = "select Email,password from [dbo].[User] where Email=@Email and password=@password";
            SqlCommand sqlcomm = new SqlCommand(sqlquery, sqlconn);
            sqlconn.Open();
            sqlcomm.Parameters.AddWithValue("@Email", lc.UserEmail);
            sqlcomm.Parameters.AddWithValue("@password", lc.Password);
            SqlDataReader sdr = sqlcomm.ExecuteReader();
            if(sdr.Read())
            {
                Session["UserEmail"] = lc.UserEmail.ToString();
                 return RedirectToAction("Welcome");

            }
            else
            {
                ViewData["Message"] = "User Login Detalis Failed !";
            }
            sqlconn.Close();
            return View();
        }
        [HttpGet]
       public ActionResult Welcome()
       {
            return View();
        }
        
            
        
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(RegisterClass rc,HttpPostedFileBase file)
        {
            string mainconn = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection sqlconn = new SqlConnection(mainconn);
            string sqlquery = "insert into [dbo].[User](firstname,LastName,password,Confirmpassword,Email,Phonenumber) values (@firstname,@LastName,@password,@Confirmpassword,@Email,@Phonenumber)";
            SqlCommand sqlcomm = new SqlCommand(sqlquery, sqlconn);
            sqlconn.Open();
            sqlcomm.Parameters.AddWithValue("@firstname", rc.FirstName);
            sqlcomm.Parameters.AddWithValue("@LastName", rc.LastName);
            sqlcomm.Parameters.AddWithValue("@password", rc.Password);
            sqlcomm.Parameters.AddWithValue("@Confirmpassword", rc.Confirmpwd);
            sqlcomm.Parameters.AddWithValue("@Email", rc.Email);
            sqlcomm.Parameters.AddWithValue("@phoneNumber", rc.PhoneNumber);
            sqlcomm.ExecuteNonQuery();
             sqlconn.Close();
            ViewData["Message"] = "User Record" + rc.FirstName + "  Is Saved Successfully !";
            return View();
        }
    }
    
    
   

}