namespace Application.Features.Specializations.Commands.DeleteSpecialization
{
    internal class DeleteSpecializationCommandHandler : IRequestHandler<DeleteSpecializationCommand>
    {
        private readonly IApplicationDbContext dbContext;

        public DeleteSpecializationCommandHandler(IApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task Handle(DeleteSpecializationCommand request, CancellationToken cancellationToken)
        {
            var specialization = await dbContext.FindByIdAsync<Specialization>(request.id);
            dbContext.Set<Specialization>().Remove(specialization);
            await dbContext.SaveChangesAsync();
        }
    }
}
