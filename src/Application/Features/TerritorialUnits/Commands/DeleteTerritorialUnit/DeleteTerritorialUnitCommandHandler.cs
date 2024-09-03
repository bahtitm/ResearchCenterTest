namespace Application.Features.TerritorialUnits.Commands.DeleteTerritorialUnit
{
    internal class DeleteTerritorialUnitCommandHandler : IRequestHandler<DeleteTerritorialUnitCommand>
    {
        private readonly IApplicationDbContext dbContext;

        public DeleteTerritorialUnitCommandHandler(IApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task Handle(DeleteTerritorialUnitCommand request, CancellationToken cancellationToken)
        {
            var territorialUnit = await dbContext.FindByIdAsync<TerritorialUnit>(request.id);
            dbContext.Set<TerritorialUnit>().Remove(territorialUnit);
            await dbContext.SaveChangesAsync();
        }
    }
}
