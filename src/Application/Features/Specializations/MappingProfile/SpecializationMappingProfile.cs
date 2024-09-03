using Application.Features.Specializations.Commands.CreateSpecialization;
using Application.Features.Specializations.Commands.UpdateSpecialization;
using Application.Features.Specializations.Dtos;

namespace Application.Features.Specializations.MappingProfile
{
    internal class SpecializationMappingProfile : Profile
    {
        public SpecializationMappingProfile()
        {
            CreateMap<CreateSpecializationCommand, Specialization>();
            CreateMap<UpdateSpecializationCommand, Specialization>();
            CreateMap<Specialization, SpecializationDto>();
        }
    }
}
