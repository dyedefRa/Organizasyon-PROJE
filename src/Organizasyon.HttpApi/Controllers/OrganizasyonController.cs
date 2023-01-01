using Organizasyon.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Organizasyon.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class OrganizasyonController : AbpController
    {
        protected OrganizasyonController()
        {
            LocalizationResource = typeof(OrganizasyonResource);
        }
    }
}