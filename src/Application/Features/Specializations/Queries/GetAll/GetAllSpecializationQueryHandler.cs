using Application.Features.Specializations.Dtos;

namespace Application.Features.Specializations.Queries.GetAll
{
    internal class GetAllSpecializationQueryHandler : IRequestHandler<GetAllSpecializationQuery, IEnumerable<SpecializationDto>>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;
        public GetAllSpecializationQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<SpecializationDto>> Handle(GetAllSpecializationQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(dbContext.Set<Specialization>().ProjectTo<SpecializationDto>(mapper.ConfigurationProvider));
        }
    }
}
