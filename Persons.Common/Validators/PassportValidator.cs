using FluentValidation;
using Persons.Common.Dtos;
using Persons.Common.Interfaces;
using System.Threading.Tasks;

namespace Persons.Common.Validators
{
    public class PassportValidator : AbstractValidator<PassportDto>
    {
        public PassportValidator(ICrudRepository<PersonDto> repository)
        {
            RuleFor(x => x.Type)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(x => x.Number)
                .NotEmpty()
                .MaximumLength(20);

            RuleFor(x => x)
                .MustAsync((x, c) => IsPersonExistsAsync(x, repository))
                .WithMessage("Сотрудник с таким id не существует");
        }

        private async Task<bool> IsPersonExistsAsync(PassportDto dto, ICrudRepository<PersonDto> repository)
        {
            var result = await repository.FindByIdAsync(dto.PersonId);
            return result != null;
        }
    }
}
