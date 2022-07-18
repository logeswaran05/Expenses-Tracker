using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Expenses_Tracker.Models
{
    public class CalculateExpenses
    {

       

        [Required]
        [Display(Name = "Category")]
        public Category ExpenseCategory { get; set; }

        [Required]
        [Display(Name = "Duration")]
        public Duration Duration { get; set; }
       
       

    }
    
    public enum Duration
    {
        Total, LastMonth, LastYear
    }
   
}