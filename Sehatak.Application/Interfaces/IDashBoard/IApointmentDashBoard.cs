using Sehatak.Application.Common;
using Sehatak.Application.DTOs.DashBoardDto;

namespace Sehatak.Application.Interfaces.IDashBoard
{
    public interface IApointmentDashBoard
    {
        Task<AppointmentsSummaryDto> GetCenterAppointmentsSummaryAsync(int centerId, DateOnly? date = null);
        Task<PagedResult<ReceptionistAppointmentResponseDto>> GetReceptionistAppointmentsAsync(int centerId, int userId, DateOnly date, PagedRequest request);
    }
}
