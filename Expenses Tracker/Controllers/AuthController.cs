using Expenses_Tracker.Context;
using Expenses_Tracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;

namespace Expenses_Tracker.Controllers
{
    public class AuthController : Controller
    {
        public readonly ExpensesTrakerDbContext context;

        public AuthController()
        {
            this.context = new ExpensesTrakerDbContext();
        }

        // GET: Auth
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Login data)
        {
            if(ModelState.IsValid)
            {
                var user=context.Users.Where(item=>item.Email==data.Email &&item.Password==data.Password).FirstOrDefault();
                if(user==null)
                {
                    ModelState.AddModelError("Email", "Email not Match");
                    ModelState.AddModelError("Password", "Password not Match");
                    return View("Index",data);
                }
                else
                {
                    TempData["Userid"]=user.Id;
                    return RedirectToAction("Dashboard","Expense");
                }
            }
            else
            {
                return View("Index", data);
            }
        }
        public ActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Signup(User data)
        {
            if (ModelState.IsValid)
            {
                var user = context.Users.Where(i => i.Email == data.Email).FirstOrDefault();
                if (user != null)
                {
                    ModelState.AddModelError("Email", "Email Already Exists");
                    return View("Signup", data);
                }
                else
                {
                    context.Users.Add(data);
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }

            }
         else
                return View("Signup", data);
        }


        }
}