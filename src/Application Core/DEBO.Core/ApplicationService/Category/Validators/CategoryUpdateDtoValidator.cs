using DEBO.Core.Entity.Category.Dtos;
using FluentValidation;

namespace DEBO.Core.ApplicationService.Category.Validators
{
    public class CategoryUpdateDtoValidator :
        AbstractValidator<CategoryUpdateDto>
    {
        public CategoryUpdateDtoValidator()
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