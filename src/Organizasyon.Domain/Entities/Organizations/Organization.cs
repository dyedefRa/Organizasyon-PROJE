using Organizasyon.Entities.Files;
using Organizasyon.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities;

namespace Organizasyon.Entities.Organizations
{
    //Admin ekleyecek . 
    //Babyshower
    //Kına
    //Nikah
    [Table(OrganizasyonConsts.DbTablePrefix + "Organizations")]
    public class Organization : Entity<int>
    {
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }
        [MaxLength(1000)]
        public string Description { get; set; }
        public File Image { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public Status Status { get; set; }
    }
}
