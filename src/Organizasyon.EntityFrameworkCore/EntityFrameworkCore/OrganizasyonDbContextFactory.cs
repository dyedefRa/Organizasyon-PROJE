using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Organizasyon.EntityFrameworkCore
{
    /* This class is needed for EF Core console commands
     * (like Add-Migration and Update-Database commands) */
    public class OrganizasyonDbContextFactory : IDesignTimeDbContextFactory<OrganizasyonDbContext>
    {
        public OrganizasyonDbContext CreateDbContext(string[] args)
        {
            OrganizasyonEfCoreEntityExtensionMappings.Configure();

            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<OrganizasyonDbContext>()
                .UseSqlServer(configuration.GetConnectionString("Default"));

            return new OrganizasyonDbContext(builder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../Organizasyon.DbMigrator/"))
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}
