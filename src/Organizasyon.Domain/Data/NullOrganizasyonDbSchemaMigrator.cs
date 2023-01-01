using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Organizasyon.Data
{
    /* This is used if database provider does't define
     * IOrganizasyonDbSchemaMigrator implementation.
     */
    public class NullOrganizasyonDbSchemaMigrator : IOrganizasyonDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}