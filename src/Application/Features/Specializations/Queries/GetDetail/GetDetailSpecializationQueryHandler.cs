using Application.Features.Specializations.Dtos;

namespace Application.Features.Specializations.Queries.GetDetail
{
    internal class GetDetailSpecializationQueryHandler : IRequestHandler<GetDetailSpecializationQuery, SpecializationDto>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;
        public GetDetailSpecializationQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        public async Task<SpecializationDto> Handle(GetDetailSpecializationQuery request, CancellationToken cancellationToken)
        {
            var specialization = await dbContext.FindByIdAsync<Specialization>(request.id);
            return mapper.Map<SpecializationDto>(specialization);
        }
    }
}

