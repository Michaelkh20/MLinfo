using Microsoft.EntityFrameworkCore;
using MLinfo_v1._0.Models.DBModels;

namespace MLinfo_v1._0.Data;

public class ApplicationDBContext : DbContext
{
    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
    {
    }

    public DbSet<Article> Articles { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Organization> Organizations { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<MLMethod> MlMethods { get; set; }
    public DbSet<Keyword> Keywords { get; set; }
    public DbSet<Language> Languages { get; set; }
}