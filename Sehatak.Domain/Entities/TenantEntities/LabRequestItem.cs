

namespace Sehatak.Domain.Entities.TenantEntities
{
    public class LabRequestItem
    {
        public int Id { get; set; }

        public int LabRequestId { get; set; }

        public int ServicePriceId { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal? ResultValue { get; set; }
        public string? ResultFileUrl { get; set; }

        // Navigation Properties :
        public LabRequest LabRequest { get; set; } = null!;
        public ServicePrice ServicePrice { get; set; } = null!;
    }
}
