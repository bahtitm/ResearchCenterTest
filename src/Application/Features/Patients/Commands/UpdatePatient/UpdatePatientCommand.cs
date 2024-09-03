using Application.Features.Patients.Dtos;

namespace Application.Features.Patients.Commands.UpdatePatient
{
    public class UpdatePatientCommand : IRequest<PatientDto>
    {
        public uint Id { get; set; }
        public uint TerritorialUnitId { get; set; }

    }
}
