using MediatR;
using MongoDB.Driver;
using MyBrainCategories.Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MyBrainCategories.Application.Categories.Queries.GetAll
{
    public class GetAllHandler : IRequestHandler<GetAllQuery, IEnumerable<CategoryDto>>
    {
        private readonly DataContext dataContext;

        public GetAllHandler(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        public Task<IEnumerable<CategoryDto>> Handle(GetAllQuery request, CancellationToken cancellationToken)
        {
            var list = dataContext.Categories.AsQueryable().Select(CategoryDto.Projecten).ToList();
            return Task.FromResult(list as IEnumerable<CategoryDto>);
        }
    }
}
