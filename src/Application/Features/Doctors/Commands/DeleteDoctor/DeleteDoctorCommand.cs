namespace Application.Features.Doctors.Commands.DeleteDoctor
{
    public record DeleteDoctorCommand(uint id) : IRequest;
}
