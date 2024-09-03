using Application.Features.Doctors.Commands.CreateDoctor;
using Application.Features.Doctors.Commands.UpdateDoctor;
using Application.Features.Doctors.Dtos;

namespace Application.Features.Doctors.MappingProfile
{
    internal class DoctorMappingProfile : Profile
    {
        public DoctorMappingProfile()
        {
            CreateMap<CreateDoctorCommand, Doctor>();
            CreateMap<UpdateDoctorCommand, Doctor>();
            CreateMap<Doctor, DoctorDto>();
        }
    }
}
