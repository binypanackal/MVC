using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoExpenceses.DoExpensesDto;
using DoExpenceses.DoExpencesesDAL;

namespace DoExpencesMVCAngualar.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/

        public ActionResult Login()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult Login(UserDetail userDetails)
        {
            if (!ModelState.IsValid)
            {
                TaskExpence taskExpence = new TaskExpence();
                UserDetail userdetails = taskExpence.verifyLogin(userDetails);
                if (userdetails != null)
                {
                    Session["UserName"] = userdetails.FirstName + " " + userdetails.LastName;
                    Session["UserID"] = userdetails.UserID;
                    System.Web.Security.FormsAuthentication.SetAuthCookie(Session["UserName"].ToString(), true);
                    return Json(new { redirectToUrl = Url.Action("Index","Doexpence") });
                }
                else
                {
                    HttpContext.Response.StatusCode = 400;
                    return new ContentResult{Content="Invalid Login , Try agin!"};
                   

                }
            }
            return View();
        }


    
        public JsonResult LogOff()
        {
            
            Session.Abandon();
            HttpCookie formCookie = new HttpCookie(System.Web.Security.FormsAuthentication.FormsCookieName, "");
            formCookie.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(formCookie);
            return Json(new { redirectToUrl = Url.Action("Index", "Doexpence") }, JsonRequestBehavior.AllowGet);
            
        }
        //
        // GET: /Login/Details/5

        public ActionResult Register()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult Register(UserDetail userDetails)
        {
            TaskExpence taskExpence = new TaskExpence();
            taskExpence.CreateUser(userDetails);
            return RedirectToAction("Index", "Doexpence"); 
        }


        //
        // GET: /Login/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Login/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Login/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Login/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Login/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Login/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
