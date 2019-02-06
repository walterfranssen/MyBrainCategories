using MediatR;
using System;

namespace MyBrainCategories.Application.Categories.Command.CreateCategory
{
    public class CreateCategoryCommand : IRequest<Guid>
    {
        public string Name { get; set; }
    }
}
