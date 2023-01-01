using Organizasyon.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Organizasyon.Web.Pages
{
    /* Inherit your PageModel classes from this class.
     */
    public abstract class OrganizasyonPageModel : AbpPageModel
    {
        protected OrganizasyonPageModel()
        {
            LocalizationResourceType = typeof(OrganizasyonResource);
        }
    }
}