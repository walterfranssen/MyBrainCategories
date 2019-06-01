using FluentValidation;

namespace MyBrainCategories.Application.Categories.Command.CreateCategory
{
    public class CreateCategoryValidation : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryValidation()
        {
            this.RuleFor(x => x.Name).NotEmpty();
        }
    }
}
