

using Microsoft.AspNetCore.Http;

namespace Sehatak.Application.DTOs.LabDto
{
    public class LabResultItemDto
    {
        public int LabRequestItemId { get; set; }
        public decimal ResultValue { get; set; }
        public IFormFile? ResultFileUrl { get; set; }

    }
}
