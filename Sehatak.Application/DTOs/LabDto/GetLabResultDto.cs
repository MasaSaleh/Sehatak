

namespace Sehatak.Application.DTOs.LabDto
{
    public class GetLabResultDto
    {
        public int LabRequestId {  get; set; }
        public int PatientId { get; set; }
        public int? AppointmentId { get; set; }
        public string PatientName { get; set; }
        public string? Note { get; set; }
        public List<LabResultItemResponseDto>? LabItems { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}


