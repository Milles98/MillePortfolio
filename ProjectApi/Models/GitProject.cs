namespace ProjectApi.Models
{
    public class GitProject
    {
        public string ProjectName { get; set; } = null!;
        public List<TechStack> Technology { get; set; } = null!;
        public DateOnly Date { get; set; }
        public string Description { get; set; } = null!;

    }
}
