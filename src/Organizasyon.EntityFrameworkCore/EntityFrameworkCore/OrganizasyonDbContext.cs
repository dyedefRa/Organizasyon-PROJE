using Microsoft.EntityFrameworkCore;
using Organizasyon.Entities.Cities;
using Organizasyon.Entities.Companies;
using Organizasyon.Entities.CompanyOrganizationConcepts;
using Organizasyon.Entities.CompanyPackages;
using Organizasyon.Entities.Concepts;
using Organizasyon.Entities.Files;
using Organizasyon.Entities.FrequentlyAskedQuestions;
using Organizasyon.Entities.Labels;
using Organizasyon.Entities.Logs;
using Organizasyon.Entities.MailTemplates;
using Organizasyon.Entities.Organizations;
using Organizasyon.Entities.Packages;
using Organizasyon.Entities.SentMails;
using Organizasyon.Entities.Towns;
using Organizasyon.Users;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.IdentityServer.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;
using Volo.Abp.Users.EntityFrameworkCore;

namespace Organizasyon.EntityFrameworkCore
{
    [ConnectionStringName("Default")]
    public class OrganizasyonDbContext : 
        AbpDbContext<OrganizasyonDbContext>
    {
        /* Add DbSet properties for your Aggregate Roots / Entities here. */
        
        #region Entities from the modules
        
        /* Notice: We only implemented IIdentityDbContext and ITenantManagementDbContext
         * and replaced them for this DbContext. This allows you to perform JOIN
         * queries for the entities of these modules over the repositories easily. You
         * typically don't need that for other modules. But, if you need, you can
         * implement the DbContext interface of the needed module and use ReplaceDbContext
         * attribute just like IIdentityDbContext and ITenantManagementDbContext.
         *
         * More info: Replacing a DbContext of a module ensures that the related module
         * uses this DbContext on runtime. Otherwise, it will use its own DbContext class.
         */
        
        //Identity
        public DbSet<AppUser> Users { get; set; }
        public DbSet<IdentityRole> Roles { get; set; }
        public DbSet<IdentityClaimType> ClaimTypes { get; set; }
        public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
        public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
        public DbSet<IdentityLinkUser> LinkUsers { get; set; }
        
        // Tenant Management
        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }

        #endregion


        public DbSet<City> Cities { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<CompanyOrganizationConcept> CompanyOrganizationConcepts { get; set; }
        public DbSet<CompanyPackage> CompanyPackages { get; set; }
        public DbSet<Concept> Concepts { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<FrequentlyAskedQuestion> FrequentlyAskedQuestions { get; set; }
        public DbSet<Label> Labels { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<MailTemplate> MailTemplates { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<SentMail> SentMails { get; set; }
        public DbSet<Town> Towns { get; set; }


        public OrganizasyonDbContext(DbContextOptions<OrganizasyonDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            /* Include modules to your migration db context */

            builder.ConfigurePermissionManagement();
            builder.ConfigureSettingManagement();
            builder.ConfigureBackgroundJobs();
            builder.ConfigureAuditLogging();
            builder.ConfigureIdentity();
            builder.ConfigureIdentityServer();
            builder.ConfigureFeatureManagement();
            builder.ConfigureTenantManagement();

            /* Configure your own tables/entities inside here */

            //builder.Entity<YourEntity>(b =>
            //{
            //    b.ToTable(OrganizasyonConsts.DbTablePrefix + "YourEntities", OrganizasyonConsts.DbSchema);
            //    b.ConfigureByConvention(); //auto configure for the base class props
            //    //...
            //});

            //TODOO 3
            builder.Entity<AppUser>(b =>
            {
                b.ToTable(AbpIdentityDbProperties.DbTablePrefix + "Users");
                b.ConfigureByConvention();
                b.ConfigureAbpUser();
                //b.Property(a => a.SteamId).HasColumnName("SteamId").HasMaxLength(128);
                //b.Property(a => a.DiscordId).HasColumnName("DiscordId").HasMaxLength(128);
                //b.Property(a => a.NormalizedEmail).HasColumnName("NormalizedEmail").HasMaxLength(256);
                //b.Property(a => a.NormalizedUserName).HasColumnName("NormalizedUserName").HasMaxLength(256);
                //b.Property(a => a.BirthDate).HasColumnName("BirthDate").HasColumnType("datetime");
                //b.Property(a => a.ImageId).HasColumnName("ImageId").HasColumnType("uniqueidentifier");

                //b.HasOne(d => d.Image)
                //    .WithMany(p => p.AppUsers)
                //    .HasForeignKey(d => d.ImageId)
                //    .HasConstraintName("FK_AbpUsers_LFGFiles");
                b.HasOne<IdentityUser>().WithOne().HasForeignKey<AppUser>(x => x.Id);
            });

        }
    }
}
