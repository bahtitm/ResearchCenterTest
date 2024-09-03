using Application.Features.Doctors.Dtos;

namespace Application.Features.Doctors.Commands.UpdateDoctor
{
    internal class UpdateDoctorCommandHandler : IRequestHandler<UpdateDoctorCommand, DoctorDto>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;
        public UpdateDoctorCommandHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<DoctorDto> Handle(UpdateDoctorCommand request, CancellationToken cancellationToken)
        {
            var doctor = await dbContext.FindByIdAsync<Doctor>(request.Id);
            mapper.Map(request, doctor);
            await dbContext.SaveChangesAsync();
            return mapper.Map<DoctorDto>(doctor);
        }
    }
}
