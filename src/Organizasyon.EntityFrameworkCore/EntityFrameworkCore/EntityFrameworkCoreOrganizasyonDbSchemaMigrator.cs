using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Organizasyon.Data;
using Volo.Abp.DependencyInjection;

namespace Organizasyon.EntityFrameworkCore
{
    public class EntityFrameworkCoreOrganizasyonDbSchemaMigrator
        : IOrganizasyonDbSchemaMigrator, ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;

        public EntityFrameworkCoreOrganizasyonDbSchemaMigrator(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task MigrateAsync()
        {
            /* We intentionally resolving the OrganizasyonDbContext
             * from IServiceProvider (instead of directly injecting it)
             * to properly get the connection string of the current tenant in the
             * current scope.
             */

            await _serviceProvider
                .GetRequiredService<OrganizasyonDbContext>()
                .Database
                .MigrateAsync();
        }
    }
}
