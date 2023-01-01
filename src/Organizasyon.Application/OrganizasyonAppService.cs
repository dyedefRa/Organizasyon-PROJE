using System;
using System.Collections.Generic;
using System.Text;
using Organizasyon.Localization;
using Volo.Abp.Application.Services;

namespace Organizasyon
{
    /* Inherit your application services from this class.
     */
    public abstract class OrganizasyonAppService : ApplicationService
    {
        protected OrganizasyonAppService()
        {
            LocalizationResource = typeof(OrganizasyonResource);
        }
    }
}
