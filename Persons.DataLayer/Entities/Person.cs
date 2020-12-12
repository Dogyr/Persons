using System.ComponentModel.DataAnnotations.Schema;

namespace Persons.DataLayer.Entities
{
    [Table(nameof(Person))]
    public class Person
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Phone { get; set; }

        public Passport Passport { get; set; }

        public int CompanyId { get; set; }

        [ForeignKey(nameof(CompanyId))]
        public Company Company { get; set; }
    }
}
