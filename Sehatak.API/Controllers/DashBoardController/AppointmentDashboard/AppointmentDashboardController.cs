using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sehatak.Application.Common;
using Sehatak.Application.Interfaces.ApointmentInterface;
using Sehatak.Application.Interfaces.ICheckTime;
using Sehatak.Application.Interfaces.IDashBoard;
using Sehatak.Domain.Enums;
using Sehatak.Infrastructure.Services.AppointmentService;

namespace Sehatak.API.Controllers.DashBoard.AppointmentDashboard
{
    [ApiController]
    [Route("[Controller]")]
    public class AppointmentDashboardController : ControllerBase
    {
        private readonly IApointmentDashBoard dash;
        public AppointmentDashboardController(IApointmentDashBoard dash)
        {
            this.dash = dash;
        }
        [Authorize(Policy = "AdminOnly")]
        [HttpGet("appointments-summary/{centerId}")]
        public async Task<IActionResult> GetCenterAppointmentsSummary(int centerId, [FromQuery] DateOnly? date)
        {
            var result = await dash.GetCenterAppointmentsSummaryAsync(centerId, date);
            return Ok(result);
        }

        [Authorize(Policy = "ReceptionistOnly")]
        [HttpGet("receptionist-appointment-dashboard/{centerId}")]
        public async Task<IActionResult> ReceptionistAppointmentDashBoard(int centerId, [FromQuery] DateOnly date,[FromQuery] PagedRequest request)
        {
            var userId = int.Parse(User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)!.Value);
            var result = await dash.GetReceptionistAppointmentsAsync(centerId,userId,date,request);
            return Ok(result);
        }

        [Authorize(Policy = "PatientOnly")]
        [HttpGet("patient-appointment-dashboard/{centerId}")]
        public async Task<IActionResult> PatientAppointmentDashBoard(int centerId, [FromQuery] DateOnly date,int? subPatientId, [FromQuery] PagedRequest request, [FromQuery] AppointmentStatus status)
        {
            var userId = int.Parse(User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)!.Value);
            var result = await dash.GetPatientAppointmentsAsync(centerId, userId, date,subPatientId, request,status);
            return Ok(result);
        }
    }
}
