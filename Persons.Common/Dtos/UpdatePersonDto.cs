namespace Persons.Common.Dtos
{
    public class UpdatePersonDto
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Phone { get; set; }

        public int? CompanyId { get; set; }
    }
}
