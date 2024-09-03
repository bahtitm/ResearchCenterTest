using Application.Features.Specializations.Dtos;

namespace Application.Features.Specializations.Queries.GetAll
{
    public record GetAllSpecializationQuery : IRequest<IEnumerable<SpecializationDto>>;
}
