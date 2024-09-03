namespace Application.Features.Cabinets.Commands.DeleteCabinet
{
    public record DeleteCabinetCommand(uint id) : IRequest;
}
