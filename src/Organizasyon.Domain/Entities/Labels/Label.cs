using Organizasyon.Enums;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities;

namespace Organizasyon.Entities.Labels
{
    [Table(OrganizasyonConsts.DbTablePrefix + "Labels")]
    public class Label : Entity<int>
    {
        public int Name { get; set; }
        public LabelType LabelType { get; set; }
        public DateTime InsertedDate { get; set; }
        public Status Status { get; set; }
    }
}
