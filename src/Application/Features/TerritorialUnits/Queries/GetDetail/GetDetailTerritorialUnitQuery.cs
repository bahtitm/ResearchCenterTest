using Application.Features.TerritorialUnits.Dtos;

namespace Application.Features.TerritorialUnits.Queries.GetDetail
{
    public record GetDetailTerritorialUnitQuery(uint id) : IRequest<TerritorialUnitDto>;
}
