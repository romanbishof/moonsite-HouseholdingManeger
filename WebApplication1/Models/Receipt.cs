using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Receipt
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Tenant name is required.")]
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "Tenant name should contain only letters and spaces.")]
        public string NameOfTenent { get; set; }


        [Required(ErrorMessage = "Please select an apartment")]
        public string Apartment { get; set; }


        [Required(ErrorMessage = "Please choose month/s of payment")]
        public List<string> MonthOfPayment { get; set; }


        [Required(ErrorMessage = "Please select payment method")]
        public string PaymentMethod { get; set; }


        [Required(ErrorMessage = "Please write the amount of payment")]
        [RegularExpression(@"^[1-9][0-9]*$", ErrorMessage = "Payment amount should contain only numbers and cannot be 0.")]
        public int PaymentAmount { get; set; } 

    }
}