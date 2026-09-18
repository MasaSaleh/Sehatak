

using Sehatak.Application.DTOs.MedicalRecordDto;

namespace Sehatak.Application.DTOs.BillPaymentDto
{
    public class AppointmentBillPaymentResponseDto
    {
        public int? AppointmentId { get; set; }
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public List<MedicalRecordItemResponseDto>? Items { get; set; }
        public int PaymentId { get; set; }
        public string BillPaymentStatus { get; set; } = "Pending";
        public decimal Amount { get; set; }
        public string BillPaymentType { get; set; } = "Appointment";
        public string Method { get; set; } = "Cash";
        public DateTime? PaidAt { get; set; }
    }
}
