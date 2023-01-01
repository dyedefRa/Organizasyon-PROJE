using Microsoft.AspNetCore.Authorization;

namespace Organizasyon.Web.Pages
{
    [Authorize]
    public class IndexModel : OrganizasyonPageModel
    {
        public void OnGet()
        {
        }
    }
}