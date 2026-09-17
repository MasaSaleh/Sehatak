

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Sehatak.Application.DTOs.Exceptions;
using Sehatak.Application.Interfaces.ICheckTime;
using Sehatak.Domain.Enums;
using Sehatak.Domain.Enums.SharedEnums;
using Sehatak.Infrastructure.Data;

namespace Sehatak.Infrastructure.Services.CheckTimeService
{
    public class CheckTimeService : ICheckTime
    {
        private readonly SharedDbContext sharedDbContext;
        private readonly TenantDbContextFactory contextFactory;
        public CheckTimeService(SharedDbContext sharedDbContext, TenantDbContextFactory contextFactory)
        {
            this.sharedDbContext = sharedDbContext;
            this.contextFactory = contextFactory;
        }

        public async Task<string> FinishAppointmentTime(int centerId, int userId, int appointmentId)
        {
            var center = await sharedDbContext.MedicalCenters
                .FirstOrDefaultAsync(c => c.Id == centerId
                         && c.CenterStatus == CenterStatus.Active);

            if (center == null)
                throw new BusinessException("Center.NotFound");

            using var db = contextFactory.CreateForCenter(centerId);

            var doctor = await db.Doctors
                .Include(u=>u.user)
                .FirstOrDefaultAsync(u => u.userId == userId
                                     && u.user.isActive);

            if (doctor == null)
                throw new BusinessException("Doctor.NotFound");

            var appointment = await db.Appointments
                .FirstOrDefaultAsync(a => a.Id == appointmentId
                                     && a.doctorId == doctor.Id
                                     && a.appointmentStatus == AppointmentStatus.Confirmed);

            if (appointment.actualStartTime == null)
                throw new BusinessException("Appointment.NotStartedYet");

            if (appointment.actualEndTime != null)
                throw new BusinessException("Appointment.AlreadyFinished");

            appointment.actualEndTime = DateTime.UtcNow;
            appointment.appointmentStatus = AppointmentStatus.Completed;
            await db.SaveChangesAsync();

            return appointment.appointmentStatus.ToString();

        }

        public async Task<string> NextPatient(int centerId, int userId, int appointmentId)
        {
            var center = await sharedDbContext.MedicalCenters
                .FirstOrDefaultAsync(c => c.Id == centerId
                         && c.CenterStatus == CenterStatus.Active);

            if (center == null)
                throw new BusinessException("Center.NotFound");

            using var db = contextFactory.CreateForCenter(centerId);

            var user = await db.Users
                .FirstOrDefaultAsync(u => u.Id == userId
                                     && u.isActive);

            if (user == null)
                throw new BusinessException("User.NotFound");

            var appointment = await db.Appointments
                .FirstOrDefaultAsync(a => a.Id == appointmentId
                                     && a.appointmentStatus == AppointmentStatus.Confirmed);

            if (appointment == null)
                throw new BusinessException("Appointment.NotFound");

            if (appointment.actualStartTime != null)
                throw new BusinessException("Appointment.AlreadyStarted");

            appointment.actualStartTime = DateTime.UtcNow;
            appointment.appointmentStatus = AppointmentStatus.InProgress;
            await db.SaveChangesAsync();

            return appointment.appointmentStatus.ToString();

        }

        public async Task<string> ReceptionistCheckInAppointmentAsync(int centerId, int userId, int appointmentId)
        {
            var center = await sharedDbContext.MedicalCenters
                .FirstOrDefaultAsync(c => c.Id == centerId
                                     && c.CenterStatus == CenterStatus.Active);

            if (center == null)
                throw new BusinessException("Center.NotFound");

            using var db = contextFactory.CreateForCenter(centerId);

            var user = await db.Users
                .FirstOrDefaultAsync(u => u.Id == userId
                                     && u.isActive);

            if (user == null)
                throw new BusinessException("User.NotFound");

            var appointment = await db.Appointments
                .FirstOrDefaultAsync(a => a.Id == appointmentId
                                     && a.appointmentStatus == AppointmentStatus.Confirmed);

            if (appointment == null)
                throw new BusinessException("Appointment.NotFound");

            if (appointment.CheckInTime != null)
                throw new BusinessException("Appointment.AlreadyCheckedIn");

            appointment.CheckInTime = DateTime.UtcNow;
            await db.SaveChangesAsync();

            return "تم تسجيل وصول المريض.";
        }
    }
}
