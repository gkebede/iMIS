
using Domain;
using Microsoft.EntityFrameworkCore;
// using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Persistence
{
  public class DataContext : DbContext
  {
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<Student> Students { get; set; }

  protected override void OnModelCreating(ModelBuilder builder)
{
    base.OnModelCreating(builder);
    
    // Add any model-specific configurations if needed.
}
  }

}