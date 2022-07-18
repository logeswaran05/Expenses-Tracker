using Expenses_Tracker.Context;
using Expenses_Tracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Expenses_Tracker.Controllers
{
    public class ExpenseController : Controller
    {
       private readonly ExpensesTrakerDbContext context;
        public ExpenseController()
        {
            this.context = new ExpensesTrakerDbContext();
        }

        // GET: Expense
        public ActionResult Dashboard()

        {
            int id =(int) TempData["Userid"] ;
            TempData.Keep("Userid");
            var expencses= context.Expenses.Where(i=>i.Userid==id&&i.Date.Month==DateTime.Now.Month).ToList();
            decimal total = 0;
            if(context.Expenses.Where(i=>i.Id==id).Any())
            total = context.Expenses.Where(i => i.Userid == id).Sum(i=>i.Amount);

            ViewBag.totalExpenses=total;
            
            return View(expencses);
        }
       
        public ActionResult AddExpense()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddExpense(Expense data)
        {
            if(ModelState.IsValid)
            {
                data.Userid = (int)TempData["Userid"];
                TempData.Keep("Userid");

                if (data.Date.Date > DateTime.Now)
                {
                    ModelState.AddModelError("Date", "Date cannot be in future");
                    return View("AddExpense", data);
                }
                context.Expenses.Add(data);
                context.SaveChanges();
                return RedirectToAction("Dashboard");

            }
            else
                return View("AddExpense", data);


           
        }
        public ActionResult EditExpense(int id)
        {
            var expence = context.Expenses.Find(id);
            return View(expence);
        }
        [HttpPost]
        public ActionResult EditExpense(Expense data)
        {
            if (ModelState.IsValid)
            {
                data.Userid = (int)TempData["Userid"];
                TempData.Keep("Userid");
                if (data.Date.Date > DateTime.Now)
                {
                    ModelState.AddModelError("Date", "Date cannot be in future");
                    return View("EditExpense", data);
                }
                context.Entry<Expense>(data).State = System.Data.Entity.EntityState.Modified;
                context.SaveChangesAsync();
                return RedirectToAction("Dashboard");
            }
            else {
                ModelState.AddModelError("Date", "Date err future");

                return View("EditExpense", data);
            }
               
           
        }
        
        public ActionResult Delete(int id)
        {
            var  data = context.Expenses.Find(id);
            context.Expenses.Remove(data);
            context.SaveChanges();
            return RedirectToAction("Dashboard");
        }
        public ActionResult CalculateExpense()
        {
            ViewBag.isTableVisible = false;
           
            return View();
        }
        [HttpPost]
        public ActionResult CalculateExpense(string Duration,string ExpenseCategory)
        {

            int id = (int)TempData["Userid"];
            var dur =Duration.Split('-');
            int month = int.Parse(dur[1]);
            int year = int.Parse(dur[0]);
            int exp = int.Parse(ExpenseCategory);
            TempData.Keep("Userid");
           List<Expense> expenses = new List<Expense>();
           if(ModelState.IsValid)
            {
                expenses = context.Expenses.Where(i => i.Userid == id &&
                (int)i.ExpenseCategory ==exp &&
                i.Date.Month==month&&
                i.Date.Year == year).ToList();

            }
           if(expenses.Any())
            {
                ViewBag.isTableVisible = true;
                return View("CalculateExpense", expenses);
               
            }
            else
            {
                return Content("No Expense found");
            }

          

        }

    }
}