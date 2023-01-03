using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.Users;

namespace Organizasyon.Users
{
    public class AppUser : FullAuditedAggregateRoot<Guid>, IUser
    {
        #region Base properties

        /* These properties are shared with the IdentityUser entity of the Identity module.
         * Do not change these properties through this class. Instead, use Identity module
         * services (like IdentityUserManager) to change them.
         * So, this properties are designed as read only!
         */

        public virtual Guid? TenantId { get; private set; }

        public virtual string UserName { get; private set; }

        public virtual string NormalizedUserName { get; private set; }

        public virtual string Name { get; private set; }

        public virtual string Surname { get; private set; }

        public virtual string Email { get; private set; }

        public virtual string NormalizedEmail { get; private set; }

        public virtual bool EmailConfirmed { get; private set; }

        public virtual string PhoneNumber { get; private set; }

        public virtual bool PhoneNumberConfirmed { get; private set; }

        #endregion

        /* Add your own properties here. Example:
         *
         * public string MyProperty { get; set; }
         *
         * If you add a property and using the EF Core, remember these;
         *
         * 1. Update BDHDbContext.OnModelCreating
         * to configure the mapping for your new property
         * 2. Update BDHEfCoreEntityExtensionMappings to extend the IdentityUser entity
         * and add your new property to the migration.
         * 3. Use the Add-Migration to add a new database migration.
         * 4. Run the .DbMigrator project (or use the Update-Database command) to apply
         * schema change to the database.
         */

        //public string SteamId { get; set; }

        //public string DiscordId { get; set; }

        //public DateTime? BirthDate { get; set; }
        //public Guid? ImageId { get; set; }

        //public virtual File Image { get; set; }
        //public virtual ICollection<Team> Teams { get; set; }

        public string CompanyName { get; set; }
        public int? CompanyImageId { get; set; }
        public int? CompanyCityId { get; set; }
        public int? CompanyDisrictId { get; set; }
        public DateTime ValidDate { get; set; }

        //TODOO 1
        //public virtual File Image { get; set; }
        //public virtual ICollection<Team> Teams { get; set; }
        //Company File
    }
}
