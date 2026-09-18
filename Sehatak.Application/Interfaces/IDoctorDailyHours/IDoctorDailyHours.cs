using Sehatak.Application.Common;
using Sehatak.Application.DTOs.AddDoctorDailyHour;
using Sehatak.Application.DTOs.AddDoctorDailyHourDto;
using Sehatak.Application.DTOs.DoctorDailyHourDto;
using Sehatak.Application.DTOs.DoctorDto;

namespace Sehatak.Application.Interfaces.AddDoctorDailyHours
{
    public interface IDoctorDailyHours
    {
        Task<AddDoctorDailyHoursResponse> AddDoctorDailyHoursAsync(int centerId , int userId , int doctorId ,AddDoctorDailyHoursRequest request);
        Task<UpdateDoctorDailyHoursResponse> UpdateDoctorDailyHoursAsync(int centerId, int userId, int doctorId, UpdateDoctorDailyHousrRequest request);
        Task<string> CancleDailyHoursAsync(int centerId, int doctorId, DateOnly date);
        Task<PagedResult<GetDoctorDailyHoursResponse>> GetDoctorDailyHoursAsync(int centerId, int doctorId, PagedRequest request);
        Task<DoctorAppointmentResponse> GetDoctorAppointmentsForDayAsync(int centerId, int userId, DateOnly? date);
        Task<PagedResult<GetDoctorsBlockDaysResponseDto>> GetDoctorsBlockDayAsync(int centerId, int userId, DateOnly date,PagedRequest request);
        Task<PagedResult<GetDoctorsBlockDaysResponseDto>> DoctorGetBlokDays(int centerId, int userId, DateOnly date, PagedRequest request);
    }
}
