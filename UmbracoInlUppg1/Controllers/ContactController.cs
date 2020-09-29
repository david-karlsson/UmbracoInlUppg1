using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Mvc;
using UmbracoInlUppg1.Models;


namespace UmbracoInlUppg1.Controllers
{
    public class ContactController : SurfaceController
    {
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult HandleContactForm(ContactFormViewModel model)
        {
            //Check if the data posted is valid (All required's & email set in email field)
            if (!ModelState.IsValid)
            {
                //Not valid - so lets return the user back to the view with the data they entered still prepopulated
                return CurrentUmbracoPage();
            }
            //Generate an email message object to send
            MailMessage email = new MailMessage("noreply@localhost.se", model.Email)
            {
                Subject = "Contact Form Request",
                Body = model.Message
            };
            try
            {
                //Connect to SMTP credentials set in web.config
                SmtpClient smtp = new SmtpClient();
                //Try & send the email with the SMTP settings
                smtp.Send(email);
            }
            catch (Exception ex)
            {
                //Throw an exception if there is a problem sending the email
                throw ex;
            }
            //Update success flag (in a TempData key)
            TempData["IsSuccessful"] = true;
            //All done - lets redirect to the current page & show our thanks/success message
            return RedirectToCurrentUmbracoPage();
        }

        public ActionResult RenderContactForm()
        {
            return View();
        }
    }
}