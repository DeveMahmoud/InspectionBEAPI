using ApplicationLayer.InspectionVisit.Commands;
using ApplicationLayer.InspectionVisit.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InspectionBEAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]

    public class InspectionVisitsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public InspectionVisitsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([FromBody] CreateInspectionVisitCommand command)
        {
            if (command == null)
                return BadRequest("Invalid data.");

            var id = await _mediator.Send(command);

            return Ok(new { Id = id, Message = "Inspection Visit created successfully" });
        }
        [Authorize(Roles = "Admin,Inspector")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateInspectionVisitCommand command)
        {
            if (id != command.Id)
                return BadRequest("Id in URL and body do not match.");

            var result = await _mediator.Send(command);

            if (!result)
                return NotFound(new { Message = $"Inspection Visit with Id {id} not found." });

            return Ok(new { Message = "Inspection Visit updated successfully" });
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllInspectionVisitsQuery();
            var result = await _mediator.Send(query);

            if (result == null || !result.Any())
                return NotFound(new { Message = "No inspection visits found." });

            return Ok(result);
        }
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,Inspector")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetInspectionVisitByIdQuery(id);
            var result = await _mediator.Send(query);

            if (result == null)
                return NotFound(new { Message = $"Inspection visit with Id {id} not found." });

            return Ok(result);
        }
        [HttpGet("GetCurrentInspectorVisitsByUser")]
        [Authorize(Roles = "Inspector")]
        public async Task<IActionResult> GetCurrentInspectorVisitsByUser()
        {
            var query = new GetInspectionVisitsForCurrentInspectorQuery();
            var result = await _mediator.Send(query);

            if (result == null || !result.Any())
                return NotFound(new { Message = "No inspection visits found for this inspector." });

            return Ok(result);
        }



    }
}
