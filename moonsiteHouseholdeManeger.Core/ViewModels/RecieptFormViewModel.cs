using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace moonsiteHouseholdeManeger.Core.ViewModels
{
    public class RecieptFormViewModel
    {

        public Guid BlogPostUmbracoKey { get; set; }
        public int ID { get; set; }

        [Required(ErrorMessage = "יש למלא את שם הדייר")]
        [RegularExpression(@"^[\u0590-\u05FF\s]+$", ErrorMessage = "שם הדייר יכול להכיל אותיות ורווחים בלבד")]
        public string NameOfTenent { get; set; }

        [Required(ErrorMessage = "אנא בחר דירה")]
        public int Apartment { get; set; }
        public DateTime DateOfPayment { get; set; }

        [Required(ErrorMessage = "אנא בחר אמצעי תשלום")]
        public string PaymentMethod { get; set; }

        [Required(ErrorMessage = "נא למלא את סכום התשלום")]
        [RegularExpression(@"^[1-9][0-9]*$", ErrorMessage = "יש לבחור ערכים מספריים בלבד")]
        public int PaymentAmount { get; set; }
        public string Month { get; set; }


        [Required(ErrorMessage = "יש לבחור לפחות חודש אחד לתשלום")]
        public List<string> Monthes { get; set; }
    }
}
