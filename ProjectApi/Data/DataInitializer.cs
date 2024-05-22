using Microsoft.EntityFrameworkCore;
using ProjectApi.Models;

namespace ProjectApi.Data
{
    public class DataInitializer
    {
        private readonly AppDbContext _context;

        public DataInitializer(AppDbContext context)
        {
            _context = context;
        }

        public void Initialize()
        {
            _context.Database.Migrate();

            if (!_context.TechIcons.Any() && !_context.GitProjects.Any())
            {
                SeedData();
            }
        }

        public void SeedData()
        {
            var techIcons = new List<TechIcon>
            {
                new TechIcon { Technology = "HTML", Url = "https://kinsta.com/wp-content/uploads/2021/03/HTML-5-Badge-Logo.png" },
                new TechIcon { Technology = "CSS", Url = "https://upload.wikimedia.org/wikipedia/commons/thumb/6/62/CSS3_logo.svg/800px-CSS3_logo.svg.png" },
                new TechIcon { Technology = "C#", Url = "https://play-lh.googleusercontent.com/FSEp7SDYWWcgdJDy1CkYD9Cb7X7TAkUUZH_-3vJ5O4xN0gtt3Iv1EmhXQXKWm5V74WE" },
                new TechIcon { Technology = "ASP.NET", Url = "https://www.simplilearn.com/ice9/free_resources_article_thumb/ASP.NET_logo.jpg" },
                new TechIcon { Technology = "React", Url = "https://static-00.iconduck.com/assets.00/react-icon-512x512-u6e60ayf.png" },
                new TechIcon { Technology = "JavaScript", Url = "https://static.vecteezy.com/system/resources/previews/027/127/463/original/javascript-logo-javascript-icon-transparent-free-png.png" },
                new TechIcon { Technology = "LINQ", Url = "https://www.flowgear.net/wp-content/uploads/2019/03/linq.png" },
                new TechIcon { Technology = "SQL", Url = "https://optim.tildacdn.one/tild6238-3035-4335-a333-306335373139/-/resize/824x/-/format/webp/IMG_3349.jpg" },
                new TechIcon { Technology = "EFC", Url = "https://ucarecdn.com/b9980f90-7701-420e-8feb-2e45c5be8775/" },
                new TechIcon { Technology = "SSMS", Url = "https://miro.medium.com/v2/resize:fit:402/1*KTDZHTVaVbvbyhIf2PmBAw.png" },
                new TechIcon { Technology = "Azure", Url = "https://www.svgrepo.com/show/353464/azure.svg" }
            };

            if (!_context.TechIcons.Any())
            {
                _context.TechIcons.AddRange(techIcons);
                _context.SaveChanges();
            }


            //OM JAG BEHÖVER MER BILDER FÖR PROJEKT I FRAMTIDEN:
            //https://postimages.org/

            var projects = new List<GitProject>
            {
                new GitProject
                {
                    ProjectImg = "https://i.postimg.cc/j5xx1Nhq/image-bankapp.png",
                    ProjectName = "Bank Application",
                    Technologies = new List<TechStack>
                    {
                        new TechStack { TechIcon = techIcons.First(ti => ti.Technology == "C#") },
                        new TechStack { TechIcon = techIcons.First(ti => ti.Technology == "ASP.NET") },
                        new TechStack { TechIcon = techIcons.First(ti => ti.Technology == "EFC") },
                        new TechStack { TechIcon = techIcons.First(ti => ti.Technology == "HTML") },
                        new TechStack { TechIcon = techIcons.First(ti => ti.Technology == "CSS") },
                        new TechStack { TechIcon = techIcons.First(ti => ti.Technology == "JavaScript") },
                        new TechStack { TechIcon = techIcons.First(ti => ti.Technology == "LINQ") },
                        new TechStack { TechIcon = techIcons.First(ti => ti.Technology == "SQL") },
                        new TechStack { TechIcon = techIcons.First(ti => ti.Technology == "Azure") },
                        new TechStack { TechIcon = techIcons.First(ti => ti.Technology == "SSMS") }

                    },
                    Date = new DateOnly(2024, 03, 18),
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
                        new TechStack { TechIcon = techIcons.First(ti => ti.Technology == "HTML") },
                        new TechStack { TechIcon = techIcons.First(ti => ti.Technology == "CSS") },
                        new TechStack { TechIcon = techIcons.First(ti => ti.Technology == "JavaScript") },
                        new TechStack { TechIcon = techIcons.First(ti => ti.Technology == "React") },
                    },
                    Date = new DateOnly(2024, 01, 22),
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
                    ProjectName = "Advertisement API",
                    Technologies = new List<TechStack>
                    {
                        new TechStack { TechIcon = techIcons.First(ti => ti.Technology == "C#") },
                        new TechStack { TechIcon = techIcons.First(ti => ti.Technology == "ASP.NET") },
                        new TechStack { TechIcon = techIcons.First(ti => ti.Technology == "LINQ") },
                        new TechStack { TechIcon = techIcons.First(ti => ti.Technology == "EFC") },
                        new TechStack { TechIcon = techIcons.First(ti => ti.Technology == "SSMS") },
                        new TechStack { TechIcon = techIcons.First(ti => ti.Technology == "Azure") },
                    },
                    Date = new DateOnly(2024, 03, 18),
                    Description = "WebApi är ett RESTful API byggt med .NET 8.0, designat för att hantera annonser. " +
                    "Det tillhandahåller slutpunkter för att skapa, hämta, uppdatera och radera annonser. " +
                    "API:et stöder även partiella uppdateringar via HTTP PATCH och inkluderar autentiserings- och auktoriseringsmekanismer. " +
                    "API:et använder JWT för autentisering.",

                    GithubUrl = "https://github.com/Milles98/MillesAPIAssignment",
                    LiveDemoUrl = "https://advertisementapi.azurewebsites.net/swagger/index.html"
                },
                new GitProject
                {
                    ProjectImg = "https://i.postimg.cc/ZYyzRc2C/Milles-Hotel.png",
                    ProjectName = "Milles Hotel",
                    Technologies = new List<TechStack>
                    {
                        new TechStack { TechIcon = techIcons.First(ti => ti.Technology == "C#") },
                        new TechStack { TechIcon = techIcons.First(ti => ti.Technology == "LINQ") },
                        new TechStack { TechIcon = techIcons.First(ti => ti.Technology == "SQL") },
                        new TechStack { TechIcon = techIcons.First(ti => ti.Technology == "EFC") },
                        new TechStack { TechIcon = techIcons.First(ti => ti.Technology == "SSMS") },
                    },
                    Date = new DateOnly(2023, 11, 27),
                    Description = "MillesHotel-lösningen är en .NET 8.0-applikation som simulerar ett hotellhanteringssystem. " +
                    "Denna lösning inkluderar två projekt: MillesHotel och MillesHotelLibrary. " +
                    "MillesHotel är huvudprojektet i lösningen. Det är en konsolapplikation som " +
                    "tillhandahåller ett användargränssnitt för att interagera med hotellhanteringssystemet. Det " +
                    "innehåller olika menyer för att hantera bokningar, kunder, rum, fakturor och administrativa uppgifter. " +
                    "Projektet refererar till MillesHotelLibrary-projektet och flera NuGet-paket. " +
                    "MillesHotelLibrary är ett klassbibliotek som innehåller kärnlogiken och datamodellerna " +
                    "för hotellhanteringssystemet. Det inkluderar tjänster för att hantera bokningar, " +
                    "kunder, rum, fakturor och administrativa uppgifter. Det inkluderar också gränssnitt och " +
                    "datamodeller som representerar enheterna i systemet. Lösningen använder Entity " +
                    "Framework Core med en SQL Server-databas. HotelDbContext-klassen i " +
                    "MillesHotelLibrary-projektet är DbContext för applikationen.",
                    GithubUrl = "https://github.com/Milles98/MillesHotel",
                }

            };

            if (!_context.GitProjects.Any())
            {
                _context.GitProjects.AddRange(projects);
                _context.SaveChanges();
            }
        }
    }
}
