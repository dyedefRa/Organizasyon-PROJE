using System.Threading.Tasks;

namespace Organizasyon.Data
{
    public interface IOrganizasyonDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
