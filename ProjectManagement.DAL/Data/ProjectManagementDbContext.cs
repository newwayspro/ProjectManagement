using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjectManagement.DAL.Entities;

namespace ProjectManagement.DAL.Data;

public sealed class ProjectManagementDbContext(DbContextOptions<ProjectManagementDbContext> options)
    : IdentityDbContext<AppUser>(options)
{
    public DbSet<Project> Projects => Set<Project>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Project>(entity =>
        {
            entity.ToTable("Projects");
            entity.HasKey(project => project.Id);
            entity.Property(project => project.Name).HasMaxLength(200).IsRequired();
            entity.Property(project => project.Description).HasMaxLength(2000);
            entity.Property(project => project.CreatedAtUtc).HasDefaultValueSql("SYSUTCDATETIME()");
        });
    }
}
