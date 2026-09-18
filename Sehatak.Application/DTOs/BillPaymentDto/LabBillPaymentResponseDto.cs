

using Sehatak.Application.DTOs.LabDto;

namespace Sehatak.Application.DTOs.BillPaymentDto
{
    public class LabBillPaymentResponseDto
    {
        public int? LabId { get; set; }
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public List<LabItemResponseDto>? Items { get; set; }
        public int PaymentId { get; set; }
        public string BillPaymentStatus { get; set; } = "Pending";
        public decimal Amount { get; set; }
        public string BillPaymentType { get; set; } = "Lab";
        public string Method { get; set; } = "Cash";
        public DateTime? PaidAt { get; set; }
    }
}
