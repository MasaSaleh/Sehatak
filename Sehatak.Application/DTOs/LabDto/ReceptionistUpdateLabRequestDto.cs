using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sehatak.Application.DTOs.LabDto
{
    public class ReceptionistUpdateLabRequestDto
    {
        public int LabRequestId { get; set; }
        public int PatientId { get; set; }
        public string? Note { get; set; }
        public List<LabRequestItemsSummaryDto>? AddLabItems { get; set; }
        public List<int>? RemoveLabItems { get; set; }
    }
}
