using Expenses_Tracker.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Expenses_Tracker.Context
{
    public class ExpensesTrakerDbContext :DbContext
    {
        static string con = @"Data Source =DESKTOP-MUE0CC2\SQLEXPRESS;Initial Catalog = ExpensesTracker; Integrated Security = True";
        public ExpensesTrakerDbContext():base(con)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Expense> Expenses { get; set; }

      
    }
   

}