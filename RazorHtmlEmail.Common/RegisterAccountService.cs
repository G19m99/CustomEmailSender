using RazorHtmlEmails.RazorClassLib.Services;
using RazorHtmlEmails.RazorClassLib.Views.Emails.ConfirmAccount;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using RazorHtmlEmails.RazorClassLib.Views.Emails.InvoiceEmail;

namespace RazorHtmlEmail.Common
{
    public class RegisterAccountService : IRegisterAccountService
    {
        private readonly IRazorViewToStringRenderer _razorViewToStringRenderer;

        //create a service foreach type of email
        public RegisterAccountService(IRazorViewToStringRenderer razorViewToStringRenderer)
        {
            _razorViewToStringRenderer = razorViewToStringRenderer;
        }
        //pass in all required data for email as params
        public async Task Register(string email, string baseUrl)
        {
            //confirm account takes a url to redirect user onbutton click & setup text for email
            var confirmAccountModel = new ConfirmAccountEmailViewModel($"{baseUrl}/{Guid.NewGuid()}");

            string body = await _razorViewToStringRenderer.RenderViewToStringAsync("/Views/Emails/ConfirmAccount/ConfirmAccountEmail.cshtml", confirmAccountModel);

            var toAddress = email;
            var fromAddress = "<ADD YOUR EMAIL HERE>";
            SendEmail(toAddress, fromAddress, "Please confirm", body);
        }
        public async Task Invoice(string email, string baseUrl, int order_id, int plug_amt, int tire_amt, decimal amt_due, DateTime date)
        {
            var CreateInvoiceModel = new CreateInvoiceEmailViewModel($"{baseUrl}/{Guid.NewGuid()}", order_id, plug_amt, tire_amt, amt_due, date);

            string body = await _razorViewToStringRenderer.RenderViewToStringAsync("/Views/Emails/InvoiceEmail/CreateInvoiceEmail.cshtml", CreateInvoiceModel);

            var toAddress = email;
            var fromAddress = "<ADD YOUR EMAIL HERE>";
            SendEmail(toAddress, fromAddress, "Here's youre invoice", body);
        }
        public static void SendEmail(string toAddresses, string fromAddress, string subject, string body)
        {
            SmtpClient client = new SmtpClient()
            {
                //smtp client needs to be set up under apps in google security
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential()
                {
                    UserName = "<ADD YOUR EMAIL HERE>",
                    Password = "<PASSWORD (RANDOM)>"
                }
            };
            MailAddress fromEmail = new MailAddress(fromAddress);
            MailAddress toEmail = new MailAddress(toAddresses);

            //creating and sending in Register method -sendEmail method handles smtp only

            MailMessage msg = new MailMessage()
            {
                From = fromEmail,
                IsBodyHtml = true,
                Subject = subject,
                Body = body

            };
            msg.To.Add(toEmail);
            try
            {
                client.Send(msg);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
   
    public interface IRegisterAccountService
    {
        Task Register(string email, string baseUrl);
        Task Invoice(string email, string baseUrl, int order_id, int plug_amt, int tire_amt, decimal amt_due, DateTime date);
    }
   
}
