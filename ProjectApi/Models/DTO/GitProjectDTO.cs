namespace ProjectApi.Models.DTO
{
    public class GitProjectDTO
    {
        public string ProjectImg { get; set; } = null!;
        public string ProjectName { get; set; } = null!;
        public List<int> Technologies { get; set; } = new List<int>();
        public DateOnly Date { get; set; }
        public string Description { get; set; } = null!;
        public string? GithubUrl { get; set; }
        public string? LiveDemoUrl { get; set; }
    }
}
