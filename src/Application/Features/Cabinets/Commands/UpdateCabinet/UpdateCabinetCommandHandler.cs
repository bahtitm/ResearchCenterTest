using Application.Features.Cabinets.Dtos;

namespace Application.Features.Cabinets.Commands.UpdateCabinet
{
    internal class UpdateCabinetCommandHandler : IRequestHandler<UpdateCabinetCommand, CabinetDto>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;
        public UpdateCabinetCommandHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<CabinetDto> Handle(UpdateCabinetCommand request, CancellationToken cancellationToken)
        {
            var cabinet = await dbContext.FindByIdAsync<Cabinet>(request.Id);
            mapper.Map(request, cabinet);
            await dbContext.SaveChangesAsync();
            return mapper.Map<CabinetDto>(cabinet);
        }
    }
}
