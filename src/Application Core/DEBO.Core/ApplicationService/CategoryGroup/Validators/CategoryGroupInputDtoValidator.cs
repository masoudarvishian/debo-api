using DEBO.Core.Entity.Category.Dtos;
using FluentValidation;

namespace DEBO.Core.ApplicationService.CategoryGroup.Validators
{
    public class CategoryGroupInputDtoValidator :
        AbstractValidator<CategoryInputDto>
    {
        public CategoryGroupInputDtoValidator()
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