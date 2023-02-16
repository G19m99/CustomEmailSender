using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorHtmlEmail.Common;
namespace CustomEmailSender.Pages
{
    public class IndexModel : PageModel
    {
        private IRegisterAccountService _registerAccountService;

        public IndexModel(IRegisterAccountService r)
        {
            this._registerAccountService = r;
        }

        public void OnPost()
        {
            string firstName = Request.Form["fName"];
            string lastName = Request.Form["lName"];
            string email = Request.Form["email"];
            SendReqistrationEmail(firstName, lastName, email);
        }
        public void SendReqistrationEmail(string fName, string lName, string email)
        {
            _registerAccountService.Register(email, "#");
        }
    }
}