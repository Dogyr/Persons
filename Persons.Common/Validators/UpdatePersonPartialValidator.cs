using FluentValidation;
using Persons.Common.Dtos;
using Persons.Common.Interfaces;
using System.Threading.Tasks;

namespace Persons.Common.Validators
{
    public class UpdatePersonPartialValidator : AbstractValidator<UpdatePersonDto>
    {
        public UpdatePersonPartialValidator(ICrudRepository<CompanyDto> repository)
        {
            RuleFor(x => x.Name)
                .MaximumLength(100);

            RuleFor(x => x.Surname)
                .MaximumLength(100);

            RuleFor(x => x.Phone)
                .MaximumLength(12);

            RuleFor(x => x.CompanyId)
                .MustAsync((x, c) => IsCompanyExistsAsync(x, repository))
                .WithMessage("Компания с таким id не существует")
                .When(x => x.CompanyId.HasValue);
        }

        private async Task<bool> IsCompanyExistsAsync(int? companyId, ICrudRepository<CompanyDto> repository)
        {
            var result = await repository.FindByIdAsync(companyId.HasValue ? companyId.Value : default);
            return result != null;
        }
    }
}
