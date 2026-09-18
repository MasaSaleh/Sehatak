

using Sehatak.Application.Common;
using Sehatak.Application.DTOs.BillPaymentDto;

namespace Sehatak.Application.Interfaces.IBillPayment
{
    public interface IBillPayment
    {
        Task<PagedResult<AppointmentBillPaymentResponseDto>> AppointmentsBillPayment(int centerId, int userId,PagedRequest request, int? subPatientId);
        Task<PagedResult<LabBillPaymentResponseDto>> LabsBillPayment(int centerId, int userId, PagedRequest request, int? subPatientId);
        Task<PagedResult<ConsultationBillPaymentResponseDto>> ConsultationSBillPayment(int centerId, int userId, PagedRequest request, int? subPatientId);

    }
}
