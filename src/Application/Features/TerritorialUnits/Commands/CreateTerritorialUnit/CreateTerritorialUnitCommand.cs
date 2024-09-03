using Application.Features.TerritorialUnits.Dtos;

namespace Application.Features.TerritorialUnits.Commands.CreateTerritorialUnit
{
    public class CreateTerritorialUnitCommand : IRequest<TerritorialUnitDto>
    {
        public string? Nomber { get; set; }
    }
}
