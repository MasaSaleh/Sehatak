

namespace Sehatak.Application.DTOs.MedicalRecordDto
{
    public class MedicalRecordItemResponseDto
    {
        public int Id { get; set; }
        public int ServicePriceId { get; set; }
        public string ServiceName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        
    }
}
