namespace Persons.Common.Dtos
{
    public class PersonDto : BaseDto
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Phone { get; set; }

        public int CompanyId { get; set; }
    }
}
