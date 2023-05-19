using Infrastructure.Configurations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

/// <summary>
/// Database context class to provide access to the database.
/// </summary>
public class RepositoryContext : IdentityDbContext<User>
{
    public RepositoryContext(DbContextOptions options)
        : base(options)
    {
    }

    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<Member> Members { get; set; }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfiguration(new UserConfiguration());
        builder.ApplyConfiguration(new TenantConfiguration());
        builder.ApplyConfiguration(new MemberConfiguration());
        builder.ApplyConfiguration(new RoleConfiguration());
    }

    public override int SaveChanges()
    {
        SetSoftDelete();
        SetMetadata();

        return base.SaveChanges();
    }

    private void SetSoftDelete()
    {
        var entries = ChangeTracker
            .Entries()
            .Where(e => e.Entity is ISoftDeletable && 
                e.State == EntityState.Deleted);
       
        foreach (var entityEntry in entries)
        {
            // sets isDeleted to true 
            ((ISoftDeletable)entityEntry.Entity).IsDeleted = true;
            // sets the entity state to modified, so it gets updated instead of deleted
            entityEntry.State = EntityState.Modified;
        }

    }

    private void SetMetadata()
    {
        var entries = ChangeTracker
            .Entries()
            .Where(e => e.Entity is BaseEntity && (
                    e.State == EntityState.Added
                    || e.State == EntityState.Modified));

        foreach (var entityEntry in entries)
        {
            ((BaseEntity)entityEntry.Entity).UpdatedDate = DateTimeOffset.Now;

            if (entityEntry.State == EntityState.Added)
            {
                ((BaseEntity)entityEntry.Entity).CreatedDate = DateTimeOffset.Now;
            }
        }
    }
}
