using MediatR;
using MyBrainCategories.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MyBrainCategories.Application.Categories.Command.CreateCategory
{
    public class CreateCategoryHandler : IRequestHandler<CreateCategoryCommand, Guid>
    {
        private readonly DataContext dataContext;

        public CreateCategoryHandler(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        public async Task<Guid> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = new Domain.Entities.Category
            {
                Id = Guid.NewGuid(),
                Name = request.Name
            };

            await dataContext.Categories.InsertOneAsync(category);
            return category.Id;
        }
    }
}
