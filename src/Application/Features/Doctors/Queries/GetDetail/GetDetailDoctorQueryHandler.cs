using Application.Features.Doctors.Dtos;

namespace Application.Features.Doctors.Queries.GetDetail
{
    internal class GetDetailDoctorQueryHandler : IRequestHandler<GetDetailDoctorQuery, DoctorDto>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;
        public GetDetailDoctorQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        public async Task<DoctorDto> Handle(GetDetailDoctorQuery request, CancellationToken cancellationToken)
        {
            var doctor = await dbContext.FindByIdAsync<Doctor>(request.id);
            return mapper.Map<DoctorDto>(doctor);
        }
    }
}