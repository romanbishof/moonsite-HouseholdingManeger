using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class RecieptsController : Controller
    {
        RecieptBLL recieptBLL = new RecieptBLL();

        // GET: Reciepts
        public ActionResult Index()
        {
            List<RecieptDTO> allReciepts = recieptBLL.GetAllReciepts();
            return View(allReciepts);

        }
    }
}