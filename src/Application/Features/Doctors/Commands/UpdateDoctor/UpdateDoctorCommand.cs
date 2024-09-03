using Application.Features.Doctors.Dtos;

namespace Application.Features.Doctors.Commands.UpdateDoctor
{
    public class UpdateDoctorCommand : IRequest<DoctorDto>
    {
        public uint Id { get; set; }       
        public uint CabinetId { get; set; }       
        public uint SpecializationId { get; set; }
        public uint TerritorialUnitId { get; set; }
        
    }
}
