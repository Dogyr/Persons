using System.ComponentModel.DataAnnotations;

namespace Persons.DataLayer.Entities
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
