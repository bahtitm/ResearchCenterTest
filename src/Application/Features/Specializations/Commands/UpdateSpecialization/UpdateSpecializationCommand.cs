using Application.Features.Specializations.Dtos;

namespace Application.Features.Specializations.Commands.UpdateSpecialization
{
    public class UpdateSpecializationCommand : IRequest<SpecializationDto>
    {
        public uint Id { get; set; }
        public string? Name { get; set; }
    }
}
