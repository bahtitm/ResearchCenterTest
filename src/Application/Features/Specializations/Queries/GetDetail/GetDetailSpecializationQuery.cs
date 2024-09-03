using Application.Features.Specializations.Dtos;

namespace Application.Features.Specializations.Queries.GetDetail
{
    public record GetDetailSpecializationQuery(uint id) : IRequest<SpecializationDto>;
}
