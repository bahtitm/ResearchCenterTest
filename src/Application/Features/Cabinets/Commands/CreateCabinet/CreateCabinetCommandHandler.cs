using Application.Features.Cabinets.Dtos;

namespace Application.Features.Cabinets.Commands.CreateCabinet
{
    public class CreateCabinetCommandHandler : IRequestHandler<CreateCabinetCommand, CabinetDto>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;
        public CreateCabinetCommandHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<CabinetDto> Handle(CreateCabinetCommand request, CancellationToken cancellationToken)
        {
            var cabinet = mapper.Map<Cabinet>(request);
            await dbContext.AddAsync(cabinet);
            await dbContext.SaveChangesAsync();
            return mapper.Map<CabinetDto>(cabinet);
        }
    }
}
