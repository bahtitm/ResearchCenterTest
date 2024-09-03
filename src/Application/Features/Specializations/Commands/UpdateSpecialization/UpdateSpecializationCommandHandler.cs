using Application.Features.Specializations.Dtos;

namespace Application.Features.Specializations.Commands.UpdateSpecialization
{
    internal class UpdateSpecializationCommandHandler : IRequestHandler<UpdateSpecializationCommand, SpecializationDto>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;
        public UpdateSpecializationCommandHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<SpecializationDto> Handle(UpdateSpecializationCommand request, CancellationToken cancellationToken)
        {
            var specialization = await dbContext.FindByIdAsync<Specialization>(request.Id);
            mapper.Map(request, specialization);
            await dbContext.SaveChangesAsync();
            return mapper.Map<SpecializationDto>(specialization);
        }
    }
}