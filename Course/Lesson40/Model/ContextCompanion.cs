using Microsoft.EntityFrameworkCore;

public class ContextCompanion : DbContext
{
 
    public ContextCompanion(DbContextOptions<ContextCompanion> options) : base(options)
    {
    }

    public DbSet<Companion> Companions { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Companion>().HasKey(c => c.id);   
    }
}