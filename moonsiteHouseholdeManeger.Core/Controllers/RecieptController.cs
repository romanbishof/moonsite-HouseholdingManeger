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


                var newReciept = Services.ContentService.Create("Reciept", RecieptList.Id, "Reciept");
                newReciept.SetValue("TenantName", vm.NameOfTenent);
                newReciept.SetValue("Apartment", vm.Apartment);
                newReciept.SetValue("PaymentMethod", vm.PaymentMethod);
                newReciept.SetValue("PaymentAmount", vm.PaymentAmount);

                Services.ContentService.SaveAndPublish(newReciept);
            }

            TempData["status"] = "OK";
            return RedirectToCurrentUmbracoPage();


        }
    }
}
