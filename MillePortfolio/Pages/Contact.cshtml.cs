using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MillePortfolio.Models;
using System.Net.Mail;
using System.Net;
using System.Threading.Tasks;

namespace MillePortfolio.Pages
{
    public class ContactModel : PageModel
    {
        [BindProperty]
        public ContactForm Contact { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                var mailMessage = new MailMessage();
                mailMessage.To.Add("mille.elfver98@gmail.com");
                mailMessage.From = new MailAddress(Contact.Email);
                mailMessage.Subject = Contact.Subject;
                mailMessage.Body = $"Name: {Contact.Name}\nEmail: {Contact.Email}\nMessage: {Contact.Message}";

                using (var smtpClient = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtpClient.EnableSsl = true;
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.Credentials = new NetworkCredential(Environment.GetEnvironmentVariable("EMAIL_USERNAME"), Environment.GetEnvironmentVariable("EMAIL_PASSWORD"));
                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                    await smtpClient.SendMailAsync(mailMessage);
                }

                TempData["ShowToast"] = true;
            }
            catch (Exception ex)
            {
            }


            return RedirectToPage("/Index");
        }
    }
}
