using Microsoft.AspNetCore.Mvc;
using MoonsiteHouseholdManeger.web.Models;
using Umbraco.Cms.Core.Cache;
using Umbraco.Cms.Core.Logging;
using Umbraco.Cms.Core.Routing;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Infrastructure.Persistence;
using Umbraco.Cms.Web.Website.Controllers;
using System.Net.Mail;
using Microsoft.IdentityModel.Tokens;

namespace MoonsiteHouseholdManeger.web.Controllers
{
    public class RecieptFormController : SurfaceController
    {
        private readonly ILogger<RecieptFormController> _logger;
        
        public RecieptFormController(ILogger<RecieptFormController> logger, IUmbracoContextAccessor umbracoContextAccessor, IUmbracoDatabaseFactory databaseFactory, ServiceContext services, AppCaches appCaches, IProfilingLogger profilingLogger, IPublishedUrlProvider publishedUrlProvider) : base(umbracoContextAccessor, databaseFactory, services, appCaches, profilingLogger, publishedUrlProvider)
        {
            _logger = logger;
            
        }
        

        [HttpPost]
        public IActionResult Submit(RecieptFormModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("Error", " please check the form");
                return CurrentUmbracoPage();
            }
            try
            {
                //ParentId of the forms that hold sthe children list
                var Reciept = Services.ContentTypeService?.Get("RecieptForms");
                var parentId = Guid.Parse("20454434-ec03-4511-96d0-3591afaa44fb");

                if (Reciept != null)
                {
                    int payment = model.PaymentAmount / model.Monthes.Count;

                    var date = DateTime.Now.Date;

                    foreach (var month in model.Monthes)
                    {

                        var newReciept = Services.ContentService?.Create("Reciept", parentId, "recieptForm");
                        newReciept.SetValue("TenentName", model.NameOfTenent);
                        newReciept.SetValue("Apartment", model.Apartment);
                        newReciept.SetValue("MonthOfPayment", month);
                        newReciept.SetValue("DateOfPayment", date);
                        newReciept.SetValue("PaymentMethod", model.PaymentMethod);
                        newReciept.SetValue("PaymentAmount", payment);

                        Services.ContentService.SaveAndPublish(newReciept);

                    }

                    //Send out an email
                    SendConfirmationEmail(model);

                    TempData["status"] = "OK";
                    return RedirectToCurrentUmbracoPage();
                }

            }
            catch (Exception exc)
            {

                //Logger.Error<Reciep>("There was an error in reciept submision", exc.Message);
                ModelState.AddModelError("Error", "Sorry there was a problem, please try again later");

            }

            return CurrentUmbracoPage();
        }
        String fromAddress;
        String toAddress;

        private void SendConfirmationEmail(RecieptFormModel model)
        {
            //var siteSettings = Services.ContentTypeService?.GetAllPropertyTypeAliases("siteSettings");
            var siteSettings = Services.ContentService.GetById(1098);

//            1098
//d13aa701 - 9a1a - 4f37 - bbc0 - 53a766e929cc

            if (siteSettings == null)
            {
                throw new Exception("There are no settings");
            }

            

            
            foreach (var property in siteSettings.Properties)
            {
                switch (property.Alias)
                {
                    case "emailSettingsFromAddress":
                        fromAddress = property.GetValue().ToString();
                        break;

                    case "emailSettingsAdminAccounts":
                        toAddress = property.GetValue().ToString();
                        break;

                    default:
                        break;
                }
            }

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
            var emailBody = $" התקבל {model.NameOfTenent} התשלום עבור";
            var smtpMessage = new MailMessage();
            smtpMessage.Subject = emailSubject;
            smtpMessage.Body = emailBody;
            smtpMessage.From = new MailAddress(fromAddress);

            smtpMessage.To.Add(toAddress);

            //send 

            using (var smtpClient = new SmtpClient())
            {
                smtpClient.Send(smtpMessage);
            }
        }
    }
}
