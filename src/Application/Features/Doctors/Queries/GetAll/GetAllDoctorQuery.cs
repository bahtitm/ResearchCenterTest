using Application.Features.Doctors.Dtos;

namespace Application.Features.Doctors.Queries.GetAll
{
    public record GetAllDoctorQuery : IRequest<IEnumerable<DoctorDto>>;
}
