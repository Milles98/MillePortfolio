using Microsoft.EntityFrameworkCore;
using ProjectApi.Models;

namespace ProjectApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        public DbSet<GitProject> GitProjects { get; set; }
        public DbSet<TechIcon> TechIcons { get; set; }
        public DbSet<TechStack> TechStacks { get; set; }
    }
}
