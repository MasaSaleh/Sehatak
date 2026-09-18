using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sehatak.Application.Common;
using Sehatak.Application.Interfaces.IBillPayment;

namespace Sehatak.API.Controllers.BillPaymentController
{
    [ApiController]
    [Route("[Controller]")]
    public class BillPaymentController : ControllerBase
    {
        private readonly IBillPayment bill;
        public BillPaymentController(IBillPayment bill)
        {
            this.bill = bill;
        }

        [Authorize(Policy = "PatientOnly")]
        [HttpGet("patient-get-appointment-bill/{centerId}")]
        public async Task<IActionResult> AppointmentBillPaymentAsync(int centerId,[FromQuery] PagedRequest request, [FromQuery]int? subPatientId)
        {
            var userId = int.Parse(User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)!.Value);
            var result = await bill.AppointmentsBillPayment(centerId, userId,request,subPatientId);
            return Ok(result);
        }

        [Authorize(Policy = "PatientOnly")]
        [HttpGet("patient-get-lab-bill/{centerId}")]
        public async Task<IActionResult> LabBillPaymentAsync(int centerId, [FromQuery] PagedRequest request, [FromQuery] int? subPatientId)
        {
            var userId = int.Parse(User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)!.Value);
            var result = await bill.LabsBillPayment(centerId, userId, request, subPatientId);
            return Ok(result);
        }

        [Authorize(Policy = "PatientOnly")]
        [HttpGet("patient-get-consultation-bill/{centerId}")]
        public async Task<IActionResult> ConsultationBillPaymentAsync(int centerId, [FromQuery] PagedRequest request, [FromQuery] int? subPatientId)
        {
            var userId = int.Parse(User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)!.Value);
            var result = await bill.ConsultationSBillPayment(centerId, userId, request, subPatientId);
            return Ok(result);
        }
    }
}
