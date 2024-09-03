using Application.Features.Cabinets.Dtos;

namespace Application.Features.Cabinets.Commands.UpdateCabinet
{
    public class UpdateCabinetCommand : IRequest<CabinetDto>
    {
        public uint Id { get; set; }
        public string? Name { get; set; }
    }
}
