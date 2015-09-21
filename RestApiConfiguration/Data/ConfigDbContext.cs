using System.Data.Entity;

namespace RestApiConfiguration.Data
{
    public class ConfigDbContext : DbContext
    {
        public DbSet<ConfigurationEntity> Configurations { get; set; }
    }
}