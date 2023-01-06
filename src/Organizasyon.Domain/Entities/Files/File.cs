using Organizasyon.Entities.Companies;
using Organizasyon.Entities.Concepts;
using Organizasyon.Entities.Organizations;
using Organizasyon.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities;

namespace Organizasyon.Entities.Files
{
    [Table(OrganizasyonConsts.DbTablePrefix + "Files")]
    public class File : Entity<int>
    {
        [Required]
        [MaxLength(500)]
        public string FileName { get; set; }
        [MaxLength(10)]
        public string FileExtension { get; set; }
        public long? FileSize { get; set; }
        [Required]
        [MaxLength(500)]
        public string FilePath { get; set; }
        [Required]
        [MaxLength(500)]
        public string ShownPath { get; set; }
        [Required]
        [MaxLength(500)]
        public string FullPath { get; set; }
        [Required]
        [MaxLength(500)]
        public string Title { get; set; }
        public string ContentType { get; set; }
        public FileType FileType { get; set; }
        public int? CompanyId { get; set; }
        [ForeignKey("CompanyId")]
        public virtual Company Company { get; set; }
        public int? OrganizationId { get; set; }
        [ForeignKey("OrganizationId")]
        public virtual Organization Organization { get; set; }
        public int? ConceptId { get; set; }
        [ForeignKey("ConceptId")]
        public virtual Concept Concept { get; set; }
        public Status Status { get; set; }

        //public virtual AppUser AppUser { get; set; }

    }
}
