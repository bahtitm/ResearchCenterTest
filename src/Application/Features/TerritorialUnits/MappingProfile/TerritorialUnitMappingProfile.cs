using Application.Features.TerritorialUnits.Commands.CreateTerritorialUnit;
using Application.Features.TerritorialUnits.Commands.UpdateTerritorialUnit;
using Application.Features.TerritorialUnits.Dtos;

namespace Application.Features.TerritorialUnits.MappingProfile
{
    internal class TerritorialUnitMappingProfile : Profile
    {
        public TerritorialUnitMappingProfile()
        {
            CreateMap<CreateTerritorialUnitCommand, TerritorialUnit>();
            CreateMap<UpdateTerritorialUnitCommand, TerritorialUnit>();
            CreateMap<TerritorialUnit, TerritorialUnitDto>();
        }
    }
}
