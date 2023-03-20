using Microsoft.AspNetCore.Authorization;

namespace Organizasyon.Web.Pages.Admin
{
    [Authorize]
    public class IndexModel : OrganizasyonPageModel
    {
        public void OnGet()
        {
        }
    }
}