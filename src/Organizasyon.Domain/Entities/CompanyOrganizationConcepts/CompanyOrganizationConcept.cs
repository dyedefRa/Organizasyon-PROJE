using Organizasyon.Entities.Companies;
using Organizasyon.Entities.Concepts;
using Organizasyon.Entities.Organizations;
using Organizasyon.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities;

namespace Organizasyon.Entities.CompanyOrganizationConcepts
{
    //Conspt gibi düşün.
    [Table(OrganizasyonConsts.DbTablePrefix + "CompanyOrganizationConcepts")]
    public class CompanyOrganizationConcept : Entity<int>
    {
        //DEGISECEK
        public int CompanyId { get; set; }
        [ForeignKey("CompanyId")]
        [Required]
        public virtual Company Company { get; set; }
        public int OrganizationId { get; set; }
        [ForeignKey("OrganizationId")]
        [Required]
        public virtual Organization Organization { get; set; }
        public int ConceptId { get; set; }
        [ForeignKey("ConceptId")]
        [Required]
        public virtual Concept Concept { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public Status Status { get; set; }
    }
}
