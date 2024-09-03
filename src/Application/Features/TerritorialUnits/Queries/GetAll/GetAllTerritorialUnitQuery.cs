using Application.Features.TerritorialUnits.Dtos;

namespace Application.Features.TerritorialUnits.Queries.GetAll
{
    public record GetAllTerritorialUnitQuery : IRequest<IEnumerable<TerritorialUnitDto>>;
}
