using Organizasyon.Dtos.Files;
using Organizasyon.Dtos.Users;
using Organizasyon.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Organizasyon.Dtos.Companies
{
    public class CreateUpdateCompanyDto
    {
        public CreateUpdateCompanyDto()
        {
            Files = new List<FileDto>();
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public Guid UserId { get; set; }
        public UserDto User { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string ShortAddress { get; set; }
        public string LongAddress { get; set; }
        public string LatLong { get; set; }
        public string About { get; set; }
        public int CityId { get; set; }
        public int DisrictId { get; set; }
        public DateTime CompanyValidDate { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public int? CreatedBy { get; set; }
        public Status Status { get; set; } = Status.Active;
        public List<FileDto> Files { get; set; }
        //public  List<CompanyPackageDto> CompanyPackages { get; set; }


    }
}
