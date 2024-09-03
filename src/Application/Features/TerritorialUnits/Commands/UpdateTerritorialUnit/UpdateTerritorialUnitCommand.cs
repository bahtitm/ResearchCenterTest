using Application.Features.TerritorialUnits.Dtos;

namespace Application.Features.TerritorialUnits.Commands.UpdateTerritorialUnit
{
    public class UpdateTerritorialUnitCommand : IRequest<TerritorialUnitDto>
    {
        public uint Id { get; set; }
        public string? Nomber { get; set; }
    }
}
