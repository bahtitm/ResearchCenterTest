using Application.Features.Cabinets.Commands.CreateCabinet;
using Application.Features.Cabinets.Commands.UpdateCabinet;
using Application.Features.Cabinets.Dtos;

namespace Application.Features.Cabinets.MappingProfile
{
    internal class CabinetMappingProfile : Profile
    {
        public CabinetMappingProfile()
        {
            CreateMap<CreateCabinetCommand, Cabinet>();
            CreateMap<UpdateCabinetCommand, Cabinet>();
            CreateMap<Cabinet, CabinetDto>();

        }
    }
}