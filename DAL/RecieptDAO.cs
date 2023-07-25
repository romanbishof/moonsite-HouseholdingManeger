using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class RecieptDAO:RecieptContext
    {
      
        public int AddReciept(Reciept reciept)
        {
            try
            {
                db.Reciepts.Add(reciept);
                db.SaveChanges();
                return reciept.ID;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<RecieptDTO> GetReciepts()
        {
            List<RecieptDTO> dtolist = new List<RecieptDTO>();
            List<Reciept> list = db.Reciepts.ToList();
            foreach (var reciept in list)
            {
                RecieptDTO dto = new RecieptDTO
                {

                    ID = reciept.ID,
                    NameOfTenent = reciept.TenentName,
                    Apartment = reciept.Apartment,
                    DateOfPayment = reciept.PaymentDate.Date,
                    PaymentMethod = reciept.PaymentMethod,
                    PaymentAmount = reciept.PaymentAmount,
                    Month = reciept.Month

                };

                dtolist.Add(dto);
            }

            dtolist = dtolist.OrderByDescending(date => date.DateOfPayment).ToList();

            return dtolist;
        }
    }
}
