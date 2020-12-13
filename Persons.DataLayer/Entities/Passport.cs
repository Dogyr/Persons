using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Persons.DataLayer.Entities
{
    [Table(nameof(Passport))]
    public class Passport : BaseEntity
    {
        [MaxLength(50)]
        public string Type { get; set; }

        [MaxLength(20)]
        public string Number { get; set; }

        [Required]
        public int PersonId { get; set; }

        [ForeignKey(nameof(PersonId))]
        public Person Person { get; set; }
    }
}
