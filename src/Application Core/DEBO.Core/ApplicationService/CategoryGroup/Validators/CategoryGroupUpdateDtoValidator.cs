using DEBO.Core.Entity.CategoryGroup.Dtos;
using FluentValidation;

namespace DEBO.Core.ApplicationService.CategoryGroup.Validators
{
    public class CategoryGroupUpdateDtoValidator :
        AbstractValidator<CategoryGroupUpdateDto>
    {
        public CategoryGroupUpdateDtoValidator()
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