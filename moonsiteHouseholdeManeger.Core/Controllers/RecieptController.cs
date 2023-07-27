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
using Umbraco.Core.Logging;
using System.Net.Mail;
using System.Net.Http;

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

            try
            {
                var RecieptList = Umbraco.ContentAtRoot().DescendantsOrSelfOfType("RecieptsList").FirstOrDefault();

                if (RecieptList != null)
                {
                    int payment = (vm.PaymentAmount / vm.Monthes.Count);
                    var date = DateTime.Now.Date;

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

                //Send out an email
                SendConfirmationEmail(vm);

                TempData["status"] = "OK";
                return RedirectToCurrentUmbracoPage();
            }
            catch (Exception exc)
            {

                Logger.Error<RecieptController>("There was an error in reciept submision", exc.Message);
                ModelState.AddModelError("Error", "Sorry there was a problem, please try again later");

            }

            return CurrentUmbracoPage();

        }

        //will sent out email
        private void SendConfirmationEmail(RecieptFormViewModel vm)
        {
            var siteSettings = Umbraco.ContentAtRoot().DescendantsOrSelfOfType("Settings").FirstOrDefault();
            if (siteSettings == null)
            {
                throw new Exception("There are no settings");
            }

            var fromAddress = siteSettings.Value<string>("emailSettingsFromAddress");
            var toAddress = siteSettings.Value<string>("emailSettingsAdminAccount");

            if (string.IsNullOrEmpty(fromAddress))
            {
                throw new Exception("There needs to be a from address in site settings");
            }
            
            if (string.IsNullOrEmpty(toAddress))
            {
                throw new Exception("There needs to be a to address in site settings");
            }

            //email subject
            var emailSubject = "אישור תשלום";
            var emailBody = $" התקבל {vm.NameOfTenent} התשלום עבור";
            var smtpMessage = new MailMessage();
            smtpMessage.Subject = emailSubject;
            smtpMessage.Body = emailBody;
            smtpMessage.From = new MailAddress(fromAddress);

            smtpMessage.To.Add(toAddress);

            //send 

            using(var smtpClient = new SmtpClient())
            {
                smtpClient.Send(smtpMessage);
            }

        }
    }
}
