using Application.Features.TerritorialUnits.Dtos;

namespace Application.Features.TerritorialUnits.Commands.CreateTerritorialUnit
{
    internal class CreateTerritorialUnitCommandHandler : IRequestHandler<CreateTerritorialUnitCommand, TerritorialUnitDto>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;
        public CreateTerritorialUnitCommandHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<TerritorialUnitDto> Handle(CreateTerritorialUnitCommand request, CancellationToken cancellationToken)
        {
            var territorialUnit = mapper.Map<TerritorialUnit>(request);
            await dbContext.AddAsync(territorialUnit);
            await dbContext.SaveChangesAsync();
            return mapper.Map<TerritorialUnitDto>(territorialUnit);
        }
    }
}
