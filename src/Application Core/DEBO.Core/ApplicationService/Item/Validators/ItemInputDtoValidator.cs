using FluentValidation;

namespace DEBO.Core.ApplicationService.Item.Validators
{
    using Entity.Item;
    public class ItemInputDtoValidator : AbstractValidator<Item>
    {
        public ItemInputDtoValidator()
        {
            RuleFor(x => x.Title)
                .NotNull()
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(200)
                .WithName("عنوان");

            RuleFor(x => x.Description)
               .MinimumLength(2)
               .MaximumLength(500)
               .WithName("توضیحات");

            RuleFor(x => x.IsExist).NotNull().NotEmpty();

            RuleFor(x => x.Price).Must(x => x >= 0);

            RuleFor(x => x.BusinessId).NotNull().NotEmpty().Must(x => x > 0);
            RuleFor(x => x.CategoryId).NotNull().NotEmpty().Must(x => x > 0);
        }
    }
}
