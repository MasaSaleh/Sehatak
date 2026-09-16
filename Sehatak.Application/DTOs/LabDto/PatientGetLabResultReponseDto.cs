

namespace Sehatak.Application.DTOs.LabDto
{
    public class PatientGetLabResultReponseDto
    {
        public int LabRequestId { get; set; }
        public List<LabResultItemResponseDto> labResultItem { get; set; }
    }
}
