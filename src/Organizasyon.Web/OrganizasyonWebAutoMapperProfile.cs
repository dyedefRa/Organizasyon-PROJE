using AutoMapper;
using Volo.Abp.Identity;

namespace Organizasyon.Web
{
    public class OrganizasyonWebAutoMapperProfile : Profile
    {
        public OrganizasyonWebAutoMapperProfile()
        {
            CreateMap<Pages.Admin.Identity.Roles.CreateModalModel.RoleInfoModel, IdentityRoleCreateDto>();
            CreateMap<Pages.Admin.Identity.Roles.EditModalModel.RoleInfoModel, IdentityRoleUpdateDto>();
            CreateMap<IdentityRoleDto, Pages.Admin.Identity.Roles.EditModalModel.RoleInfoModel>();
        }
    }
}
