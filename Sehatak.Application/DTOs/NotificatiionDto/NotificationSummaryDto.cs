

namespace Sehatak.Application.DTOs.NotificatiionDto
{
    public class NotificationSummaryDto
    {
        public int NotificationId { get; set; }
        public string Type { get; set; }
        public string Message {  get; set; }
        public bool isRead { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
