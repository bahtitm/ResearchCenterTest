using Application.Features.TerritorialUnits.Dtos;

namespace Application.Features.TerritorialUnits.Queries.GetDetail
{
    internal class GetDetailTerritorialUnitQueryHandler : IRequestHandler<GetDetailTerritorialUnitQuery, TerritorialUnitDto>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;
        public GetDetailTerritorialUnitQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        public async Task<TerritorialUnitDto> Handle(GetDetailTerritorialUnitQuery request, CancellationToken cancellationToken)
        {
            var territorialUnit = await dbContext.FindByIdAsync<TerritorialUnit>(request.id);
            return mapper.Map<TerritorialUnitDto>(territorialUnit);
        }
    }
}