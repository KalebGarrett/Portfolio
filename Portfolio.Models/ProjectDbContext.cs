using Microsoft.EntityFrameworkCore;

namespace Portfolio.Models;

public class ProjectDbContext : DbContext
{
    public ProjectDbContext(DbContextOptions<ProjectDbContext> options) : base(options)
    {
    }

    public DbSet<Project> Projects { get; set; }
}