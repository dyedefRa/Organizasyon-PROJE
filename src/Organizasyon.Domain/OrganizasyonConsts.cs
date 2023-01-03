using System;

namespace Organizasyon
{
    public static class OrganizasyonConsts
    {
        public const string DbTablePrefix = "App";

        public const string DbSchema = null;

        #region MailTemplateKey

        public static class MailTemplateKey
        {
            public const string TemplateBody = "template_body";
            public const string TemplateFooter = "template_footer";
            public const string NewPassword = "new_password";

        }

        #endregion

        public static class DEFAULT
        {
            /// <summary>
            /// Filtrelerde kullanılan default tarih değeri
            /// </summary>
            public static DateTime DefaultDate = new DateTime(2000, 01, 01);
        }
    }
}
