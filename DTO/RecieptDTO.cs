using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class RecieptDTO
    {
        public int ID { get; set; }
        public string NameOfTenent { get; set; }
        public int Apartment { get; set; }
        public DateTime DateOfPayment { get; set; }
        public string PaymentMethod { get; set; }
        public int PaymentAmount { get; set; }
        public string Month { get; set; }
        public List<string> Monthes { get; set;}

    }
}
