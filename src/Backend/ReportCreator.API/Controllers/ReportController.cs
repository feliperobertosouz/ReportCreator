using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReportCreator.Application.Apps;
using ReportCreator.Domain.DTOs.Requests;

namespace ReportCreator.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {

        [HttpGet("pagination")]
        public IActionResult GetReports([FromBody] RequestPaginationBase pagination)
        {
            var paginationApp = new ReportPaginationApp();
            var paginationResponse = paginationApp.Paginate<object>(pagination);

            return Ok(new { message = "Reports retrieved successfully.", data = paginationResponse });
        }

        [HttpPost]
        public IActionResult CreateReport([FromBody] RequestReportBase reportBase)
        {
            return Ok(new { message = "Report created successfully.", data = reportBase });
        }
    }
}
