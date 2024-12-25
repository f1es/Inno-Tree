using InnoTree.Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace InnoTree.Infrastructure.Context;

public class InnoTreeDbContext : DbContext
{
	public DbSet<Decoration>? Decorations { get; set; }

    public InnoTreeDbContext()
    {
        
    }
    public InnoTreeDbContext(DbContextOptions<InnoTreeDbContext> options) :
		base(options)
    {
        
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);
		modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
	}

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		base.OnConfiguring(optionsBuilder);
	}
}
