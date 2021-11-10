using System;
using System.Data.Entity;
using SportsStoreDomainLibrary.Entity;

namespace SportsStoreDomainLibrary
{
  public class SportsStoreDbContext:DbContext
  {
    public SportsStoreDbContext() : base("SportsStoreConnection")
    {

    }

    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
      //if schema is required then we will add it here
      //modelBuilder.HasDefaultSchema("<schemaname>")
      base.OnModelCreating(modelBuilder);
    }
  }
}
