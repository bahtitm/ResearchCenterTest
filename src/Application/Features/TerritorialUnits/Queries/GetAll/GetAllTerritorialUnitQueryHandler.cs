using Application.Features.TerritorialUnits.Dtos;

namespace Application.Features.TerritorialUnits.Queries.GetAll
{
    internal class GetAllTerritorialUnitQueryHandler : IRequestHandler<GetAllTerritorialUnitQuery, IEnumerable<TerritorialUnitDto>>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;
        public GetAllTerritorialUnitQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<TerritorialUnitDto>> Handle(GetAllTerritorialUnitQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(dbContext.Set<TerritorialUnit>().ProjectTo<TerritorialUnitDto>(mapper.ConfigurationProvider));
        }
    }
}