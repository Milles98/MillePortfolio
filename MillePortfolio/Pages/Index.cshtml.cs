using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MillePortfolio.Models;
using Newtonsoft.Json;

namespace MillePortfolio.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly HttpClient _http;

        public IndexModel(ILogger<IndexModel> logger, HttpClient http)
        {
            _logger = logger;
            _http = http;
            GitProjects = new List<GitProject>();
        }

        public List<GitProject> GitProjects { get; set; }

        public async Task OnGetAsync()
        {
            var response = await _http.GetAsync("https://milleprojectapi.azurewebsites.net/GitProject");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                if (!string.IsNullOrEmpty(json))
                {
                    GitProjects = JsonConvert.DeserializeObject<List<GitProject>>(json);
                }
            }
        }
    }


}
