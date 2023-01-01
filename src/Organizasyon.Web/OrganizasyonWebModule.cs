using System;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Organizasyon.EntityFrameworkCore;
using Organizasyon.Localization;
using Organizasyon.MultiTenancy;
using Microsoft.OpenApi.Models;
using Volo.Abp;
using Volo.Abp.Account.Web;
using Volo.Abp.AspNetCore.Authentication.JwtBearer;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.Localization;
using Volo.Abp.AspNetCore.Mvc.UI;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;
using Volo.Abp.AspNetCore.Mvc.UI.MultiTenancy;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Basic;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Basic.Bundling;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared;
using Volo.Abp.AspNetCore.Serilog;
using Volo.Abp.Autofac;
using Volo.Abp.AutoMapper;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity.Web;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement.Web;
using Volo.Abp.SettingManagement.Web;
using Volo.Abp.Swashbuckle;
using Volo.Abp.TenantManagement.Web;
using Volo.Abp.UI.Navigation.Urls;
using Volo.Abp.UI;
using Volo.Abp.UI.Navigation;
using Volo.Abp.VirtualFileSystem;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.CookiePolicy;

namespace Organizasyon.Web
{
    [DependsOn(
        typeof(OrganizasyonHttpApiModule),
        typeof(OrganizasyonApplicationModule),
        typeof(OrganizasyonEntityFrameworkCoreModule),
        typeof(AbpAutofacModule),
        typeof(AbpIdentityWebModule),
        typeof(AbpSettingManagementWebModule),
        typeof(AbpAccountWebIdentityServerModule),
        typeof(AbpAspNetCoreMvcUiBasicThemeModule),
        typeof(AbpAspNetCoreAuthenticationJwtBearerModule),
        typeof(AbpTenantManagementWebModule),
        typeof(AbpAspNetCoreSerilogModule),
        typeof(AbpSwashbuckleModule)
        )]
    public class OrganizasyonWebModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.PreConfigure<AbpMvcDataAnnotationsLocalizationOptions>(options =>
            {
                options.AddAssemblyResource(
                    typeof(OrganizasyonResource),
                    typeof(OrganizasyonDomainModule).Assembly,
                    typeof(OrganizasyonDomainSharedModule).Assembly,
                    typeof(OrganizasyonApplicationModule).Assembly,
                    typeof(OrganizasyonApplicationContractsModule).Assembly,
                    typeof(OrganizasyonWebModule).Assembly
                );
            });
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var hostingEnvironment = context.Services.GetHostingEnvironment();
            var configuration = context.Services.GetConfiguration();

            context.Services.AddAntiforgery(options =>
            {
                options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
                options.Cookie.HttpOnly = true;
                options.SuppressXFrameOptionsHeader = true;
            });

            context.Services.ConfigureApplicationCookie(options =>
            {
                options.ExpireTimeSpan = TimeSpan.FromDays(365 * 1000);
            });

