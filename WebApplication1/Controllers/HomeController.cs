using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using DTO;
using BLL;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        RecieptBLL recieptBLL = new RecieptBLL();
        // GET: Home
        public ActionResult Index()
        {
            //Receipt reciept = new Receipt();
            RecieptDTO dto = new RecieptDTO();
            
            return View(dto);
        }

        [HttpPost]
        public ActionResult Index(RecieptDTO recieptModel)
        {

            RecieptDTO newRecieptModel = new RecieptDTO();

            if (ModelState.IsValid)
            {
                int payment = (recieptModel.PaymentAmount / recieptModel.Monthes.Count);

                foreach (var month in recieptModel.Monthes)
                {
                    recieptModel.Month = month;
                    recieptModel.PaymentAmount = payment;
                    

                    if (recieptBLL.AddReciept(recieptModel))
                    {
                        ModelState.Clear();
                    }
                        
                }
                return View(newRecieptModel);
            }
            else
            {
                
                return View(recieptModel);

            }
        }
    }
}