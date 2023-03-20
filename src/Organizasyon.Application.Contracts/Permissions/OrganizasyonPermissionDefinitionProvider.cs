using Organizasyon.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Organizasyon.Permissions
{
    public class OrganizasyonPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(OrganizasyonPermissions.GroupName);

            var companiesPermission = myGroup.AddPermission(OrganizasyonPermissions.Companies.Default, L("Şirket Yönetimi"));
            //documentPermission.AddChild(NumuneTakipPermissions.Documents.Create, L("Permission:Documents.Create"));
            //documentPermission.AddChild(NumuneTakipPermissions.Documents.Edit, L("Permission:Documents.Edit"));
            //documentPermission.AddChild(NumuneTakipPermissions.Documents.Delete, L("Permission:Documents.Delete"));

            var labelsPermission = myGroup.AddPermission(OrganizasyonPermissions.Labels.Default, L("Etiket Yönetimi"));

            var frequentlyAskedQuestionsPermission = myGroup.AddPermission(OrganizasyonPermissions.FrequentlyAskedQuestions.Default, L("SSS Yönetimi"));

            var packagesPermission = myGroup.AddPermission(OrganizasyonPermissions.Packages.Default, L("Paket Yönetimi"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<OrganizasyonResource>(name);
        }
    }
}
