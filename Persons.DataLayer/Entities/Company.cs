using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Persons.DataLayer.Entities
{
    [Table(nameof(Company))]
    public class Company : BaseEntity
    {
        [MaxLength(100)]
        public string Name { get; set; }

        public List<Person> Persons { get; set; }
    }
}