            //ConfigureAppSetting(context, configuration);
            ConfigureUrls(configuration);
            ConfigureBundles();
            ConfigureAuthentication(context, configuration);
            ConfigureAutoMapper();
            ConfigureVirtualFileSystem(hostingEnvironment);
            ConfigureLocalizationServices();
            ConfigureAutoApiControllers();
            ConfigureRedirectStrategy(context, configuration);
            context.Services.AddLogging();
        }

        private void ConfigureAppSetting(ServiceConfigurationContext context, IConfiguration configuration)
        {
            //context.Services.Configure<ConstraintSettings>(configuration.GetSection("ConstraintSettings"));
            //context.Services.Configure<DefaultSettings>(configuration.GetSection("DefaultSettings"));
            //context.Services.Configure<FtpSettings>(configuration.GetSection("FtpSettings"));
            //context.Services.Configure<SftpSettings>(configuration.GetSection("SftpSettings"));
            //context.Services.Configure<SmtpSettings>(configuration.GetSection("SmtpSettings"));
            //context.Services.Configure<SftpMatchSettings>(configuration.GetSection("SftpMatchSettings"));
            //context.Services.Configure<ItsServiceSettings>(configuration.GetSection("ItsServiceSettings"));
            //configuration.GetSection("ConstraintSettings").Bind(XmlToDtoHelper.ConstraintSettings);
        }

        private void ConfigureRedirectStrategy(ServiceConfigurationContext context, IConfiguration configuration)
        {
            var basePath = configuration["App:SelfUrl"];
            context.Services
                .ConfigureApplicationCookie(options =>
                    options.Events.OnRedirectToLogin = context =>
                    {
                        if (context.Request.Path.StartsWithSegments("/api"))
                        {
                            context.Response.Headers["Location"] = context.RedirectUri;
                            context.Response.StatusCode = 401;
                        }
                        else
                            context.Response.Redirect(basePath + "/Home/Index");

                        return Task.CompletedTask;
                    });
        }

        private void ConfigureUrls(IConfiguration configuration)
        {
            Configure<AppUrlOptions>(options =>
            {
                options.Applications["MVC"].RootUrl = configuration["App:SelfUrl"];
            });
        }

        private void ConfigureBundles()
        {
            Configure<AbpBundlingOptions>(options =>
            {
                options.StyleBundles.Configure(
                    "css_files",
                    bundle =>
                    {
                        bundle.AddFiles("/global_assets/css/icons/icomoon/styles.min.css");
                        bundle.AddFiles("/global_assets/css/icons/material/styles.min.css");
                        bundle.AddFiles("/assets/css/bootstrap.min.css");
                        bundle.AddFiles("/assets/css/bootstrap_limitless.min.css");
                        bundle.AddFiles("/assets/css/layout.min.css");
                        bundle.AddFiles("/assets/css/components.min.css");
                        bundle.AddFiles("/assets/css/colors.min.css");
                        bundle.AddFiles("/libs/abp/aspnetcore-mvc-ui-theme-shared/datatables/datatables-styles.css");
                        bundle.AddFiles("/libs/bootstrap-datepicker/bootstrap-datepicker.min.css");
                        bundle.AddFiles("/global_assets/css/icons/fontawesome/styles.min.css");
                        bundle.AddFiles("/libs/toastr/toastr.min.css");
                        bundle.AddFiles("/libs/datatables.net-bs4/css/dataTables.bootstrap4.css");
                        bundle.AddFiles("/assets/css/custom.css");
                    });
            });

            Configure<AbpBundlingOptions>(options =>
            {
                options.StyleBundles.Configure(
                    "custom_js_files",
                    bundle =>
                    {
                        bundle.AddFiles("/assests/js/custom.js");
                    });
            });
        }

        private void ConfigureAuthentication(ServiceConfigurationContext context, IConfiguration configuration)
        {
            var key = Encoding.ASCII.GetBytes(configuration["AppSettings:SecretKey"]);

            context.Services.AddAuthentication().AddCookie(options =>
            {
                options.CookieManager = new ChunkingCookieManager();
                options.Cookie.HttpOnly = true;
                options.Cookie.SameSite = SameSiteMode.None;
                options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
                //options.ExpireTimeSpan = TimeSpan.MaxValue;
            })
                .AddJwtBearer(options =>
                {
                    options.Authority = configuration["AuthServer:Authority"];
                    options.RequireHttpsMetadata = Convert.ToBoolean(configuration["AuthServer:RequireHttpsMetadata"]);
                    options.Audience = "Organizasyon";
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });
        }

        private void ConfigureAutoMapper()
        {
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<OrganizasyonWebModule>();
            });
        }

        private void ConfigureVirtualFileSystem(IWebHostEnvironment hostingEnvironment)
        {
            if (hostingEnvironment.IsDevelopment())
            {
                Configure<AbpVirtualFileSystemOptions>(options =>
                {
                    options.FileSets.ReplaceEmbeddedByPhysical<OrganizasyonDomainSharedModule>(Path.Combine(hostingEnvironment.ContentRootPath, $"..{Path.DirectorySeparatorChar}Organizasyon.Domain.Shared"));
                    options.FileSets.ReplaceEmbeddedByPhysical<OrganizasyonDomainModule>(Path.Combine(hostingEnvironment.ContentRootPath, $"..{Path.DirectorySeparatorChar}Organizasyon.Domain"));
                    options.FileSets.ReplaceEmbeddedByPhysical<OrganizasyonApplicationContractsModule>(Path.Combine(hostingEnvironment.ContentRootPath, $"..{Path.DirectorySeparatorChar}Organizasyon.Application.Contracts"));
                    options.FileSets.ReplaceEmbeddedByPhysical<OrganizasyonApplicationModule>(Path.Combine(hostingEnvironment.ContentRootPath, $"..{Path.DirectorySeparatorChar}Organizasyon.Application"));
                    options.FileSets.ReplaceEmbeddedByPhysical<OrganizasyonWebModule>(hostingEnvironment.ContentRootPath);
                });
            }
        }

        private void ConfigureLocalizationServices()
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                //options.Languages.Add(new LanguageInfo("en", "en", "English"));
                options.Languages.Add(new LanguageInfo("tr", "tr", "Türkçe"));
            });
        }

        private void ConfigureAutoApiControllers()
        {
            Configure<AbpAspNetCoreMvcOptions>(options =>
            {
                options.ConventionalControllers.Create(typeof(OrganizasyonApplicationModule).Assembly);
            });
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();
            var env = context.GetEnvironment();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAbpRequestLocalization();

            if (!env.IsDevelopment())
            {
                app.UseErrorPage();
            }

            app.Use(async (context, next) =>
            {
                context.Response.Headers.Add("X-Frame-Options", "DENY");
                await next();
            });

            app.UseCookiePolicy(new CookiePolicyOptions
            {
                HttpOnly = HttpOnlyPolicy.Always,
                Secure = CookieSecurePolicy.Always,
            });

            app.UseCorrelationId();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseJwtTokenMiddleware();

            app.UseUnitOfWork();
            app.UseIdentityServer();
            app.UseAuthorization();
            app.UseAuditing();
            app.UseAbpSerilogEnrichers();
            app.UseConfiguredEndpoints();
        }
    }
}
