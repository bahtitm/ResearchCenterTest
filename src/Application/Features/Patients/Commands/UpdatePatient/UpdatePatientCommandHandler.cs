using Application.Features.Patients.Dtos;

namespace Application.Features.Patients.Commands.UpdatePatient
{
    internal class UpdatePatientCommandHandler : IRequestHandler<UpdatePatientCommand, PatientDto>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;
        public UpdatePatientCommandHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<PatientDto> Handle(UpdatePatientCommand request, CancellationToken cancellationToken)
        {
            var patient = await dbContext.FindByIdAsync<Patient>(request.Id);
            mapper.Map(request, patient);
            await dbContext.SaveChangesAsync();
            return mapper.Map<PatientDto>(patient);
        }
    }
}
