using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReportCreator.Application.Apps;
using ReportCreator.Domain.DTOs.Requests.Base;

namespace ReportCreator.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {

        [HttpGet("pagination")]
        public IActionResult GetReports([FromBody] RequestPaginationBaseDTO pagination)
        {
            var paginationApp = new ReportPaginationApp();
            var paginationResponse = paginationApp.Paginate<object>(pagination);

            return Ok(new { message = "Reports retrieved successfully.", data = paginationResponse });
        }

        [HttpPost]
        public IActionResult CreateReport([FromBody] RequestReportBaseDTO reportBase)
        {
            var reportApp = new ReportApp();

            reportApp.RegisterReport(reportRequest: reportBase);

            return Created();
        }
    }
}
