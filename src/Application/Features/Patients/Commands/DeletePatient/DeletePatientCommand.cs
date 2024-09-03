namespace Application.Features.Patients.Commands.DeletePatient
{
    public record DeletePatientCommand(uint id) : IRequest;
}
