using Microsoft.AspNetCore.Authorization;

namespace Organizasyon.Web.Pages.Admin
{
    [Authorize]
    public class IndexModel : OrganizasyonAdminPageModel
    {
        public void OnGet()
        {
        }
    }
}