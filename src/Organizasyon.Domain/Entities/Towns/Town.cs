using Organizasyon.Entities.Cities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities;

namespace Organizasyon.Entities.Towns
{
    [Table(OrganizasyonConsts.DbTablePrefix + "Towns")]
    public class Town : Entity<int>
    {
        [MaxLength(255)]
        public string Title { get; set; }
        public int TownNo { get; set; }
        public int CityId { get; set; }
        [ForeignKey("CityId")]
        [Required]
        public virtual City City { get; set; }
    }
}
