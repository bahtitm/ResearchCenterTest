namespace Application.Features.Doctors.Commands.DeleteDoctor
{
    internal class DeleteDoctorCommandHandler : IRequestHandler<DeleteDoctorCommand>
    {
        private readonly IApplicationDbContext dbContext;

        public DeleteDoctorCommandHandler(IApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task Handle(DeleteDoctorCommand request, CancellationToken cancellationToken)
        {
            var doctor = await dbContext.FindByIdAsync<Doctor>(request.id);
            dbContext.Set<Doctor>().Remove(doctor);
            await dbContext.SaveChangesAsync();
        }
    }
}
