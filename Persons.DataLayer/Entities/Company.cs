using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Persons.DataLayer.Entities
{
    [Table(nameof(Company))]
    public class Company
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Person> Persons { get; set; }
    }
}
