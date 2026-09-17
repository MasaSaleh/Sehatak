using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sehatak.Application.DTOs.ConfirmPaymentDto;
using Sehatak.Application.Interfaces.IConfirmPayment;

namespace Sehatak.API.Controllers.ConfirmPaymentController
{
    [ApiController]
    [Route("[Controller]")]
    public class ConfirmPaymentController : ControllerBase
    {
        private readonly IConfirmPayment payment;
        public ConfirmPaymentController(IConfirmPayment payment)
        {
            this.payment = payment;
        }
        [Authorize(Policy = "ReceptionistOnly")]
        [HttpPost("receptionist-lab-paid/{centerId}/{labRequestId}")]
        public async Task<IActionResult> LabPaymentAsync(int centerId , int labRequestId , [FromBody] CollectPaymentRequestDto request)
        {
            var userId = int.Parse(User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)!.Value);
            var result = await payment.ReceptionistPayLabRequestAsync(centerId, userId,labRequestId, request);
            return Ok(result);
        }
    }
}
