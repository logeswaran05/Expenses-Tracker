using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Expenses_Tracker.Models
{
    public class Sample
    {
        public Gender Sex { get; set; }
    }
    public enum Gender
    {
        Male,
        Female
    }
}