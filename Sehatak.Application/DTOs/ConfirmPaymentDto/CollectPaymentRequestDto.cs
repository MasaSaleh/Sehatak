using Sehatak.Domain.Enums.PaymentEnums;


namespace Sehatak.Application.DTOs.ConfirmPaymentDto
{
    public class CollectPaymentRequestDto
    {
        public PaymentMethod Method { get; set; }
        public string? Note { get; set; }
    }
}
