using RequestManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RequestManager.Controllers
{
    public class HomeController : MyController
    {
        // create database connections
        private DB_Entities _db = new DB_Entities();

        public class Depatment
        {      
            public string DepartmentValue { get; set; }
            public string DepartmentText { get; set; }
        }

        public class RequestBy
        {
            public string UserValue { get; set; }
            public string UserText { get; set; }
        }

        public class ChartData
        {
            public string project { get; set; }
            public string count { get; set; }
        }

        public ActionResult Index()
        {
            // no session then need to login
            if (Session["Name"] != null)
            {
                var Departs = _db.Users.Select(t => t.Department).Distinct().ToList();
                //select distinct department
                var categoryList1 = new List<Depatment>();
                if (Departs.Count() > 0)
                {
                    foreach (string Depart in Departs)
                    {
                        var item = new Depatment() { DepartmentText = Depart, DepartmentValue = Depart };
                        categoryList1.Add(item);
                    }
                    //Using viewBag to send data back.
                    ViewBag.database = categoryList1;
                }
                else 
                {
                  
                    ViewBag.database = categoryList1;
                   
                }
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }


        public ActionResult FillUser(string DepartmentValue)
        {
            //response to ajax calls
            var data = _db.Users.Where(s => s.Department.Equals(DepartmentValue)).ToList();
            //check the user info and add to a list so the dropdownlist has data source.
            var categoryList2 = new List<RequestBy>();
            if (data.Count() > 0)
            {
                foreach (var user in data)
                {
                    var item = new RequestBy() { UserValue = user.Name, UserText = user.Name };
                    categoryList2.Add(item);
                }
               
            }
            else { 
            
            }
               
           
            return Json(categoryList2, JsonRequestBehavior.AllowGet);
        }


        public ActionResult Login()
        {
            //login show page action
            ViewBag.Message = "Your login page.";

            return View();
        }

        public ActionResult Viewall()
        {
            //login show page action
            ViewBag.Message = "Your datatable page.";
            if (Session["Name"] != null)
            {

                List<string[]> list = new List<string[]>();
                var records = _db.Request.ToList();
                //get all data and convert to string type put in string array at last and store in ViewBag
                foreach (var record in records)
                {
                    string[] newdata = { record.ProjectName.ToString(), record.DepartmentName.ToString(), record.RequestBy.ToString(), record.DescriptionOfProblem.ToString(), record.CreateTime.ToString() };
                    list.Add(newdata);
                }
                string[][] data = list.ToArray();
                ViewBag.Datasource = data;

                return View();
            }
            else 
            {
                return RedirectToAction("Login");
            }
        }

        public ActionResult Chart()
        {
            //login show page action
            ViewBag.Message = "Your Chart page.";

            if (Session["Name"] != null)
            {
                var records = _db.Request.GroupBy(d => d.ProjectName).Select(y => new { ProjectName = y.Key, Count = y.Count() }).ToList();
                string projectname=null;
                string count=null;
               
                //put all data to a string then use viewbag send to jQuery function
                foreach (var record in records)
                {
                    projectname = projectname+ "'" + record.ProjectName.ToString() + "'" + ",";
                    count= count+ record.Count.ToString() + ",";
                    
                }
                if (projectname.Length > 1)
                {
                    projectname = projectname.Remove(projectname.Length - 1, 1);
                }

                if (count.Length > 1)
                {
                    count = count.Remove(count.Length - 1, 1);
                }

                ViewBag.ObjectName =projectname;
                ViewBag.Data = count;
                return View();
            }
            else 
            {
                return RedirectToAction("Login");
            }
                
        }

        [HttpPost]
        public ActionResult Loginpost(string name, string password)
        {
            //response login post
            if (ModelState.IsValid)
            {


                var data = _db.Users.Where(s => s.Name.Equals(name) && s.Password.Equals(password)).ToList();
                if (data.Count() > 0)
                {
                    //add session
                    Session["Name"] = name;
                    Session["Type"] = data.FirstOrDefault().Type;
                    Session["Depart"] = data.FirstOrDefault().Department;
                    Session["error"] = null;
                    return RedirectToAction("Index");
                }
                else
                {
                    //wrong password or username
                    Session["error"] = RequestManager.Resources.Resource.WrongUser;
                    return RedirectToAction("Login");
                }
            }
            else
            {
                return RedirectToAction("Login");
            }
        }


        [HttpPost]
        public ActionResult RequestPost(RequestModel obj)
        {
            if (ModelState.IsValid)
            {
                //check duplication or not
                RequestModel records = _db.Request.FirstOrDefault(u => u.DepartmentName.ToLower().Equals(obj.DepartmentName.ToLower()) && u.ProjectName.ToLower().Equals(obj.ProjectName.ToLower()) && u.RequestBy.ToLower().Equals(obj.RequestBy.ToLower()) && u.DescriptionOfProblem.ToLower().Equals(obj.DescriptionOfProblem.ToLower()));
                if (records == null)
                {
                    try
                    {
                        obj.CreateTime = DateTime.Now;
                        //save to database
                        _db.Request.Add(obj);
                        _db.SaveChanges();
                        return RedirectToAction("Viewall", "Home");
                    }
                    catch(Exception e) 
                    {
                        Session["error"] = e.Message.ToString();

                        return RedirectToAction("Index", "Home");
                    }
                   
                }
                else
                {
                  
                    Session["error"] = "Records already exists. Please enter a different request.";
                }
            }

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Logout()
        {
            Session.Clear();
            //remove session to log outs
            return RedirectToAction("Login");
        }

        //set language action
        public ActionResult ChangeLanguage(string lang)
        {
            new LanguageMang().SetLanguage(lang);
            return RedirectToAction("Index", "Home");
        }
    }
}