using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class RecieptBLL
    {
        RecieptDAO dao = new RecieptDAO();
        public bool AddReciept(RecieptDTO recieptModel)
        {
            Reciept reciept= new Reciept();
            reciept.TenentName = recieptModel.NameOfTenent;
            reciept.Apartment = recieptModel.Apartment;
            reciept.Month = recieptModel.Month;
            reciept.PaymentMethod = recieptModel.PaymentMethod;
            reciept.PaymentAmount = recieptModel.PaymentAmount;
            reciept.PaymentDate = DateTime.Now;

            dao.AddReciept(reciept);
            
            return true;

        }

        public List<RecieptDTO> GetAllReciepts()
        {
            List<RecieptDTO> dtolist = dao.GetReciepts();
            
            return dtolist;
        }

    }
}
