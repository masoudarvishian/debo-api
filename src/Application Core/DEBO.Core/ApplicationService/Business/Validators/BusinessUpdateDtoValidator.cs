using DEBO.Core.Entity.Business.Dtos;
using FluentValidation;

namespace DEBO.Core.ApplicationService.Business.Validators
{
    public class BusinessUpdateDtoValidator : AbstractValidator<BusinessUpdateDto>
    {
        public BusinessUpdateDtoValidator()
        {
            RuleFor(x => x.Title)
                .NotNull()
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(200)
                .WithName("عنوان");
        }
    }
}
