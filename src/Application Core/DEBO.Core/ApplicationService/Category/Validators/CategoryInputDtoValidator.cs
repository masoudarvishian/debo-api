using DEBO.Core.Entity.Category.Dtos;
using FluentValidation;

namespace DEBO.Core.ApplicationService.Category.Validators
{
    public class CategoryInputDtoValidator : AbstractValidator<CategoryInputDto>
    {
        public CategoryInputDtoValidator()
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