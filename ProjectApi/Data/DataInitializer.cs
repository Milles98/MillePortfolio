using ProjectApi.Models;

namespace ProjectApi.Data
{
    public class DataInitializer
    {
        public static List<GitProject> Projects { get; set; }
        public static void SeedData()
        {
            var techIcons = new Dictionary<string, string>
            {
                {"HTML", "fa-brands fa-html5" },
                {"CSS", "fa-brands fa-css3" }
            };

            Projects = new List<GitProject>
            {
                new GitProject
                {
                    ProjectName = "BankApplication",
                    Technology = new List<TechStack>
                    {
                        new TechStack { Technology = "HTML", TechIcon = techIcons["HTML"] },
                        new TechStack { Technology = "CSS", TechIcon = techIcons["CSS"] },
                        // Add more technologies here...
                    },
                    Date = new DateOnly(2024, 04, 02),
                    Description = "Test"
                }
            };
        }
    }
}
