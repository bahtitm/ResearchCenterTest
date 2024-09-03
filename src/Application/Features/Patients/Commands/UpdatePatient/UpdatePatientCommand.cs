using Application.Features.Patients.Dtos;

namespace Application.Features.Patients.Commands.UpdatePatient
{
    public class UpdatePatientCommand : IRequest<PatientDto>
    {
        public uint Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Patronymic { get; set; }
        public string? Address { get; set; }
        public string? BirthDay { get; set; }
        public Gender Gender { get; set; }
    }
}
