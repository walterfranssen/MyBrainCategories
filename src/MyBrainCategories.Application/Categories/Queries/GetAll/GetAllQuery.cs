using MediatR;
using System.Collections.Generic;

namespace MyBrainCategories.Application.Categories.Queries.GetAll
{
    public class GetAllQuery : IRequest<IEnumerable<CategoryDto>>
    {
    }
}
