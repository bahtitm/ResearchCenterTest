using Application.Features.Patients.Commands.CreatePatient;
using Application.Features.Patients.Commands.UpdatePatient;
using Application.Features.Patients.Dtos;

namespace Application.Features.Patients.MappingProfile
{
    internal class PatientMappingProfile : Profile
    {
        public PatientMappingProfile()
        {
            CreateMap<CreatePatientCommand, Patient>();
            CreateMap<UpdatePatientCommand, Patient>();
            CreateMap<Patient, PatientDto>()
                .ForMember(ds=>ds.TerritorialUnitNumber, op=>op.MapFrom(sr=>sr.TerritorialUnit.Nomber));
            CreateMap<Patient, PatientDetailDto>();

        }
    }
}
