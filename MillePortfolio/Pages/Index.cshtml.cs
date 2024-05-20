using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MillePortfolio.Models;
using Newtonsoft.Json;
using System.Net.Mail;
using System.Net;
using System.Net.Http.Headers;
using Microsoft.Extensions.Caching.Memory;

namespace MillePortfolio.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly HttpClient _http;
        private readonly IMemoryCache _memoryCache;

        public IndexModel(ILogger<IndexModel> logger, HttpClient http, IMemoryCache memoryCache)
        {
            _logger = logger;
            _http = http;
            _memoryCache = memoryCache;
        }

        public List<GitProject> GitProjects { get; set; }

        [BindProperty]
        public ContactForm Contact { get; set; }

        public async Task OnGetAsync()
        {
            _http.BaseAddress = new Uri("https://milleprojectapi.azurewebsites.net");
            _http.DefaultRequestHeaders.Accept.Clear();
            _http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


            if (!_memoryCache.TryGetValue("GitProjects", out List<GitProject> cachedProjects))
            {
                HttpResponseMessage response = await _http.GetAsync("/GitProject");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    if (!string.IsNullOrEmpty(json))
                    {
                        GitProjects = JsonConvert.DeserializeObject<List<GitProject>>(json);

                        _memoryCache.Set("GitProjects", GitProjects, TimeSpan.FromHours(1));
                    }
                }
            }
            else
            {
                GitProjects = cachedProjects;
            }
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
                _logger.LogError(ex, "Det gick ej att skicka meddelandet");
                TempData["ShowToast"] = false;
                TempData["ErrorMessage"] = "Det gick inte att skicka meddelandet";
            }


            return RedirectToPage("/Index");
        }
    }


}
