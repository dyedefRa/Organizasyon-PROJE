using Organizasyon.Dtos.Companies;
using Organizasyon.Enums;
using System;
using Volo.Abp.Application.Dtos;

namespace Organizasyon.Dtos.Users
{
    public class UserDto : EntityDto<Guid>
    {
        public Guid? TenantId { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public UserType UserType { get; set; }
        public CompanyDto Company { get; set; }
        public Status Status { get; set; }

    }
}
