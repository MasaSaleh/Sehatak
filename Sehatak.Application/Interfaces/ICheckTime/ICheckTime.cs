

namespace Sehatak.Application.Interfaces.ICheckTime
{
    public interface ICheckTime
    {
        Task<string> ReceptionistCheckInAppointmentAsync(int centerId, int userId, int appointmentId);
        Task<string> NextPatient(int centerId, int userId, int appointmentId);
        Task<string> FinishAppointmentTime(int centerId, int userId, int appointmentId);
    }
}
