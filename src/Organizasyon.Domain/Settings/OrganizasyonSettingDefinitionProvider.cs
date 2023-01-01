using Volo.Abp.Settings;

namespace Organizasyon.Settings
{
    public class OrganizasyonSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            //Define your own settings here. Example:
            //context.Add(new SettingDefinition(OrganizasyonSettings.MySetting1));
        }
    }
}
