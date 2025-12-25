using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Memory;
using MillePortfolio.Models;
using MillePortfolio.Data;
using System.Net.Mail;
using System.Net;

namespace MillePortfolio.Pages
{
	public class IndexModel : PageModel
	{
		private readonly ILogger<IndexModel> _logger;
		private readonly IMemoryCache _cache;
		private static readonly TimeSpan RateLimitWindow = TimeSpan.FromMinutes(1);

		public IndexModel(ILogger<IndexModel> logger, IMemoryCache cache)
		{
			_logger = logger;
			_cache = cache;
		}

		public List<GitProject> GitProjects { get; set; } = new();

		[BindProperty]
		public ContactForm Contact { get; set; } = new();

		public void OnGet()
		{
			GitProjects = ProjectData.GetProjects();
		}

		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid)
			{
				GitProjects = ProjectData.GetProjects();
				return Page();
			}

			// Rate limiting - 1 message per minute per IP
			var clientIp = HttpContext.Connection.RemoteIpAddress?.ToString() ?? "unknown";
			var cacheKey = $"ContactForm_{clientIp}";

			if (_cache.TryGetValue(cacheKey, out _))
			{
				_logger.LogWarning("Rate limit exceeded for IP: {IP}", clientIp);
				TempData["ShowToast"] = false;
				TempData["ErrorMessage"] = "Vänta en minut innan du skickar igen";
				return RedirectToPage("/Index");
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
					smtpClient.Credentials = new NetworkCredential(
						Environment.GetEnvironmentVariable("EMAIL_USERNAME"),
						Environment.GetEnvironmentVariable("EMAIL_PASSWORD"));
					smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
					await smtpClient.SendMailAsync(mailMessage);
				}

				// Set rate limit after successful send
				_cache.Set(cacheKey, true, RateLimitWindow);

				TempData["ShowToast"] = true;
				_logger.LogInformation("Contact form submitted from IP: {IP}", clientIp);
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
