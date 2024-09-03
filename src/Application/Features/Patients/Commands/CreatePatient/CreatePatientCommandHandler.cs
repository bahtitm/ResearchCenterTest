using Application.Features.Patients.Dtos;

namespace Application.Features.Patients.Commands.CreatePatient
{
    internal class CreatePatientCommandHandler : IRequestHandler<CreatePatientCommand, PatientDto>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;
        public CreatePatientCommandHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<PatientDto> Handle(CreatePatientCommand request, CancellationToken cancellationToken)
        {
            var patient = mapper.Map<Patient>(request);
            await dbContext.AddAsync(patient);
            await dbContext.SaveChangesAsync();
            return mapper.Map<PatientDto>(patient);
        }
    }
}