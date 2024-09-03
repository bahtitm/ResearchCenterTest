using Application.Features.Patients.Dtos;

namespace Application.Features.Patients.Queries.GetAll
{
    internal class GetAllPatientQueryHandler : IRequestHandler<GetAllPatientQuery, IEnumerable<PatientDto>>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;
        public GetAllPatientQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<PatientDto>> Handle(GetAllPatientQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(dbContext.Set<Patient>().ProjectTo<PatientDto>(mapper.ConfigurationProvider));
        }
    }
}