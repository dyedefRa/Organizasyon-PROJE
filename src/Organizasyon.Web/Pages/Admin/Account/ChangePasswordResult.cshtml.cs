using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Organizasyon.Web.Pages.Admin.Account
{
    public class ChangePasswordResultModel : PageModel
    {
        public bool Result { get; set; }
        public void OnGet(bool result)
        {
            Result = result;
        }
    }
}
