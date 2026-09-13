using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sehatak.Application.DTOs.LabDto
{
    public class ReceptionistLabRequestReponseDto
    {
        public int LabRequestId { get; set; }
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public string? Note { get; set; }
        public decimal TotalPrice { get; set; }
        public string LabStatus { get; set; } = "Pending";
        public List<LabItemResponseDto>? LabItems { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
