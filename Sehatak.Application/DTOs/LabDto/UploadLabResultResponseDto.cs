

using Microsoft.AspNetCore.Http;

namespace Sehatak.Application.DTOs.LabDto
{
    public class UploadLabResultResponseDto
    {
        public int LabRequestId { get; set; }
        public List<int> LabRequestItemId { get; set; }
        public List<decimal> ResultValue { get; set; }
    }
}
