namespace Application.Features.Patients.Commands.DeletePatient
{
    internal class DeletePatientCommandHandler : IRequestHandler<DeletePatientCommand>
    {
        private readonly IApplicationDbContext dbContext;

        public DeletePatientCommandHandler(IApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task Handle(DeletePatientCommand request, CancellationToken cancellationToken)
        {
            var patient = await dbContext.FindByIdAsync<Patient>(request.id);
            dbContext.Set<Patient>().Remove(patient);
            await dbContext.SaveChangesAsync();
        }
    }
}
