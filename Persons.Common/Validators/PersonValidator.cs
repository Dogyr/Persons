using FluentValidation;
using Persons.Common.Dtos;
using Persons.Common.Interfaces;
using System.Threading.Tasks;

namespace Persons.Common.Validators
{
    public class PersonValidator : AbstractValidator<PersonDto>
    {
        public PersonValidator(ICrudRepository<CompanyDto> repository)
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.Surname)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.Phone)
                .Matches("^[0-9]+$")
                .MaximumLength(15);

            RuleFor(x => x)
                .MustAsync((x, c) => IsCompanyExistsAsync(x, repository))
                .WithMessage("Компания с таким id не существует");
        }

        private async Task<bool> IsCompanyExistsAsync(PersonDto dto, ICrudRepository<CompanyDto> repository)
        {
            var result = await repository.FindByIdAsync(dto.CompanyId);
            return result != null;
        }
    }
}
