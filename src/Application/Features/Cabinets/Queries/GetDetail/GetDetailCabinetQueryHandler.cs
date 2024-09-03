using Application.Features.Cabinets.Dtos;

namespace Application.Features.Cabinets.Queries.GetDetail
{
    internal class GetDetailCabinetQueryHandler : IRequestHandler<GetDetailCabinetQuery, CabinetDto>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;
        public GetDetailCabinetQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        public async Task<CabinetDto> Handle(GetDetailCabinetQuery request, CancellationToken cancellationToken)
        {
            var cabinet = await dbContext.FindByIdAsync<Cabinet>(request.id);
            return mapper.Map<CabinetDto>(cabinet);
        }
    }
}
