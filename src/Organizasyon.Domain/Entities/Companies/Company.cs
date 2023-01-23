using Organizasyon.Entities.CompanyPackages;
using Organizasyon.Entities.Files;
using Organizasyon.Enums;
using Organizasyon.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities;

namespace Organizasyon.Entities.Companies
{
    [Table(OrganizasyonConsts.DbTablePrefix + "Companies")]
    public class Company : Entity<int>
    {
        [MaxLength(255)]
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public Guid UserId { get; set; }
        [ForeignKey("UserId")]
        [Required]
        public virtual AppUser User { get; set; }
        [MaxLength(100)]
        public string Phone { get; set; }
        [MaxLength(100)]
        public string Email { get; set; }
        [MaxLength(1000)]
        public string ShortAddress { get; set; }
        [MaxLength(1000)]
        public string LongAddress { get; set; }
        [MaxLength(300)]
        public string LatLong { get; set; }
        public string About { get; set; }
        public int CityId { get; set; }
        public int DisrictId { get; set; }
        public DateTime CompanyValidDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public Status Status { get; set; }
        public virtual ICollection<File> Files { get; set; }
        public virtual ICollection<CompanyPackage> CompanyPackages { get; set; }


    }
}
