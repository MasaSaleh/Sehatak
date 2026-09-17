

using Sehatak.Application.DTOs.ConfirmPaymentDto;

namespace Sehatak.Application.Interfaces.IConfirmPayment
{
    public interface IConfirmPayment
    {
        Task<PaymentResponseDto> ReceptionistPayLabRequestAsync(int centerId, int userId,int labRequestId, CollectPaymentRequestDto request);
        Task<PaymentResponseDto> ReceptionistCollectAppointmentPaymentAsync(int centerId, int userId, int appointmentId, CollectPaymentRequestDto request);
    }
}
