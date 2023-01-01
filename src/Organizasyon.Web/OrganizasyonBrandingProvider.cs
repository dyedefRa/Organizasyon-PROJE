using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace Organizasyon.Web
{
    [Dependency(ReplaceServices = true)]
    public class OrganizasyonBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "Organizasyon";
    }
}
