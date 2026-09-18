

using Sehatak.Application.DTOs.MedicalRecordDto;

namespace Sehatak.Application.DTOs.BillPaymentDto
{
    public class ConsultationBillPaymentResponseDto
    {
        public int? ConsultaionId { get; set; }
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public int PaymentId { get; set; }
        public string BillPaymentStatus { get; set; } = "Pending";
        public decimal Amount { get; set; }
        public string BillPaymentType { get; set; } = "Consultation";
        public string Method { get; set; } = "Online";
        public DateTime? PaidAt { get; set; }
    }
}
