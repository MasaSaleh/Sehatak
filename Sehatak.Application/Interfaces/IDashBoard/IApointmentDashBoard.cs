using Sehatak.Application.Common;
using Sehatak.Application.DTOs.DashBoardDto;
using Sehatak.Domain.Enums;

namespace Sehatak.Application.Interfaces.IDashBoard
{
    public interface IApointmentDashBoard
    {
        Task<AppointmentsSummaryDto> GetCenterAppointmentsSummaryAsync(int centerId, DateOnly? date = null);
        Task<PagedResult<ReceptionistAppointmentResponseDto>> GetReceptionistAppointmentsAsync(int centerId, int userId, DateOnly date, PagedRequest request);
        Task<PagedResult<PatientsAppointmentResponseDto>> GetPatientAppointmentsAsync(int centerId, int userId, DateOnly date,int? subPatientId, PagedRequest request,AppointmentStatus status);

    }
}
