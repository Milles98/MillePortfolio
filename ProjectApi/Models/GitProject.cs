namespace ProjectApi.Models
{
    public class GitProject
    {
        public int Id { get; set; }
        public string ProjectImg { get; set; } = null!;
        public string ProjectName { get; set; } = null!;
        public List<TechStack> Technologies { get; set; } = new List<TechStack>();
        public DateOnly Date { get; set; }
        public string Description { get; set; } = null!;
        public string? GithubUrl { get; set; }
        public string? LiveDemoUrl { get; set; }
    }
}
