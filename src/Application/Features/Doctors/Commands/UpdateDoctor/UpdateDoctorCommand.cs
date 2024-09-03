using Application.Features.Doctors.Dtos;

namespace Application.Features.Doctors.Commands.UpdateDoctor
{
    public class UpdateDoctorCommand : IRequest<DoctorDto>
    {
        public uint Id { get; set; }
        public string? FIO { get; set; }
    }
}
