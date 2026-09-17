using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sehatak.Application.Interfaces.ICheckTime;

namespace Sehatak.API.Controllers.CheckTimeController
{
    [ApiController]
    [Route("[Controller]")]
    public class CheckTimeController : ControllerBase
    {
        private readonly ICheckTime checkTime;
        public CheckTimeController(ICheckTime checkTime)
        {
            this.checkTime = checkTime;
        }

        [Authorize(Policy = "ReceptionistOnly")]
        [HttpPut("receptionist-checkIn-patient/{centerId}/{appointmentId}")]
        public async Task<IActionResult> CheckInPatient(int centerId, int appointmentId)
        {
            var userId = int.Parse(User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)!.Value);
            var result = await checkTime.ReceptionistCheckInAppointmentAsync(centerId, userId, appointmentId);
            return Ok(result);
        }

        [Authorize(Policy = "DoctorOnly")]
        [HttpPut("doctor-finish-appointment-time/{centerId}/{appointmentId}")]
        public async Task<IActionResult> FinishAppointmentTimeAsync(int centerId , int appointmentId)
        {
            var userId = int.Parse(User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)!.Value);
            var result = await checkTime.FinishAppointmentTime(centerId,userId,appointmentId);
            return Ok(result);
        }

        [Authorize(Policy = "ReceptionistOnly")]
        [HttpPut("receptionist-next-patient/{centerId}/{appointmentId}")]
        public async Task<IActionResult> NextPatientAsync(int centerId, int appointmentId)
        {
            var userId = int.Parse(User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)!.Value);
            var result = await checkTime.NextPatient(centerId, userId, appointmentId);
            return Ok(result);
        }


    }
}
