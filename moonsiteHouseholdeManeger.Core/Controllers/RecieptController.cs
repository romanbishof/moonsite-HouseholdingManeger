using moonsiteHouseholdeManeger.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Umbraco.Core.Models;
using Umbraco.Core.Services;
using Umbraco.Web;
using Umbraco.Web.Mvc;

namespace moonsiteHouseholdeManeger.Core.Controllers
{
    //all operations regarding reciept form
    public class RecieptController: SurfaceController
    {
        public ActionResult RenderRecieptForm()
        {
            var vm = new RecieptFormViewModel();

            return PartialView("~/Views/Partials/RecieptForm.cshtml", vm);
        }

        [HttpPost]
        public ActionResult HandleRecieptForm(RecieptFormViewModel vm)
        {

            
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("Error", " please check the form");
                return CurrentUmbracoPage();
            }
            var RecieptList = Umbraco.ContentAtRoot().DescendantsOrSelfOfType("RecieptsList").FirstOrDefault();

            if(RecieptList != null)
            {
                int payment = (vm.PaymentAmount / vm.Monthes.Count);
                var date = DateTime.Now.ToString("dd-MM-yyyy");

                foreach (var month in vm.Monthes)
                {

                    var newReciept = Services.ContentService.Create("Reciept", RecieptList.Id, "Reciept");
                    newReciept.SetValue("TenantName", vm.NameOfTenent);
                    newReciept.SetValue("Apartment", vm.Apartment);
                    newReciept.SetValue("MonthOfPayment", month);
                    newReciept.SetValue("DateOfPayment", date);
                    newReciept.SetValue("PaymentMethod", vm.PaymentMethod);
                    newReciept.SetValue("PaymentAmount", payment);

                    Services.ContentService.SaveAndPublish(newReciept);

                }

            }

            TempData["status"] = "OK";
            return RedirectToCurrentUmbracoPage();


        }
    }
}
