using Application.Features.Cabinets.Dtos;

namespace Application.Features.Cabinets.Queries.GetAll
{
    public record GetAllCabinetQuery : IRequest<IEnumerable<CabinetDto>>;
}
