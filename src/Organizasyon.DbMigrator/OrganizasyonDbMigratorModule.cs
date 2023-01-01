using Organizasyon.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace Organizasyon.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(OrganizasyonEntityFrameworkCoreModule),
        typeof(OrganizasyonApplicationContractsModule)
        )]
    public class OrganizasyonDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
        }
    }
}
