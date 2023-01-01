using Organizasyon.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Organizasyon.Web.Pages.Admin
{
    /* Inherit your PageModel classes from this class.
     */
    public abstract class OrganizasyonAdminPageModel : AbpPageModel
    {
        protected OrganizasyonAdminPageModel()
        {
            LocalizationResourceType = typeof(OrganizasyonResource);
        }
    }
}