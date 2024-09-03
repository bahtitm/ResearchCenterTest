using Application.Features.Specializations.Dtos;

namespace Application.Features.Specializations.Commands.CreateSpecialization
{
    internal class CreateSpecializationCommandHandler : IRequestHandler<CreateSpecializationCommand, SpecializationDto>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;
        public CreateSpecializationCommandHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<SpecializationDto> Handle(CreateSpecializationCommand request, CancellationToken cancellationToken)
        {
            var specialization = mapper.Map<Specialization>(request);
            await dbContext.AddAsync(specialization);
            await dbContext.SaveChangesAsync();
            return mapper.Map<SpecializationDto>(specialization);
        }
    }
}
