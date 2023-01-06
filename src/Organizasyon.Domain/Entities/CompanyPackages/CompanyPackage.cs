using Organizasyon.Entities.Companies;
using Organizasyon.Entities.Packages;
using Organizasyon.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace Organizasyon.Entities.CompanyPackages
{
    [Table(OrganizasyonConsts.DbTablePrefix + "CompanyPackages")]
    public class CompanyPackage : Entity<int>
    {
        public int CompanyId { get; set; }
        [ForeignKey("CompanyId")]
        [Required]
        public Company Company { get; set; }
        public int PackageId { get; set; }
        [ForeignKey("PackageId")]
        [Required]
        public Package Package { get; set; }

        // şirketin paket bitmesine 2 gün var ve girip paket aldı
        //her gün çalışan job 2.gunun sonunda validi yaklaşmış olan şirketlere girip  packagelere gelecek ve dateamount ve unit type kadar valid ekleyecek ve bu company package yı not valid yapacak
        public int PackageDateAmount { get; set; }
        public DateUnitType PackageDateUnitType { get; set; }
        public DateTime CompanyBeforeValidDate { get; set; } //Şirketin en ki aktif tarihi
        public DateTime CompanyAfterValidDate { get; set; } //şirketin paketten sonrakı aktif tarihi
        public bool IsValid { get; set; }
        public DateTime CreatedDate { get; set; }
        public Status Status { get; set; }

    }
}
