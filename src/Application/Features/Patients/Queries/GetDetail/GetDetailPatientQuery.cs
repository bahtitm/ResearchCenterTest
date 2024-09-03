using Application.Features.Patients.Dtos;

namespace Application.Features.Patients.Queries.GetDetail
{
    public record GetDetailPatientQuery(uint id) : IRequest<PatientDto>;
}
