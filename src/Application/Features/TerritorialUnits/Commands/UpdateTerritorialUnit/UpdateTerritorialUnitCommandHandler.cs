using Application.Features.TerritorialUnits.Dtos;

namespace Application.Features.TerritorialUnits.Commands.UpdateTerritorialUnit
{
    internal class UpdateTerritorialUnitCommandHandler : IRequestHandler<UpdateTerritorialUnitCommand, TerritorialUnitDto>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;
        public UpdateTerritorialUnitCommandHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<TerritorialUnitDto> Handle(UpdateTerritorialUnitCommand request, CancellationToken cancellationToken)
        {
            var TerritorialUnit = await dbContext.FindByIdAsync<TerritorialUnit>(request.Id);
            mapper.Map(request, TerritorialUnit);
            await dbContext.SaveChangesAsync();
            return mapper.Map<TerritorialUnitDto>(TerritorialUnit);
        }
    }
}
