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
                {"ASP.NET", "https://www.simplilearn.com/ice9/free_resources_article_thumb/ASP.NET_logo.jpg" }
            };

            Projects = new List<GitProject>
            {
                new GitProject
                {
                    ProjectName = "BankApplication",
                    Technology = new List<TechStack>
                    {
                        new TechStack { Technology = "HTML", TechIconUrl = techIconUrls["HTML"] },
                        new TechStack { Technology = "CSS", TechIconUrl = techIconUrls["CSS"] },
                        new TechStack { Technology = "C#", TechIconUrl = techIconUrls["C#"]},
                        new TechStack { Technology = "ASP.NET", TechIconUrl = techIconUrls["ASP.NET"]}
                    },
                    Date = new DateOnly(2024, 04, 02),
                    Description = "Test"
                },
                new GitProject
                {
                    ProjectName = "React App",
                    Technology = new List<TechStack>
                    {
                        new TechStack {Technology = "HTML", TechIconUrl = techIconUrls["HTML"]},
                        new TechStack {Technology = "CSS", TechIconUrl = techIconUrls["CSS"]}
                    },
                    Date = new DateOnly(2024, 01, 01),
                    Description = "Test"
                },
                new GitProject
                {
                    ProjectName = "WebApi",
                    Technology = new List<TechStack>
                    {
                        new TechStack {Technology = "C#", TechIconUrl = techIconUrls["C#"]}
                    },
                    Date = new DateOnly(2024, 04, 01),
                    Description = "Test"
                }
            };
        }
    }
}
