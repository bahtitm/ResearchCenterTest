using Application.Features.Cabinets.Dtos;

namespace Application.Features.Cabinets.Queries.GetDetail
{
    public record GetDetailCabinetQuery(uint id) : IRequest<CabinetDto>;
}
