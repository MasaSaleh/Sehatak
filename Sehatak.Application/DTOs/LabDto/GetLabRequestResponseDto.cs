namespace Sehatak.Application.DTOs.LabDto
{
    public class GetLabRequestResponseDto
    {
        public int LabRequestId { get; set; }
        public string? Note { get; set; }
        public string LabStatus { get; set; } = "Pending";
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
