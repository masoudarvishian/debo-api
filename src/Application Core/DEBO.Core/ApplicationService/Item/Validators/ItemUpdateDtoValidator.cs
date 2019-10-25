namespace DEBO.Core.ApplicationService.Item.Validators
{
    using Entity.Item;
    using FluentValidation;

    public class ItemUpdateDtoValidator : AbstractValidator<Item>
    {
        public ItemUpdateDtoValidator()
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
