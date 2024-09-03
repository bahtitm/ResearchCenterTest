using Application.Features.Doctors.Dtos;

namespace Application.Features.Doctors.Queries.GetAll
{
    internal class GetAllDoctorQueryHandler : IRequestHandler<GetAllDoctorQuery, IEnumerable<DoctorDto>>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;
        public GetAllDoctorQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<DoctorDto>> Handle(GetAllDoctorQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(dbContext.Set<Doctor>().ProjectTo<DoctorDto>(mapper.ConfigurationProvider));
        }
    }
}
