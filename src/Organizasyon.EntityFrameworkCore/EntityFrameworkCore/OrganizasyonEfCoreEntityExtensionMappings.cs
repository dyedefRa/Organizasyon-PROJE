using Microsoft.EntityFrameworkCore;
using Organizasyon.Users;
using Volo.Abp.Identity;
using Volo.Abp.ObjectExtending;
using Volo.Abp.Threading;

namespace Organizasyon.EntityFrameworkCore
{
    public static class OrganizasyonEfCoreEntityExtensionMappings
    {
        private static readonly OneTimeRunner OneTimeRunner = new OneTimeRunner();

        public static void Configure()
        {
            OrganizasyonGlobalFeatureConfigurator.Configure();
            OrganizasyonModuleExtensionConfigurator.Configure();

            OneTimeRunner.Run(() =>
            {
                /* You can configure extra properties for the
                 * entities defined in the modules used by your application.
                 *
                 * This class can be used to map these extra properties to table fields in the database.
                 *
                 * USE THIS CLASS ONLY TO CONFIGURE EF CORE RELATED MAPPING.
                 * USE OrganizasyonModuleExtensionConfigurator CLASS (in the Domain.Shared project)
                 * FOR A HIGH LEVEL API TO DEFINE EXTRA PROPERTIES TO ENTITIES OF THE USED MODULES
                 *
                 * Example: Map a property to a table field:

                     ObjectExtensionManager.Instance
                         .MapEfCoreProperty<IdentityUser, string>(
                             "MyProperty",
                             (entityBuilder, propertyBuilder) =>
                             {
                                 propertyBuilder.HasMaxLength(128);
                             }
                         );

                 * See the documentation for more:
                 * https://docs.abp.io/en/abp/latest/Customizing-Application-Modules-Extending-Entities
                 */

                ObjectExtensionManager.Instance
                   .MapEfCoreProperty<IdentityUser, int>(
                       nameof(AppUser.UserType),
                       (entityBuilder, propertyBuilder) =>
                       {
                           propertyBuilder.HasColumnName("UserType");
                       }
                   );

                //ObjectExtensionManager.Instance
                //   .MapEfCoreProperty<IdentityUser, string>(
                //       nameof(AppUser.CompanyName),
                //       (entityBuilder, propertyBuilder) =>
                //       {
                //           propertyBuilder.HasMaxLength(1000);
                //           propertyBuilder.HasColumnName("CompanyName");
                //       }
                //   );
                //ObjectExtensionManager.Instance
                //      .MapEfCoreProperty<IdentityUser, int?>(
                //          nameof(AppUser.CityId),
                //          (entityBuilder, propertyBuilder) =>
                //          {
                //              propertyBuilder.HasColumnName("CityId");
                //          }
                //      );
                //ObjectExtensionManager.Instance
                //     .MapEfCoreProperty<IdentityUser, int?>(
                //         nameof(AppUser.DisrictId),
                //         (entityBuilder, propertyBuilder) =>
                //         {
                //             propertyBuilder.HasColumnName("DisrictId");
                //         }
                //     );
                //ObjectExtensionManager.Instance
                //         .MapEfCoreProperty<IdentityUser, System.DateTime?>(
                //             nameof(AppUser.CompanyValidDate),
                //             (entityBuilder, propertyBuilder) =>
                //             {
                //                 propertyBuilder.HasColumnName("CompanyValidDate");
                //             }
                //         );
                //TODOO 2
                //ObjectExtensionManager.Instance
                //        .MapEfCoreProperty<IdentityUser, Guid?>(
                //            "ImageId",
                //            (entityBuilder, propertyBuilder) =>
                //            {
                //                propertyBuilder.HasColumnType("uniqueidentifier");
                //                propertyBuilder.HasColumnName("ImageId");
                //            }
                //        );
            });
        }
    }
}
