

namespace Sehatak.Application.DTOs.LabDto
{
    public class ReceptionistCreateLabRequestDto
    {
        public int PatientId { get; set; }
        public string? Note { get; set; }
        public List<LabRequestItemsSummaryDto>? LabItems { get; set; }
    }
}
