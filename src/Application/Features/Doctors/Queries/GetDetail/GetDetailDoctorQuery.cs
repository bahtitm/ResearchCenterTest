using Application.Features.Doctors.Dtos;

namespace Application.Features.Doctors.Queries.GetDetail
{
    public record GetDetailDoctorQuery(uint id) : IRequest<DoctorDto>;
}
