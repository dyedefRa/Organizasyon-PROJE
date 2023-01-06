using Organizasyon.Entities.Files;
using Organizasyon.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities;

namespace Organizasyon.Entities.Concepts
{
    [Table(OrganizasyonConsts.DbTablePrefix + "Concepts")]
    public class Concept : Entity<int>
    {
        [MaxLength(255)]
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        //Eksstra ozellıkler gelecek.
        //Etiket vs
        public DateTime CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public Status Status { get; set; }

        public virtual ICollection<File> Files { get; set; }
    }
}
