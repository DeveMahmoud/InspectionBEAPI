using ApplicationLayer.DTO;
using ApplicationLayer.Inspector.Commands;
using ApplicationLayer.Inspector.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InspectionBEAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InspectorsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public InspectorsController(IMediator mediator)
        {
            _mediator = mediator;
        }
      //  [Authorize(Roles = "Admin")]
        [HttpPost("create")]
        public async Task<IActionResult> CreateInspector([FromBody] CreateInspectorDTO inspectorDto)
        {
            var command = new CreateInspectorCommand(inspectorDto);
            var userId = await _mediator.Send(command);

            return Ok(new { Message = "Inspector created successfully", UserId = userId });
        }

      // [Authorize(Roles = "Admin")]
        [HttpGet("GetAllInspectors")]
        public async Task<IActionResult> GetAllInspectors()
        {
            var query = new GetAllInspectorsQuery();
            var inspectors = await _mediator.Send(query);

            return Ok(inspectors);
        }
    }

}