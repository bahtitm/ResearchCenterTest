using Application.Features.Doctors.Dtos;

namespace Application.Features.Doctors.Commands.CreateDoctor
{
    internal class CreateDoctorCommandHandler : IRequestHandler<CreateDoctorCommand, DoctorDto>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;
        public CreateDoctorCommandHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<DoctorDto> Handle(CreateDoctorCommand request, CancellationToken cancellationToken)
        {
            var doctor = mapper.Map<Doctor>(request);
            await dbContext.AddAsync(doctor);
            await dbContext.SaveChangesAsync();
            return mapper.Map<DoctorDto>(doctor);
        }
    }
}
