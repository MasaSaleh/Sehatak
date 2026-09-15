

namespace Sehatak.Application.DTOs.LabDto
{
    public class LabGetRequestResponseDto
    {
        public int LabRequestId { get; set; }
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public string? Note { get; set; }
        public decimal TotalPrice { get; set; }
        public string LabStatus { get; set; } = "Pending";
        public List<LabItemResponseDto>? LabItems { get; set; }
    }
}
