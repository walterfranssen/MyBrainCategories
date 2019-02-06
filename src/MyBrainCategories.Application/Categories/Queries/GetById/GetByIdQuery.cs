using MediatR;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using MyBrainCategories.Application.Categories.Queries.GetAll;
using MyBrainCategories.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyBrainCategories.Application.Categories.Queries.GetById
{
    public class GetByIdQuery : IRequest<CategoryDto>
    {
        public GetByIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }

    public class GetByIdHandler : IRequestHandler<GetByIdQuery, CategoryDto>
    {
        private readonly DataContext dataContext;

        public GetByIdHandler(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        public async  Task<CategoryDto> Handle(GetByIdQuery request, CancellationToken cancellationToken)
        {
            var category = await dataContext.Categories.AsQueryable()
                    .Where(x => x.Id == request.Id)
                    .FirstOrDefaultAsync(cancellationToken);

            return new CategoryDto { Id = category.Id, Name = category.Name };
        }
    }
}
