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
            CreateMap<Doctor, DoctorDto>()
                 .ForMember(ds => ds.CabinetName, op => op.MapFrom(sr => sr.Cabinet.Name))
                 .ForMember(ds => ds.TerritorialUnitNomber, op => op.MapFrom(sr => sr.TerritorialUnit.Nomber))
                 .ForMember(ds => ds.SpecializationName, op => op.MapFrom(sr => sr.Specialization.Name))

                 ;
        }
    }
}
