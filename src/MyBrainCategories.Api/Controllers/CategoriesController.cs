using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyBrainCategories.Application.Categories.Command.CreateCategory;
using MyBrainCategories.Application.Categories.Command.UpdateCategory;
using MyBrainCategories.Application.Categories.Queries.GetAll;
using MyBrainCategories.Application.Categories.Queries.GetById;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyBrainCategories.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator mediator;

        public CategoriesController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        // GET: api/<controller>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CategoryDto>),200)]
        public async Task<IActionResult> Get()
        {
            return new JsonResult(await mediator.Send(new GetAllQuery()));
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(CategoryDto),200)]
        public async Task<IActionResult> GetById(Guid id)
        {
            return new JsonResult(await mediator.Send(new GetByIdQuery(id)));
        }

        // POST api/<controller>
        [HttpPost]
        [ProducesResponseType(201)]
        public async Task<IActionResult> Post(CreateCategoryCommand command)
        {
            var categoryId = await mediator.Send(command);
            return CreatedAtAction(nameof(GetById), "Categories", new { id = categoryId }, categoryId);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        public async Task<IActionResult> Put(Guid id, UpdateCategoryCommand command)
        {
            await mediator.Send(command);
            return NoContent();
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(500)]
        public IActionResult Delete(Guid id)
        {
            return new StatusCodeResult(500);
            
        }
    }
}
