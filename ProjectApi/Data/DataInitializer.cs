using ProjectApi.Models;

namespace ProjectApi.Data
{
    public class DataInitializer
    {
        public static List<GitProject> Projects { get; set; }
        public static void SeedData()
        {
            var techIconUrls = new Dictionary<string, string>
            {
                {"HTML", "https://kinsta.com/wp-content/uploads/2021/03/HTML-5-Badge-Logo.png" },
                {"CSS", "https://upload.wikimedia.org/wikipedia/commons/thumb/6/62/CSS3_logo.svg/800px-CSS3_logo.svg.png" },
                {"C#", "https://play-lh.googleusercontent.com/FSEp7SDYWWcgdJDy1CkYD9Cb7X7TAkUUZH_-3vJ5O4xN0gtt3Iv1EmhXQXKWm5V74WE" },
                {"ASP.NET", "https://www.simplilearn.com/ice9/free_resources_article_thumb/ASP.NET_logo.jpg" },
                {"React", "https://static-00.iconduck.com/assets.00/react-icon-512x512-u6e60ayf.png" },
                {"JavaScript", "https://static.vecteezy.com/system/resources/previews/027/127/463/original/javascript-logo-javascript-icon-transparent-free-png.png" }
            };

            Projects = new List<GitProject>
            {
                new GitProject
                {
                    ProjectImg = "https://i.postimg.cc/j5xx1Nhq/image-bankapp.png",
                    ProjectName = "BankApplication",
                    Technologies = new List<TechStack>
                    {
                        new TechStack { Technology = "HTML", TechIconUrl = techIconUrls["HTML"] },
                        new TechStack { Technology = "CSS", TechIconUrl = techIconUrls["CSS"] },
                        new TechStack { Technology = "C#", TechIconUrl = techIconUrls["C#"]},
                        new TechStack { Technology = "ASP.NET", TechIconUrl = techIconUrls["ASP.NET"]},
                        new TechStack { Technology = "JavaScript", TechIconUrl = techIconUrls["JavaScript"]}
                    },
                    Date = new DateOnly(2024, 04, 02),
                    Description = "BankApplication är en omfattande lösning som består av fyra projekt: " +
                    "BankWeb, DataLibrary, MoneyLaunderingSafetyMeasure och WebAPI. " +
                    "BankWeb hanterar användargränssnitt och användarinteraktion, " +
                    "använder ASP.NET Core 8.0, Microsoft.AspNetCore.Identity för användarhantering " +
                    "och Microsoft.EntityFrameworkCore för dataåtkomst. DataLibrary fungerar som dataåtkomstlagret, " +
                    "använder Entity Framework Core 8.0 för dataåtkomst och AutoMapper för objekt-till-objekt-kartläggning. " +
                    "MoneyLaunderingSafetyMeasure är en konsolapplikation som implementerar säkerhetsåtgärder mot penningtvätt. " +
                    "WebAPI exponerar slutpunkter för programmatisk interaktion med lösningen. Lösningen kräver .NET 8.0 SDK.",
                    GithubUrl = "https://github.com/Milles98/BankSolution",
                    LiveDemoUrl = "https://millesbankapp.azurewebsites.net/"
                },
                new GitProject
                {
                    ProjectImg = "https://i.postimg.cc/bvCyKrVQ/image-react.png",
                    ProjectName = "React App",
                    Technologies = new List<TechStack>
                    {
                        new TechStack {Technology = "HTML", TechIconUrl = techIconUrls["HTML"]},
                        new TechStack {Technology = "CSS", TechIconUrl = techIconUrls["CSS"]},
                        new TechStack { Technology = "JavaScript", TechIconUrl = techIconUrls["JavaScript"]},
                        new TechStack {Technology = "React", TechIconUrl = techIconUrls["React"]}
                    },
                    Date = new DateOnly(2024, 01, 01),
                    Description = "React App är ett av mina projekt där jag har använt HTML/SCSS, " +
                    "JavaScript och React. Jag har skapat en stilren webbplats som är responsiv " +
                    "och skickar förfrågningar till ett API för att samla in nyheter. Webbplatsen " +
                    "innehåller en hemsida med attraktiva bilder, en nyhetssida som hämtar data från" +
                    " ett API, samt ett kontaktformulär för att möjliggöra kommunikation med besökare.",
                    GithubUrl = "https://github.com/Milles98/mille-silicion-react",
                    LiveDemoUrl = "https://mille-silicion-react.vercel.app/"
                },
                new GitProject
                {
                    ProjectImg = "https://i.postimg.cc/XvWDKgVJ/image-api.png",
                    ProjectName = "WebApi",
                    Technologies = new List<TechStack>
                    {
                        new TechStack {Technology = "C#", TechIconUrl = techIconUrls["C#"]},
                        new TechStack {Technology = "ASP.NET", TechIconUrl = techIconUrls["ASP.NET"]}
                    },
                    Date = new DateOnly(2024, 04, 01),
                    Description = "WebApi är ett RESTful API byggt med .NET 8.0, designat för att hantera annonser. " +
                    "Det tillhandahåller slutpunkter för att skapa, hämta, uppdatera och radera annonser. " +
                    "API:et stöder även partiella uppdateringar via HTTP PATCH och inkluderar autentiserings- och auktoriseringsmekanismer. " +
                    "API:et använder JWT för autentisering.",

                    GithubUrl = "https://github.com/Milles98/MillesAPIAssignment",
                    LiveDemoUrl = "https://advertisementapi.azurewebsites.net/swagger/index.html"
                }
            };
        }
    }
}
