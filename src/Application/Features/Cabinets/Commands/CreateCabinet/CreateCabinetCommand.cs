using Application.Features.Cabinets.Dtos;

namespace Application.Features.Cabinets.Commands.CreateCabinet
{
    public class CreateCabinetCommand : IRequest<CabinetDto>
    {
        public string? Name { get; set; }
    }
}
