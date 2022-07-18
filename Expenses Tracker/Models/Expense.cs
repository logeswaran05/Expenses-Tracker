using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Expenses_Tracker.Models
{
    public class Expense
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        [Required]
        
        public decimal Amount { get; set; }
        [Required]
        [Display(Name= "Category")]
        public Category ExpenseCategory { get; set; }
        [ForeignKey("User")]
        public int Userid { get; set; }
        public virtual User User { get; set; }
    }
    public enum Category
    {
        Electricity,
        Phone,
        Food,
        Fuel,
        Cloths,
        Television,
        Internet,
        Other
    }
}