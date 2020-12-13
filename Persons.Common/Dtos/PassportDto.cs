namespace Persons.Common.Dtos
{
    public class PassportDto : BaseDto
    {
        public string Type { get; set; }

        public string Number { get; set; }

        public int PersonId { get; set; }
    }
}
