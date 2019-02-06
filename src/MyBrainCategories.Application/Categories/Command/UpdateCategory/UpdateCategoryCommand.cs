using MediatR;
using MongoDB.Driver;
using MyBrainCategories.Domain.Entities;
using MyBrainCategories.Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MyBrainCategories.Application.Categories.Command.UpdateCategory
{
    public class UpdateCategoryCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }

    public class UpdateCategoryHandler : IRequestHandler<UpdateCategoryCommand>
    {
        private readonly DataContext dataContext;

        public UpdateCategoryHandler(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        public Task<Unit> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            dataContext.Categories.FindOneAndUpdateAsync(
                Builders<Category>.Filter.Eq(r => r.Id, request.Id),
                Builders<Category>.Update.Set(r => r.Name, request.Name)
                );

            return Task.FromResult(Unit.Value);
        }
    }
}
