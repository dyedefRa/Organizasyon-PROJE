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
            //Define your own permissions here. Example:
            //myGroup.AddPermission(OrganizasyonPermissions.MyPermission1, L("Permission:MyPermission1"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<OrganizasyonResource>(name);
        }
    }
}
