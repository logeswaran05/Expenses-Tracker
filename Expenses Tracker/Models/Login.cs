using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Expenses_Tracker.Models
{
    public class Login
    {
        public int Id { get; set; }
        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }
        [RegularExpression(@"(?=.*\d)(?=.*[A-Za-z]).{6,}", ErrorMessage = "Your password must be at least 6 characters long and contain at least 1 letter and 1 number")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}