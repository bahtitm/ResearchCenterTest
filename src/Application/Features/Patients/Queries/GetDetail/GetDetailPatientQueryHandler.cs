using Application.Features.Patients.Dtos;

namespace Application.Features.Patients.Queries.GetDetail
{
    internal class GetDetailPatientQueryHandler : IRequestHandler<GetDetailPatientQuery, PatientDto>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;
        public GetDetailPatientQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        public async Task<PatientDto> Handle(GetDetailPatientQuery request, CancellationToken cancellationToken)
        {
            var patient = await dbContext.FindByIdAsync<Patient>(request.id);
            return mapper.Map<PatientDto>(patient);
        }
    }
}

