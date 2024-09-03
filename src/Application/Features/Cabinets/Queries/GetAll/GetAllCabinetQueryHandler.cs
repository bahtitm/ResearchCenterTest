using Application.Features.Cabinets.Dtos;

namespace Application.Features.Cabinets.Queries.GetAll
{
    public class GetAllCabinetQueryHandler : IRequestHandler<GetAllCabinetQuery, IEnumerable<CabinetDto>>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;
        public GetAllCabinetQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<CabinetDto>> Handle(GetAllCabinetQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(dbContext.Set<Cabinet>().ProjectTo<CabinetDto>(mapper.ConfigurationProvider));
        }
    }
}
