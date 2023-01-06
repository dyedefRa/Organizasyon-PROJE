using Organizasyon.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities;

namespace Organizasyon.Entities.FrequentlyAskedQuestions
{
    [Table(OrganizasyonConsts.DbTablePrefix + "FrequentlyAskedQuestions")]
    public class FrequentlyAskedQuestion : Entity<int>
    {
        [Required]
        [MaxLength(1000)]
        public string Question { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public int FrequentlyAskedQuestionType { get; set; }
        public Status Status { get; set; }
    }
}
