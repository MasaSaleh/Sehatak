

namespace Sehatak.Application.DTOs.LabDto
{
    public class LabUploadResultResponseDto
    {
        public int LabRequestId { get; set; }
        public string LabStatus { get; set; }
        public List<LabResultItemResponseDto> LabItems { get; set; }
    }
}
