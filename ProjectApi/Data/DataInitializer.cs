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
                new TechIcon { Technology = "Azure", Url = "https://www.svgrepo.com/show/353464/azure.svg" },
                new TechIcon { Technology = "GitHub Actions", Url = "https://avatars.githubusercontent.com/u/44036562?s=200&v=4" },
                new TechIcon { Technology = "Azure DevOps", Url = "https://upload.wikimedia.org/wikipedia/commons/2/20/Azure_DevOps_Logo.svg" },
                new TechIcon { Technology = "PDFsharp", Url = "https://avatars.githubusercontent.com/u/5804039?s=200&v=4" },
                new TechIcon { Technology = ".NET Framework", Url = "https://upload.wikimedia.org/wikipedia/commons/thumb/7/7d/Microsoft_.NET_logo.svg/1200px-Microsoft_.NET_logo.svg.png" },
                new TechIcon { Technology = "YAML", Url = "https://www.vectorlogo.zone/logos/yaml/yaml-icon.svg" },
                new TechIcon { Technology = "Git", Url = "https://git-scm.com/images/logos/downloads/Git-Icon-1788C.png" }
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
                    ProjectImg = "https://i.postimg.cc/nLy3C5kZ/cicd-migration.png",
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
                    ProjectImg = "https://i.postimg.cc/DzXv0Wdp/pdf-accessibility.png",
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
                    ProjectName = "React News Portal",
                    Technologies = new List<TechStack>
                    {
                        new TechStack { TechIcon = techIcons.First(ti => ti.Technology == "React") },
                        new TechStack { TechIcon = techIcons.First(ti => ti.Technology == "JavaScript") },
                        new TechStack { TechIcon = techIcons.First(ti => ti.Technology == "HTML") },
                        new TechStack { TechIcon = techIcons.First(ti => ti.Technology == "CSS") }
                    },
                    Date = new DateOnly(2024, 01, 22),
                    Description = "Modern responsiv webbapplikation byggd med React som integrerar med externa news APIs för att visa aktuella nyheter. " +
                    "Implementerar component-baserad arkitektur, state management och async API-anrop. " +
                    "Inkluderar kontaktformulär med validering och responsiv design som fungerar på alla enheter. " +
                    "Deployed på Vercel med automatisk deployment från GitHub.",
                    GithubUrl = "https://github.com/Milles98/mille-silicion-react",
                    LiveDemoUrl = "https://mille-silicion-react.vercel.app/"
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
