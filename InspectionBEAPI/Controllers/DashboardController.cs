using ApplicationLayer.Dashboard;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InspectionBEAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DashboardController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("stats")]
        public async Task<IActionResult> GetStats()
        {
            var result = await _mediator.Send(new GetStatsQuery());
            return Ok(result);
        }

        [HttpGet("chart-data")]
        public async Task<IActionResult> GetChartData()
        {
            var result = await _mediator.Send(new GetChartDataQuery());
            return Ok(result);
        }

        [HttpGet("upcoming-visits")]
        public async Task<IActionResult> GetUpcomingVisits()
        {
            var result = await _mediator.Send(new GetUpcomingVisitsQuery());
            return Ok(result);
        }
    }
}
