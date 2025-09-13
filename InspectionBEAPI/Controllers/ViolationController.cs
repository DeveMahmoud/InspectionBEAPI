using ApplicationLayer.Violation.Commands;
using ApplicationLayer.Violation.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InspectionBEAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ViolationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ViolationController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
       // [Authorize(Roles = "Inspector")]
        public async Task<IActionResult> Create(CreateViolationCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result); 
        }
        [HttpGet("{id}")]
        //[Authorize(Roles = "Admin,Inspector")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetViolationByIdQuery { Id = id });
            return Ok(result);
        }
    }
}
