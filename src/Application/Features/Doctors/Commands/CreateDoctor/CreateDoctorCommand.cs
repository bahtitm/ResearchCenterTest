using Application.Features.Doctors.Dtos;

namespace Application.Features.Doctors.Commands.CreateDoctor
{
    public class CreateDoctorCommand : IRequest<DoctorDto>
    {
        public string? FIO { get; set; }
    }
}
