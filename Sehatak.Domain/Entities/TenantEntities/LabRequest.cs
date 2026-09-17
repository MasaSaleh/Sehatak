using Sehatak.Domain.Enums;

namespace Sehatak.Domain.Entities.TenantEntities
{
    public class LabRequest
    {
        public int Id { get; set; }
        public int? DoctorId { get; set; }
        public int PatientId { get; set; }
        public int RequestedByUserId { get; set; }
        public int? AppointmentId { get; set; }
        public string? Notes { get; set; }
        public LabRequestStatus Status { get; set; } = LabRequestStatus.Pending;
        public DateTime RequstedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; }

        // Navigation Properties :
        public Doctor Doctor { get; set; } = null!;
        public Patient Patient { get; set; } = null!;
        public User RequestedByUser { get; set; } = null!;
        public Appointment? Appointment { get; set; }
        public LabResult? LabResult { get; set; }
        public Payment? Payment { get; set; }
        public ICollection<LabRequestItem> Items { get; set; } = new List<LabRequestItem>();


    }
}
