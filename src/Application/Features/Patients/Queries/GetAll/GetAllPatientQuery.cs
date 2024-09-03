using Application.Features.Patients.Dtos;

namespace Application.Features.Patients.Queries.GetAll
{
    public record GetAllPatientQuery : IRequest<IEnumerable<PatientDto>>;
}
