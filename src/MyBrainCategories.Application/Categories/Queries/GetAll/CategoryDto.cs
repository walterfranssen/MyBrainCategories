using MyBrainCategories.Domain.Entities;
using System;
using System.Linq.Expressions;

namespace MyBrainCategories.Application.Categories.Queries.GetAll
{
    public class CategoryDto
    {
        public static Expression<Func<Category, CategoryDto>> Projecten
        {
            get {
                return c => new CategoryDto {
                    Id = c.Id,
                    Name = c.Name
                };
            }
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
