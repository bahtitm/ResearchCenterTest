namespace Application.Features.Specializations.Commands.DeleteSpecialization
{
    public record DeleteSpecializationCommand(uint id) : IRequest;
}
