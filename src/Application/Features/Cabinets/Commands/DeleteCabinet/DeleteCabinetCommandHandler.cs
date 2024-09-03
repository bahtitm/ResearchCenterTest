namespace Application.Features.Cabinets.Commands.DeleteCabinet
{
    public class DeleteCabinetCommandHandler : IRequestHandler<DeleteCabinetCommand>
    {
        private readonly IApplicationDbContext dbContext;

        public DeleteCabinetCommandHandler(IApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task Handle(DeleteCabinetCommand request, CancellationToken cancellationToken)
        {
            var cabinet = await dbContext.FindByIdAsync<Cabinet>(request.id);
            dbContext.Set<Cabinet>().Remove(cabinet);
            await dbContext.SaveChangesAsync();
        }
    }
}
