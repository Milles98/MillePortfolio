using MillePortfolio.Models;

namespace MillePortfolio.Data
{
    public static class ProjectData
    {
        public static List<GitProject> GetProjects()
        {
            var techIcons = GetTechIcons();

            return new List<GitProject>
            {
                new GitProject
                {
                    ProjectImg = "/img/technologies/Azure Devops.png",
                    ProjectName = "Enterprise CI/CD Migration - Swedish Bank",
                    Technologies = new List<TechStack>
                    {
                        new TechStack { TechIcon = techIcons.First(ti => ti.Technology == "Azure DevOps") },
                        new TechStack { TechIcon = techIcons.First(ti => ti.Technology == "GitHub Actions") },
                        new TechStack { TechIcon = techIcons.First(ti => ti.Technology == "YAML") },
                        new TechStack { TechIcon = techIcons.First(ti => ti.Technology == "Git") },
                        new TechStack { TechIcon = techIcons.First(ti => ti.Technology == "Azure") }
                    },
                    Date = new DateOnly(2024, 08, 01),
                    Description = "Under min praktikperiod på en svensk bank ledde jag migreringen av företagets CI/CD-pipelines från Azure DevOps till GitHub Actions. " +
                    "Detta var ett omfattande projekt som krävde manuell konvertering av hundratals YAML-konfigurationer samtidigt som jag säkerställde noll driftstopp. " +
                    "Utmaningen var att hantera komplexa enterprise-säkerhetskrav och integrera med befintlig Azure-infrastruktur. " +
                    "Projektet tog flera månader med hundratals fokuserade timmar och resulterade i förbättrad deployment-hastighet och reducerade kostnader. " +
                    "Teamet var mycket imponerade av resultatet, som nu används i produktionsmiljö för samtliga projekt.",
                    GithubUrl = null,
                    LiveDemoUrl = null
                },
                new GitProject
                {
                    ProjectImg = "/img/technologies/pdf.png",
                    ProjectName = "PDF Accessibility Compliance - SJ (Swedish Railways)",
                    Technologies = new List<TechStack>
                    {
                        new TechStack { TechIcon = techIcons.First(ti => ti.Technology == "C#") },
                        new TechStack { TechIcon = techIcons.First(ti => ti.Technology == ".NET Framework") },
                        new TechStack { TechIcon = techIcons.First(ti => ti.Technology == "PDFsharp") }
                    },
                    Date = new DateOnly(2024, 11, 01),
                    Description = "Omfattande modernisering av PDF-genereringssystem för SJ (Sveriges största tågoperatör) för att uppnå 100% WCAG 2.2 AA-compliance. " +
                    "Huvudutmaningen var att migrera från föråldrat PDFlib till PDFsharp i ett legacy .NET Framework 4.6.2-projekt. " +
                    "PDFsharp saknar native stöd för accessibility i templates, så jag gick ner på låg nivå i både biblioteket och egen kod för att direkt manipulera PDF-element och strukturtaggar. " +
                    "Detta krävde djup förståelse av PDF/UA-standarden och Adobe's accessibility-riktlinjer. " +
                    "Projektet påverkar över 800 000 fakturor årligen och säkerställer att personer med funktionsnedsättning kan använda skärmläsare för att läsa sina resedokument. " +
                    "Tog över en månad av intensivt arbete och gav mig expertkunskap inom PDF-manipulation och tillgänglighetsstandarder.",
                    GithubUrl = null,
                    LiveDemoUrl = null
                },
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
                    Description = "Fullstack bankapplikation byggd med ASP.NET Core 8.0 som demonstrerar säker användarhantering och finansiella transaktioner. " +
                    "Applikationen består av fyra projekt: BankWeb (användargränssnitt med Identity), DataLibrary (EF Core dataåtkomst med AutoMapper), " +
                    "MoneyLaunderingSafetyMeasure (automatisk övervakning av misstänkta transaktioner) och WebAPI (RESTful endpoints). " +
                    "Implementerar avancerade säkerhetsfunktioner för att förhindra penningtvätt och bedrägeri. " +
                    "Deployed på Azure med CI/CD pipeline.",
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
                        new TechStack { TechIcon = techIcons.First(ti => ti.Technology == "React") }
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
                        new TechStack { TechIcon = techIcons.First(ti => ti.Technology == "Azure") }
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
                        new TechStack { TechIcon = techIcons.First(ti => ti.Technology == "SSMS") }
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
                    LiveDemoUrl = null
                }
            };
        }

        private static List<TechIcon> GetTechIcons()
        {
            return new List<TechIcon>
            {
                // Frontend
                new TechIcon { Technology = "HTML", Url = "https://cdn.jsdelivr.net/gh/devicons/devicon/icons/html5/html5-original.svg" },
                new TechIcon { Technology = "CSS", Url = "https://cdn.jsdelivr.net/gh/devicons/devicon/icons/css3/css3-original.svg" },
                new TechIcon { Technology = "JavaScript", Url = "https://cdn.jsdelivr.net/gh/devicons/devicon/icons/javascript/javascript-original.svg" },
                new TechIcon { Technology = "React", Url = "https://cdn.jsdelivr.net/gh/devicons/devicon/icons/react/react-original.svg" },

                // .NET Stack (unique icons)
                new TechIcon { Technology = "C#", Url = "https://cdn.jsdelivr.net/gh/devicons/devicon/icons/csharp/csharp-original.svg" },
                new TechIcon { Technology = "ASP.NET", Url = "https://cdn.jsdelivr.net/gh/devicons/devicon/icons/dotnetcore/dotnetcore-original.svg" },
                new TechIcon { Technology = ".NET Framework", Url = "https://cdn.jsdelivr.net/gh/devicons/devicon/icons/dot-net/dot-net-plain-wordmark.svg" },
                new TechIcon { Technology = "EFC", Url = "https://cdn.jsdelivr.net/gh/devicons/devicon/icons/sqlite/sqlite-original.svg" }, // Database-ish icon for EF
                new TechIcon { Technology = "LINQ", Url = "https://cdn.jsdelivr.net/gh/devicons/devicon/icons/csharp/csharp-line.svg" }, // C# variant for LINQ
                new TechIcon { Technology = "PDFsharp", Url = "https://cdn.jsdelivr.net/gh/devicons/devicon/icons/nuget/nuget-original.svg" }, // NuGet package icon

                // Database
                new TechIcon { Technology = "SQL", Url = "https://cdn.jsdelivr.net/gh/devicons/devicon/icons/azuresqldatabase/azuresqldatabase-original.svg" },
                new TechIcon { Technology = "SSMS", Url = "https://cdn.jsdelivr.net/gh/devicons/devicon/icons/microsoftsqlserver/microsoftsqlserver-original.svg" },

                // Cloud & DevOps
                new TechIcon { Technology = "Azure", Url = "https://cdn.jsdelivr.net/gh/devicons/devicon/icons/azure/azure-original.svg" },
                new TechIcon { Technology = "Azure DevOps", Url = "https://cdn.jsdelivr.net/gh/devicons/devicon/icons/azuredevops/azuredevops-original.svg" },
                new TechIcon { Technology = "GitHub Actions", Url = "https://cdn.jsdelivr.net/gh/devicons/devicon/icons/githubactions/githubactions-original.svg" },
                new TechIcon { Technology = "Git", Url = "https://cdn.jsdelivr.net/gh/devicons/devicon/icons/git/git-original.svg" },
                new TechIcon { Technology = "YAML", Url = "https://cdn.jsdelivr.net/gh/devicons/devicon/icons/yaml/yaml-original.svg" }
            };
        }
    }
}
