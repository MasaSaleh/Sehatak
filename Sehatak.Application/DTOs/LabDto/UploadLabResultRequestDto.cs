

using Microsoft.AspNetCore.Http;

namespace Sehatak.Application.DTOs.LabDto
{
    public class UploadLabResultRequestDto
    {
        public int LabRequestId { get; set; }
        public List<LabResultItemDto> Results { get; set; }
    }
}
