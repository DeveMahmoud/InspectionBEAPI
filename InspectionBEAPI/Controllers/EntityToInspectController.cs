using ApplicationLayer.EntityToInspect.Commands;
using ApplicationLayer.EntityToInspect.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InspectionBEAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class EntityToInspectController : ControllerBase
    {
        private readonly IMediator _mediator;
        public EntityToInspectController(IMediator mediator)
        {
                _mediator= mediator;
        }
        [HttpPost]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([FromBody] CreateEntityToInspectCommand command)
        {
            var id = await _mediator.Send(command);
            return Ok(new { Id = id });
        }


        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateEntityToInspectCommand command)
        {
            if (id != command.Id)
                return BadRequest("Id in URL does not match Id in body.");

            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllEntitiesQuery());
            return Ok(result);
        }
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetEntityToInspectByIdQuery { Id = id });

            if (result == null)
                return NotFound();

            return Ok(result);
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteEntityCommand { Id = id });

            if (!result)
                return NotFound();

            return NoContent();
        }


    }
}
